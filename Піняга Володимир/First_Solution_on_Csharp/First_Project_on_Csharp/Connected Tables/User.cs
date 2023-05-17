using System;
using System.Collections.Generic;

namespace MVC.Entities
{
    public partial class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int JobId { get; set; }

        public int UserInfoId { get; set; }

        public Jobplace Job { get; set; }

        public Userinfo UserInfo { get; set; }

        public User()
        {
            Id = 0;
            Name = string.Empty;
            Surname = string.Empty;
            Job = new Jobplace();
            UserInfo = new Userinfo();
        }
    }
}