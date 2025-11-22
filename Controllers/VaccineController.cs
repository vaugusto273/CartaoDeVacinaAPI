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
    public class VaccineController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public VaccineController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddVaccine(Vaccine vaccine)
        {
            _appDbContext.Vaccines.Add(vaccine);
            await _appDbContext.SaveChangesAsync();

            return Ok(vaccine);
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Vaccine>>> GetVaccines()
        {
            var vaccines = await _appDbContext.Vaccines.ToListAsync();
            return Ok(vaccines);
        }

        [HttpGet("{value}")]
        public async Task<ActionResult<Vaccine>> GetVaccine(string value)
        {
            bool isId = int.TryParse(value, out int id);
            Vaccine? vaccine;
            if (isId)
            {
                vaccine = await _appDbContext.Vaccines.FindAsync(id);
            }
            else
            {
                vaccine = _appDbContext.Vaccines.FirstOrDefault(v => v.VaccineName.ToLower() == value.ToLower());
            }

            if (vaccine == null) return NotFound();

            return Ok(vaccine);
        }
    
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUser(int id, User updatedUser)
        {
            if (id != updatedUser.Id) return BadRequest("The URL ID is different from the ID sent in the body.");
            
            var existingUser = await _appDbContext.Users.FindAsync(id);
            
            if (existingUser == null) return NotFound();

            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteVaccine(int id)
        {
            var vaccine = await _appDbContext.Vaccines.FindAsync(id);

            if (vaccine == null) return NotFound();

            _appDbContext.Vaccines.Remove(vaccine);
            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }
    }

}