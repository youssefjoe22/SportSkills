using Microsoft.EntityFrameworkCore;

namespace SportSkills.Models
{
    public class ApplicationdbContext:DbContext
    {

        public ApplicationdbContext(DbContextOptions<ApplicationdbContext>options) :base(options)
        {
            
        }

        public DbSet<Employee>employees { get; set; }
        public DbSet<Organization>organizations { get; set; }
        public DbSet<Player>players { get; set; }
        public DbSet<Trainer>trainers { get; set; }
        public DbSet<Sport>sports { get; set; }
        public DbSet<School>schools { get; set; }
        public DbSet<Team>teams { get; set; }
        public DbSet<Group>groups { get; set; }
        public DbSet<Achievments>achievments { get; set; }
        
        
  
    }
}
