using System.Collections.Generic;
using ShelfInspectorDataModel.Infrastructure.Dto;

namespace ShelfInspectorDataModel.Infrastructure.Interfaces
{
    internal interface IDbIteraction
    {
        void QueryUpdate(Query query);

        void QueryWithTransaction(List<Query> queriesList);

        List<T> QueryQuery<T>(Query query, IRowMapper<T> rowMapper);

        object QueryForObject(Query query);

    }
}
