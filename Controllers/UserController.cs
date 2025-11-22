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
            var users = await _appDbContext.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{value}")]

        public async Task<ActionResult<User>> GetUser(string value)
        {
            bool isId = int.TryParse(value, out int id);
            User? user;
            if (isId)
            {
                user = await _appDbContext.Users.FindAsync(id);
            }
            else
            {
                user = _appDbContext.Users.FirstOrDefault(u => u.Name.ToLower() == value.ToLower());
            }

            if (user == null) return NotFound();

            return Ok(user);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateVaccine(int id, Vaccine updatedVaccine)
        {
            if (id != updatedVaccine.Id) return BadRequest("The URL ID is different from the ID sent in the body.");
            
            var existingVaccine = await _appDbContext.Vaccines.FindAsync(id);
            
            if (existingVaccine == null) return NotFound();

            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}