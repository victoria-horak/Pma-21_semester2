using System;
using System.Collections.Generic;

namespace MVC.Entities
{
    public partial class Userinfo
    {
        public int UserId { get; set; }

        public DateTime Birthday { get; set; }

        public string someInfo { get; set; }

        //public virtual ICollection<User> Users { get; set; } = new List<User>();

        public Userinfo()
        {
            UserId = 0;
            Birthday = new DateTime();
            someInfo = string.Empty;
        }

        public override string ToString()
        {
            return "\nSome info: \nBirthday: " + Birthday + "\nSome other info: " + someInfo;
        }
    }
}