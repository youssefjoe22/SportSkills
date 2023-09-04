using Microsoft.AspNetCore.Mvc;

namespace SportSkills.Models
{
    public class Employee
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
       public string Name { get; set; }
       public string Title { get; set; }
       public string Email { get; set; }
       public string Password { get; set; }
       public string Role { get; set; }

       public byte[] Image { get; set; }

    }
}
