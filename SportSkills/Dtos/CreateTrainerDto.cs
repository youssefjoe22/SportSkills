﻿namespace SportSkills.Dtos
{
    public class CreateTrainerDto
    {

       
        public string Name { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string UnionRegisteredNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CvLink { get; set; }
        public string Notes { get; set; }



    }
}
