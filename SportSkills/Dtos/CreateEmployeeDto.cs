﻿namespace SportSkills.Dtos
{
    public class CreateEmployeeDto
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public IFormFile Image { get; set; }

    }
}
