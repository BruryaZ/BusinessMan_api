using BusinessMan.Core.Models;
using BusinessMan.Core.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessMan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IService<User> _allUsers;

        public UserController(IService<User> users)
        {
            _allUsers = users;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAsync()
        {
            var user = await _allUsers.GetListAsync();
            //var UsersDTO = _mapper.Map<IEnumerable<User>>(Users);

            return Ok(user);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetAsync(int id)
        {
            var user = await _allUsers.GetByIdAsync(id);
            if (user == null)
                return NotFound();
            //return Ok(_mapper.Map<User>(User));
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<User>> PostAsync([FromBody] User value)
        {
            //var User = _mapper.Map<User>(value);
            var createdUser = await _allUsers.AddAsync(value);
            //return Ok(_mapper.Map<User>(createdUser));
            return Ok(createdUser);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> PutAsync(int id, [FromBody] User value)
        {
            //var updatedUser = await _allUsers.UpdateAsync(id, _mapper.Map<User>(value));
            var updatedUser = await _allUsers.UpdateAsync(id, value);
            if (updatedUser == null)
            {
                return NotFound();
            }
            //return Ok(_mapper.Map<User>(updatedUser));
            return Ok(updatedUser);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var User = await _allUsers.GetByIdAsync(id);
            if (User is null)
            {
                return NotFound();
            }
            await _allUsers.DeleteAsync(User);
            return NoContent();
        }
    }
}