using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SportSkills.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {

        private readonly ApplicationdbContext _context;


        public GroupsController(ApplicationdbContext context)
        {
            _context = context;


        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {

            var group = await _context.groups.ToListAsync();

            return Ok(group);


        }
        [HttpPost]


        public async Task<IActionResult> PostAllAsync(CreateGroupDto dto)
        {

            var group = new Group
            {
                Name = dto.Name,
                Hour = dto.Hour,
                Days = dto.Days,
                TrainerName = dto.TrainerName,
            };




            await _context.AddAsync(group);
            _context.SaveChanges();
            return (Ok(group));
        }



        [HttpPut("{Name}")]

        public async Task<IActionResult> UpdateAsync(string Name, [FromBody] CreateGroupDto dto)
        {
            var group = await _context.groups.SingleOrDefaultAsync(g => g.Name == Name);


            if (group == null)
                return NotFound($"Can't Find A Group with the name : {Name}   ");

            group.Name = dto.Name;
           group.Hour = dto.Hour;
            group.Days = dto.Days;
            group.TrainerName = dto.TrainerName;
            _context.SaveChanges();

            return Ok(group);

        }


        [HttpDelete("{Name}")]

        public async Task<IActionResult> DeleteAsync(string Name)
        {
            var group = await _context.groups.SingleOrDefaultAsync(g => g.Name == Name);

            if (group == null)
                return NotFound($"Can't Find A Group with the name : {Name}   ");

            _context.Remove(group);
            await _context.SaveChangesAsync();
            return Ok();


        }


    }
}
