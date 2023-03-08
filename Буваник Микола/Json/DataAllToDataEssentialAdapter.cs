namespace LinQ;
class DataAllToDataEssentialAdapter
{
    private readonly DataAll dataAll;

    public DataAllToDataEssentialAdapter(DataAll dataAll)
    {
        this.dataAll = dataAll;
    }

    public DataEssential ToDataEssential()
    {
        return new DataEssential
        {
            identificatorId = dataAll.identificatorId,
            objectId = dataAll.dataItem.objectId,
            effectimeFrom = DateTime.Parse(dataAll.dataItem.effectimeFrom),
            effectiveTo = DateTime.Parse(dataAll.dataItem.effectiveTo),
            type = dataAll.info.type
        };
    }
}