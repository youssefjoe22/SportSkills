using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Azure.Core.HttpHeader;

namespace SportSkills.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainersController : ControllerBase
    {

        private readonly ApplicationdbContext _context;


        public TrainersController(ApplicationdbContext context)
        {
            _context = context;


        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {

            var trainer = await _context.trainers.ToListAsync();

            return Ok(trainer);


        }


        [HttpPost]

        public async Task<IActionResult> PostAllAsync(CreateTrainerDto dto)
        {

            var trainer = new Trainer
            {
                Name = dto.Name,
                Title = dto.Title,
                Email = dto.Email,
                Password = dto.Password,
                PhoneNumber = dto.PhoneNumber,
                UnionRegisteredNumber = dto.UnionRegisteredNumber,
                DateOfBirth = dto.DateOfBirth,
                CvLink = dto.CvLink,
                Notes = dto.Notes,

            };

            await _context.AddAsync(trainer);
            _context.SaveChanges();
            return (Ok(trainer));
        }

        [HttpPut("{Name}")]

        public async Task<IActionResult> UpdateAsync(string Name, [FromBody] CreateTrainerDto dto)
        {

            var trainer = await _context.trainers.SingleOrDefaultAsync(t => t.Name == Name);


            if (trainer == null)
                return NotFound($"Can't Find A Trainer with the name : {Name}   ");


            Name = dto.Name;
            trainer.Title = dto.Title;
            trainer.Email = dto.Email;
            trainer.Password = dto.Password;
            trainer.PhoneNumber = dto.PhoneNumber;
            trainer.UnionRegisteredNumber = dto.UnionRegisteredNumber;
            trainer.DateOfBirth = dto.DateOfBirth;
            trainer.CvLink = dto.CvLink;
            trainer.Notes = dto.Notes;
          
            _context.SaveChanges();

            return Ok(trainer);
        }
        [HttpDelete("{Name}")]
        public async Task<IActionResult> DeleteAsync(string Name)
        {
            var trainer = await _context.groups.SingleOrDefaultAsync(t => t.Name == Name);


            if (trainer == null)
                return NotFound($"Can't Find A Trainer with the name : {Name}   ");

            _context.Remove(trainer);
            await _context.SaveChangesAsync();
            return Ok();

        }




    }
}
