namespace JsonTaskAttempt2
{
    public class Root
    {
        public string identificatorId { get; set; }
        public DataItems dataItem { get; set; }
        public Info info { get; set; }
              
        public override string ToString()
        {
            return
                $"id: {identificatorId}\neffectiveFrom:";
        }
    }
}