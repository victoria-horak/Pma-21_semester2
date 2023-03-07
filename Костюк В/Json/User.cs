using System;

namespace json_read_new
{
    class User
    {
        private DateTime effectiveTo1;
        private DateTime effectiveFrom1;
        private string identificatorId1;

        public string identificatorId { get => identificatorId1; set => identificatorId1 = value; }
        public DateTime effectiveTo { get => effectiveTo1; set => effectiveTo1 = value; }
        public DateTime effectiveFrom { get => effectiveFrom1; set => effectiveFrom1 = value; }

        public override string ToString()
        {
            return $"identificatorId: {identificatorId}\neffectiveFrom: {effectiveFrom}\neffectiveTo: {effectiveTo}\n";
        }
    }
}
