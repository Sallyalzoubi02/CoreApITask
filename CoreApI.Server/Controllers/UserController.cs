using CoreApI.Server.Models;
using CoreApI.Server.Service;
using Microsoft.AspNetCore.Mvc;

namespace CoreApI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("login")]
        public ActionResult GetUser([FromForm]UserDTO userDto) {
            if (userDto == null) {
                return BadRequest();
            }
            else {
                _userService.GetUser(userDto);
                return Ok(userDto);
            }
        }


        [HttpPost("Register")]

        public IActionResult register([FromForm] RegsiterDTO regDto)
        {
            if (regDto == null)
            {
                return BadRequest();
            }
            if (_userService.register(regDto))
                return Ok(regDto);
            else return BadRequest();
        }



        [HttpPost]
        public IActionResult regist([FromForm] RegsiterDTO user)
        {
            if (user == null)
            {
                return BadRequest();

            }
            var exist = _userService.regist(user);
            if ( exist == true)
                  return Ok(user);


            return BadRequest();
        }
    }
}
