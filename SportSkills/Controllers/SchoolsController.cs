using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportSkills.Models;
using System.Numerics;

namespace SportSkills.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {

        private readonly ApplicationdbContext _context;


        public SchoolsController(ApplicationdbContext context)
        {
            _context = context;


        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {

            var school = await _context.schools.ToListAsync();

            return Ok(school);


        }


        [HttpPost]

        public async Task<IActionResult> PostAllAsync(CreateSchoolDto dto)
        {

            var school = new School { 
            
            Name = dto.Name,
            TrainerName = dto.TrainerName,
            };

            await _context.AddAsync(school);
            _context.SaveChanges();
            return (Ok(school));
        }

        [HttpPut("{Name}")]

        public async Task<IActionResult> UpdateAsync(string Name, [FromBody] CreateSchoolDto dto)
        {

            var school = await _context.schools.SingleOrDefaultAsync(s => s.Name == Name);


            if (school == null)
                return NotFound($"Can't Find A School with the name : {Name}   ");



          school.Name = dto.Name;
            school.TrainerName = dto.TrainerName;
            _context.SaveChanges();

            return Ok(school);
        }


        [HttpDelete("{Name}")]
        public async Task<IActionResult> DeleteAsync(string Name)
        {
            var school = await _context.schools.SingleOrDefaultAsync(s => s.Name == Name);


            if (school == null)
                return NotFound($"Can't Find A School with the name : {Name}   ");

            _context.Remove(school);
            await _context.SaveChangesAsync();
            return Ok();

        }


    }
}
