namespace SportSkills.Dtos
{
    public class CreatePlayerDto
    {

        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Ssn { get; set; }
        public int UnionRegisteredNumber { get; set; }
        public int Year { get; set; }
        public string Notes { get; set; }
        public int Money { get; set; }
    }
}
