using Microsoft.VisualBasic;

namespace conectedTables.Models
{
    public class UserInfo
    {
        public int UserId { get; set; }
        public DateTime Birthday { get; set; }
        public string someInfo { get; set; }

        public UserInfo()
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
