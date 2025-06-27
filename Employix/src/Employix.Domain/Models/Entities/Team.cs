namespace Employix.Domain.Models.Entities
{
    public class Team : Entity
    {

        public string Name { get; set; }

        public string Description { get; set; }
        public User Leader { get; set; }
        public List<User> Members { get; set; }
    }
}
