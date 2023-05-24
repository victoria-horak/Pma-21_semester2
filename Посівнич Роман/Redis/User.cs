namespace SQL_RedisUser.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public Address HomeAddress { get; set; }

        public Pet UserPet { get; set; }


    }
}
