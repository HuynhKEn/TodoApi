using System;
using System.Linq;
using TodoApi.Models;
using TodoApi.Core.Auth;
using System.Threading.Tasks;
using TodoApi.Models.Request;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TodoApi.Core.Service.Interface;

namespace TodoApi.Controller {
    [ApiController]
    [Authorize]
    [Route("api/users")]
    public class UsersController : ControllerBase {
        private IUserService _userService;

        public UsersController(IUserService userService) {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest user) {
            var response = _userService.Authenticate(user);
            if (response == null) {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            return Ok(response);
        }

        [Authorize(Role.Admin)]
        [Route("get-all")]
        [HttpGet]
        public IActionResult GetAll() {
            return Ok();
        }
    }
}
