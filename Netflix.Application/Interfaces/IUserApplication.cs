using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Netflix.Application.Commons.Bases;
using Netflix.Application.Dtos.User.Request;

namespace Netflix.Application.Interfaces
{
    public interface IUserApplication
    {
        Task<BaseResponse<bool>> RegisterUser(UserRequestDto requestDto);
        Task<BaseResponse<string>> AuthenticateUser(TokenRequestDto requestDto);
        Task<BaseResponse<string>> RefreshToken(TokenRequestDto requestDto);

    }
}