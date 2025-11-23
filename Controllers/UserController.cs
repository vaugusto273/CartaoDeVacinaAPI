using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CartaoDeVacinaAPI.data;
using CartaoDeVacinaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CartaoDeVacinaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public UserController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            _appDbContext.Users.Add(user);
            await _appDbContext.SaveChangesAsync();

            return Ok(user);
        }
        
        [HttpGet]

        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _appDbContext.Users
                .Include(u => u.VaccinationRecords)                
                .ToListAsync();
            return Ok(users);
        }

        [HttpGet("{value}")]

        public async Task<ActionResult<User>> GetUser(string value)
        {
            bool isId = int.TryParse(value, out int id);
            User? user;
            if (isId)
            {
                user = await _appDbContext.Users
                    .Include(u => u.VaccinationRecords)
                    .FirstOrDefaultAsync(u => u.Id == id);
            }
            else
            {
                user = await _appDbContext.Users
                    .Include(u => u.VaccinationRecords)
                    .FirstOrDefaultAsync(u => u.Name.ToLower() == value.ToLower());
            }

            if (user == null) return NotFound();

            return Ok(user);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUser(int id, User updatedUser)
        {   
            var existingUser = await _appDbContext.Users.FindAsync(id);
            
            if (existingUser == null) return NotFound();

            existingUser.Name = updatedUser.Name;

            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _appDbContext.Users.FindAsync(id);

            if (user == null) return NotFound();

            _appDbContext.Users.Remove(user);
            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}