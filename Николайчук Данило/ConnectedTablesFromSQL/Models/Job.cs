namespace conectedTables.Models
{
    public class Job
    {
        public int UserId { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public string Position { get; set; }

        public Job()
        {
            UserId = 0;
            Company = string.Empty;
            Location = string.Empty;
            Position = string.Empty;
        }
        public override string ToString()
        {
            return "\nCompany: " + Company + "\nLocation: " + Location + "\nPosition: " + Position;
        }
    }
}
