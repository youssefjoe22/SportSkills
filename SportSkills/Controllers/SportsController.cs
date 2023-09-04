using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SportSkills.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportsController : ControllerBase
    {

        private readonly ApplicationdbContext _context;


        public SportsController(ApplicationdbContext context)
        {
            _context = context;


        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {

            var sport = await _context.sports.ToListAsync();

            return Ok(sport);


        }

        [HttpPost]

        public async Task<IActionResult> PostAllAsync(CreateSportDto dto)
        {

            var sport = new Sport
            {

                Name = dto.Name,
             //   Image = dto.Image,
            };

            await _context.AddAsync(sport);
            _context.SaveChanges();
            return (Ok(sport));
        }



        [HttpPut("{Name}")]

        public async Task<IActionResult> UpdateAsync(string Name, [FromBody] CreateSportDto dto)
        {

            var sport = await _context.sports.SingleOrDefaultAsync(s => s.Name == Name);


            if (sport == null)
                return NotFound($"Can't Find A Sport with the name : {Name}   ");



            sport.Name = dto.Name;
            //sport.Image = dto.Image;
            _context.SaveChanges();

            return Ok(sport);
        }



        [HttpDelete("{Name}")]
        public async Task<IActionResult> DeleteAsync(string Name)
        {
            var sport = await _context.sports.SingleOrDefaultAsync(t => t.Name == Name);


            if (sport == null)
                return NotFound($"Can't Find A Sport with the name : {Name}   ");

            _context.Remove(sport);
            await _context.SaveChangesAsync();
            return Ok();


        }
}
    }
