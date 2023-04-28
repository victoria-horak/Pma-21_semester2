using System.Runtime.Serialization;

namespace inClass.Models
{
    public class User
    {
        public int Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set;}
        public UsersInfo Info { get; set; }
    }
}
