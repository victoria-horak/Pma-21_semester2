using System.ComponentModel.DataAnnotations;

namespace conectedTables.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Job Job { get; set; }
        public UserInfo UserInfo { get; set; }

        public User()
        {
            Id = 0;
            Name = string.Empty;
            Surname = string.Empty;
            Job = new Job();
            UserInfo = new UserInfo();
        }
    }
}
