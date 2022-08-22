using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using netflix_api_application.Features.Authentication.Commands.RegisterUserCommand;
using netflix_api_domain.Entities;

namespace netflix_api_web.Controllers.v1;

[ApiVersion("1.0")]

public class CustomerController : BaseApiController
{
    //Post api/v1/customer

    [HttpPost]
    public async Task<IActionResult> Post(RegisterUserCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

}
