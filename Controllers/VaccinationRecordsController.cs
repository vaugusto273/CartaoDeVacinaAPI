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
    [Route("api/users/{userID:int}/[controller]")]
    public class VaccinationRecordsController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public VaccinationRecordsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]

        public async Task<ActionResult<VaccinationRecord>> AddRecord(int userID, VaccinationRecord record)
        {
            var user = await _appDbContext.Users.FindAsync(userID);
            if (user == null) return NotFound($"User with ID {userID} not found.");
            
            var vaccine = await _appDbContext.Vaccines.FindAsync(record.VaccineID);
            if (vaccine == null) return NotFound($"vaccine with ID {record.VaccineID} not found.");

            if (record.DoseNumber < 1) return BadRequest("The DoseNumver cannot be less than 1");

            record.UserID = userID;

            if(record.ApplicationDate == default) 
                record.ApplicationDate = DateTime.UtcNow; 
            
            _appDbContext.VaccinationRecords.Add(record);

            try
            {
                await _appDbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }

            return Ok(record);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VaccinationRecord>>> GetRecords(int userID)
        {
            var userExists = await _appDbContext.Users
                .AnyAsync(u => u.Id == userID);
            
            if (!userExists) return NotFound($"User with ID {userID} not found.");

            var records = await _appDbContext.VaccinationRecords
                .Include(vr => vr.Vaccine)
                .Where(vr => vr.UserID == userID)
                .ToListAsync();
            
            return Ok(records);
        }

        [HttpGet("{recordID:int}")]

        public async Task<ActionResult<VaccinationRecord>> GetRecordByID(int userID, int recordID)
        {
            var userExists = await _appDbContext.Users.AnyAsync(u => u.Id == userID);
            if (!userExists) return NotFound($"User with ID {userID} not found");

            var record = await _appDbContext.VaccinationRecords
                .Include(vr => vr.Vaccine)
                .FirstOrDefaultAsync(vr => vr.Id == recordID && vr.UserID == userID);

            if (record == null) return NotFound($"Record {recordID} not found for this user");
        
            return Ok(record);
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteRecord(int userID, int recordID)
        {
            var record = await _appDbContext.VaccinationRecords
                .FirstOrDefaultAsync(vr => vr.Id == recordID && vr.UserID == userID);
            if(record == null) return NotFound($"Record {recordID} not found for user {userID}.");

            _appDbContext.VaccinationRecords.Remove(record);
            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}