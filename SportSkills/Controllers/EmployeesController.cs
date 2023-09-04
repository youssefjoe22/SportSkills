using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace SportSkills.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationdbContext _context;


        private new List<string>_allowedExtensions =new List<string> {"jpg","png","jpeg" };
        public EmployeesController(ApplicationdbContext context)
        {
         _context = context;
            

        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {

            var employee = await _context.employees.ToListAsync();

            return Ok(employee);


        }

        [HttpPost]
        public async Task<IActionResult> PostAllAsync([FromForm]CreateEmployeeDto dto)
        {

            if (_allowedExtensions.Contains(Path.GetExtension(dto.Image.FileName).ToLower()))
                return BadRequest("Only .png and .jpg images are Allowed");
                 
            using var dataStream=new MemoryStream();
            await dto.Image.CopyToAsync(dataStream);

            var employee = new Employee {  
            
            Name=dto.Name,
                Title = dto.Title,
                Email =dto.Email,
            Password=dto.Password,
            Image = dataStream.ToArray(),
            Role = dto.Role

            };


            await _context.AddAsync(employee);
            _context.SaveChanges();
            return(Ok(employee));
        }


       
         

    }
}
