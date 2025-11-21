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

        [HttpGet("{id:int}")]

        public async Task<ActionResult<Vaccine>> GetVaccine(int id)
        {
            var vaccine = await _appDbContext.Vaccines.FindAsync(id);
            if (vaccine == null)
            {
                return NotFound();
            }
            return Ok(vaccine);
        }
    }

}