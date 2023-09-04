namespace SportSkills.Models
{
    public class Group
    {

      public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Days { get; set; }
        public int Hour  { get; set; }
        public string TrainerName { get; set; }
    }
}
