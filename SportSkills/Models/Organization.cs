namespace SportSkills.Models
{
    public class Organization
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public int NumberOfSports { get; set; }
        [Required]
        [MaxLength(255)]
        public string MgrName { get; set; }
        public string MgrEmail { get; set; }
        public string Password { get; set; }

        public byte[] Image { get; set; }


    }
}
