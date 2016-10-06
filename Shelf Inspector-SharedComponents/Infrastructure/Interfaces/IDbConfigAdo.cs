namespace ShelfInspectorDataModel.Infrastructure.Interfaces
{
    interface IDbConfigAdo: IConfigAdo
    {
        string GetDbConnectionString();
        string GetDbMasterConnectionString();
    }
}
