using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Netflix.Application.Commons.Bases;
using Netflix.Application.Dtos.User.Request;
using Netflix.Application.Interfaces;
using Netflix.Domain.Entities;
using Netflix.Infraestructure.Persistences.Interfaces;
using Netflix.Utilities.Static;
using BC = BCrypt.Net.BCrypt;
using Netflix.Application.Validators.Authentication;

namespace Netflix.Application.Services
{
    public class UserApplication : IUserApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly AuthenticationValidator _authenticationValidator;

        public UserApplication(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration, AuthenticationValidator authenticationValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
            _authenticationValidator = authenticationValidator;
        }
        public async Task<BaseResponse<string>> AuthenticateUser(TokenRequestDto requestDto)
        {
            var response = new BaseResponse<string>();
            var account = await _unitOfWork.User.AccountByUserName(requestDto.Email!);

            if (account is not null)
            {
                if (BC.Verify(requestDto.Password!, account.Password))
                {
                    response.Data = GenerateToken(account);
                    response.Message = ReplyMessage.MESSAGE_TOKEN;
                    response.IsSuccess = true;
                    return response;
                }
            }
            else
            {
                response.Message = ReplyMessage.MESSAGE_LOGIN_FAILED;
                response.IsSuccess = false;
            }

            return response;
        }


        public async Task<BaseResponse<bool>> RegisterUser(UserRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var validation = _authenticationValidator.Validate(requestDto);
            if (!validation.IsValid)
            {
                response.IsSuccess = false;
                response.Errors = validation.Errors;
                response.Message = ReplyMessage.MESSAGE_ERROR_VALIDATION;
                return response;
            }

            var account = _mapper.Map<User>(requestDto,
                opt => opt.BeforeMap((src, dest) => dest.State = 1));

            account.Password = BC.HashPassword(account.Password);

            response.Data = await _unitOfWork.User.RegisterAsync(account);

            if (response.Data)
            {
                response.Message = ReplyMessage.MESSAGE_INSERT;
                response.IsSuccess = true;
            }
            else
            {
                response.Message = ReplyMessage.MESSAGE_FAILED;
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<BaseResponse<string>> RefreshToken(TokenRequestDto requestDto)
        {
            var response = new BaseResponse<string>();
            var account = await _unitOfWork.User.AccountByUserName(requestDto.Email!);

            if (account is not null)
            {
                response.Data = GenerateToken(account);
                response.Message = ReplyMessage.MESSAGE_TOKEN;
                response.IsSuccess = true;
                return response;
            }
            else
            {
                response.Message = ReplyMessage.MESSAGE_LOGIN_FAILED;
                response.IsSuccess = false;
            }

            return response;
        }

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.FamilyName, user.UserName!),
                new Claim(JwtRegisteredClaimNames.GivenName, user.Email!),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, Guid.NewGuid().ToString(), ClaimValueTypes.Integer64)

            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(int.Parse(_configuration["Jwt:Expires"])),
                signingCredentials: credentials,
                notBefore: DateTime.UtcNow
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}