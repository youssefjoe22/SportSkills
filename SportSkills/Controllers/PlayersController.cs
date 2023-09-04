using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportSkills.Models;
using System.Numerics;

namespace SportSkills.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class playersController : ControllerBase
    {

        private readonly ApplicationdbContext _context;


        public playersController(ApplicationdbContext context)
        {
            _context = context;


        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {

            var player = await _context.players.ToListAsync();

            return Ok(player);


        }
        [HttpPost]


        public async Task<IActionResult> PostAllAsync(CreatePlayerDto dto)
        {

            var player =new Player
            {
                Name= dto.Name,
                PhoneNumber= dto.PhoneNumber,
                Ssn= dto.Ssn,
                UnionRegisteredNumber= dto.UnionRegisteredNumber,
                Year = dto.Year,
                Notes = dto.Notes,
                Money=dto.Money
            };




            await _context.AddAsync(player);
            _context.SaveChanges();
            return (Ok(player));
        }


        [HttpPut("{Name}")]

        public async Task<IActionResult> UpdateAsync(string Name, [FromBody] CreatePlayerDto dto)
        {
            var player= await _context.players.SingleOrDefaultAsync(p=>p.Name==Name);


            if (player == null)
                return NotFound($"Can't Find A player with the name : {Name}   ");

            player.Name=dto.Name;
            player.PhoneNumber = dto.PhoneNumber;
            player.Ssn = dto.Ssn;
            player.UnionRegisteredNumber = dto.UnionRegisteredNumber;
            player.Year = dto.Year; 
            player.Notes = dto.Notes;
            player.Money = dto.Money;
            _context.SaveChanges();

            return Ok(player);

        }


        [HttpDelete("{Name}")]

        public async Task<IActionResult>DeleteAsync(string Name)
        {
            var player = await _context.players.SingleOrDefaultAsync(p => p.Name == Name);

            if (player == null)
                return NotFound($"Can't Find A player with the name : {Name}   ");
                
            _context.Remove(player);
            await _context.SaveChangesAsync();
            return Ok(); 


        }


    }
}
