using System.Collections.Generic;

namespace ShelfInspectorDataModel.Infrastructure.Dto
{
    class Query
    {
        public string QueryString { get; set; }
        public Dictionary<string, object> QueryParamsDictionary;

        public Query(string query, Dictionary<string, object> queryParams)
        {
            QueryString = query;
            QueryParamsDictionary = queryParams;
        }
    }
}
