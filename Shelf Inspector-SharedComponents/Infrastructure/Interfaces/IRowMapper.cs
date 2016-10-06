using System.Data.SqlClient;

namespace ShelfInspectorDataModel.Infrastructure.Interfaces
{
    interface IRowMapper<T>
    {
        T MapRow(SqlDataReader reader);
    }
}
