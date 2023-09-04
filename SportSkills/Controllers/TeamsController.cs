using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SportSkills.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {

        private readonly ApplicationdbContext _context;


        public TeamsController(ApplicationdbContext context)
        {
            _context = context;


        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {

            var team = await _context.teams.ToListAsync();

            return Ok(team);


        }

        [HttpPost]

        public async Task<IActionResult> PostAllAsync(CreateTeamDto dto)
        {

            var team = new Team
            {

                Name = dto.Name,
                TrainerName = dto.TrainerName,
            };

            await _context.AddAsync(team);
            _context.SaveChanges();
            return (Ok(team));
        }



        [HttpPut("{Name}")]

        public async Task<IActionResult> UpdateAsync(string Name, [FromBody] CreateTeamDto dto)
        {

            var team = await _context.teams.SingleOrDefaultAsync(t => t.Name == Name);


            if (team == null)
                return NotFound($"Can't Find A Team with the name : {Name}   ");



            team.Name = dto.Name;
            team.TrainerName = dto.TrainerName;
            _context.SaveChanges();

            return Ok(team);
        }



        [HttpDelete("{Name}")]
        public async Task<IActionResult> DeleteAsync(string Name)
        {
            var team = await _context.teams.SingleOrDefaultAsync(t => t.Name == Name);


            if (team == null)
                return NotFound($"Can't Find A Team with the name : {Name}   ");

          _context.Remove(team);
          await _context.SaveChangesAsync();
          return Ok();

        }
    }
}
