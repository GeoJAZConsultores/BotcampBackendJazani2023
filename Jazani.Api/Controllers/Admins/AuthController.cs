
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Jazani.Application.Admins.Dtos.Users;
using Jazani.Application.Admins.Services;
using Jazani.Api.Exceptions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {

        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }



        // POST api/values
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserSecurityDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorValidationModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<BadRequest, Ok<UserSecurityDto>>> Post([FromBody]UserAuthDto userAuth)
        {
            UserSecurityDto userSecurity = await _userService.LoginAsync(userAuth);

            return TypedResults.Ok(userSecurity);
        }
    }
}

