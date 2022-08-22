using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using netflix_api_application.Features.Authentication.Commands.RegisterUserCommand;
using netflix_api_domain.Entities;

namespace netflix_api_application.Mappings;

public class GeneralProfile : Profile
{
    public GeneralProfile()
    {
        #region Commands
        CreateMap<RegisterUserCommand, Customer>();
        #endregion

    }
}
