using Microsoft.AspNetCore.Mvc;
using Jazani.Application.Admins.Dtos.Users;
using Jazani.Application.Admins.Services;
using Microsoft.AspNetCore.Http.HttpResults;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }



        // POST api/values
        [HttpPost]
        public async Task<Results<BadRequest, CreatedAtRoute<UserDto>>> Post([FromBody] UserSaveDto userSave)
        {
            UserDto user = await _userService.CreateAsync(userSave);

            return TypedResults.CreatedAtRoute(user);
        }
    }
}

