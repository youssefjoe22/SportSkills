using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SportSkills.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchievmentsController : ControllerBase
    {

        private readonly ApplicationdbContext _context;


        public AchievmentsController(ApplicationdbContext context)
        {
            _context = context;


        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {

            var achievment = await _context.achievments.ToListAsync();

            return Ok(achievment);


        }
        [HttpPost]


        public async Task<IActionResult> PostAllAsync(CreateAchievmentsDto dto)
        {

            var achievment = new Achievments
            {
                PlayerName = dto.PlayerName,
                Name = dto.Name,
                date=dto.date,
                Notes = dto.Notes,
            };




            await _context.AddAsync(achievment);
            _context.SaveChanges();
            return (Ok(achievment));
        }



        [HttpPut("{PlayerName}")]

        public async Task<IActionResult> UpdateAsync(string PlayerName, [FromBody] CreateAchievmentsDto dto)
        {
            var achievment = await _context.achievments.SingleOrDefaultAsync(a => a.Name == PlayerName);


            if (PlayerName == null)
                return NotFound($"Can't Find A Player with the name : {PlayerName}   ");


            achievment.PlayerName = dto.PlayerName;
            achievment.Name=dto.Name;
            achievment.date = dto.date;
            achievment.Notes = dto.Notes;

            _context.SaveChanges();

            return Ok(achievment);

        }


        [HttpDelete("{PlayerName}")]

        public async Task<IActionResult> DeleteAsync(string PlayerName)
        {
            var achievment = await _context.achievments.SingleOrDefaultAsync(a => a.Name == PlayerName);

            if (PlayerName == null)
                return NotFound($"Can't Find A Player with the name : {PlayerName}   ");

            _context.Remove(achievment);
            await _context.SaveChangesAsync();
            return Ok();


        }



    }
}
