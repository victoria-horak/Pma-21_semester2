using MongoDB.Bson.Serialization.Attributes;

namespace KontrolnaMongoSQL.Models
{
    public class UserCompany
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public PersonalData PersonalData { get; set; }
        public WorkData WorkData { get; set; }


    }
    public class PersonalData
    {
        public int Age { get; set; }
        public string HomeAddress { get; set; }
    }

    public class WorkData
    {
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Experience { get; set; }
    }
}
