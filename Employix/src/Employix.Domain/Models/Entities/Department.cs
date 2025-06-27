namespace Employix.Domain.Models.Entities
{
    public class Department : Entity
    {

        public User Leader { get; set; }

        public List<Team> Teams { get; set; }
    }
}
