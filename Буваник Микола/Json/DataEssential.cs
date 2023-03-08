namespace LinQ;

class DataEssential
{
    public string identificatorId { get; set; }
    public string objectId { get; set; }
    public DateTime effectimeFrom { get; set; }
    public DateTime effectiveTo { get; set; }
    public string type { get; set; }
        
      
    public override string ToString()
    {
        return $"identificatorId: {identificatorId}\nobjectId: {objectId}\neffectiveFrom: {effectimeFrom}\neffectiveTo: {effectiveTo}\ntype: {type}\n";
    }
}