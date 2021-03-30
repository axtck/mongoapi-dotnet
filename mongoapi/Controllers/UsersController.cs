using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mongoapi.Models;
using mongoapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mongoapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService userService;

        public UsersController(UserService uService)
        {
            userService = uService;
        }

        [HttpGet]
        public ActionResult<List<User>> Get() =>
            userService.Get();

        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public ActionResult<User> Get(string id)
        {
            var usr = userService.Get(id);

            if (usr == null)
            {
                return NotFound();
            }

            return usr;
        }

        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            userService.Create(user);

            return CreatedAtRoute("GetUser", new { id = user.Id.ToString() }, user); // return the created user 
        }

        [HttpPut("id:length(24)")]
        public IActionResult Update(string id, User user)
        {
            var usr = userService.Get(id);

            if (usr == null)
            {
                return NotFound();
            }

            userService.Update(id, user);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var usr = userService.Get(id);

            if (usr == null)
            {
                return NotFound();
            }

            userService.Remove(usr.Id);

            return NoContent();
        }
    }
}
