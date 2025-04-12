using Microsoft.AspNetCore.Mvc;
using TestTask.Domain.Entities;
using TestTask.Domain.Interfaces.Bll;

namespace TestTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/user
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        // GET: api/user/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // POST: api/user
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _userService.CreateAsync(user);
            return Ok(user); 
        }

        // PUT: api/user/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] User user)
        {
            if (id != user.Id)
                return BadRequest("Mismatched IDs");

            var existing = await _userService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _userService.UpdateAsync(user);
            return Ok(user);
        }

        // DELETE: api/user/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var existing = await _userService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _userService.DeleteAsync(id);
            return NoContent();
        }
    }

}
