using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MisfitsAssignment.Models;
using MisfitsAssignment.Models.Repository;
using MisfitsAssignment.Models.DataManager;

namespace MisfitsAssignment.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserDataRepository<User> _dataRepository;

        public UserController(IUserDataRepository<User> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/User
        [HttpGet]
        public IActionResult GetUser()
        {
            IEnumerable<User> users = _dataRepository.GetAll();
            return Ok(users);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            User user = _dataRepository.Get(id);
            if (user == null)
            {
                return NotFound("The User record couldn't be found.");
            }
            return Ok(user);
        }
        // GET: api/User/5
        [HttpGet("getuser/{userid}")]
        [Route("getuser")]
        public IActionResult GetUser(string userid)
        {
            User user = _dataRepository.Get(userid);
            if (user == null)
            {
                return NotFound("The User record couldn't be found.");
            }
            return Ok(user);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult PutUser(int id,[FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Employee is null.");
            }

            User userToUpdate = _dataRepository.Get(id);
            if (userToUpdate == null)
            {
                return NotFound("The User record couldn't be found.");
            }

            _dataRepository.Update(userToUpdate, user);
            return NoContent();
        }

        // POST: api/User
        [HttpPost]
        public IActionResult PostUser([FromBody]User user)
        {
            if (user == null)
            {
                return BadRequest("User is null.");
            }

            _dataRepository.Add(user);
            return CreatedAtRoute(
                  "Get",
                  new { Id = user.ID },
                  user); if (user == null)
            {
                return BadRequest("User is null.");
            }
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            User user = _dataRepository.Get(id);
            if (user == null)
            {
                return NotFound("The User record couldn't be found.");
            }

            _dataRepository.Delete(user);
            return NoContent();
        }
    }
}
