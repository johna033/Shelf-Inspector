using System.Collections.Generic;
using System.Data.SqlClient;
using ShelfInspectorDataModel.Infrastructure.Dao.Configs;
using ShelfInspectorDataModel.Infrastructure.Dto;
using ShelfInspectorDataModel.Infrastructure.Interfaces;

namespace ShelfInspectorDataModel.Infrastructure.ORM
{
    internal sealed class MsSqlDb: IDbIteraction
    {
        private static MsSqlDb _instance;
        private readonly IDbConfigAdo _dbConfigAdo = MsSqlDbConfigAdo.GetInstance();

        private MsSqlDb(){ }

        public static MsSqlDb GetInstance()
        {
            return _instance ?? (_instance = new MsSqlDb());
        }

        public void QueryUpdate(Query query)
        {
            using (var sqlConnection = new SqlConnection(_dbConfigAdo.GetDbConnectionString()))
            {
                var paramsDictionary = query.QueryParamsDictionary;
                var sqlCommand = new SqlCommand(query.QueryString, sqlConnection);
                if (paramsDictionary != null)
                {
                    foreach (var key in paramsDictionary.Keys)
                    {
                        sqlCommand.Parameters.AddWithValue(key, paramsDictionary[key]);
                    }
                }
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public void QueryWithTransaction(List<Query> queriesList)
        {
            throw new System.NotImplementedException();
        }

        public void QueryUpdateOnMaster(string query)
        {
            using (var sqlConnection = new SqlConnection(_dbConfigAdo.GetDbMasterConnectionString()))
            {
                var sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public List<T> QueryQueryOnMaster<T>(string query, IRowMapper<T> rowMapper)
        {
            var result = new List<T>();
            using (var sqlConnection = new SqlConnection(_dbConfigAdo.GetDbMasterConnectionString()))
            {
                var command = new SqlCommand(query, sqlConnection);
               
                sqlConnection.Open();
                var sqlReader = command.ExecuteReader();
                while (sqlReader.Read())
                {
                    result.Add(rowMapper.MapRow(sqlReader));
                }
                sqlConnection.Close();
                return result;
            }
        }

        public List<T> QueryQuery<T>(Query query, IRowMapper<T> rowMapper)
        {
            var result = new List<T>();
            using (var sqlConnection = new SqlConnection(_dbConfigAdo.GetDbConnectionString()))
            {
                var paramsDictionary = query.QueryParamsDictionary;
                var command = new SqlCommand(query.QueryString, sqlConnection);
                if (paramsDictionary != null)
                {
                    foreach (var key in paramsDictionary.Keys)
                    {
                        command.Parameters.AddWithValue(key, paramsDictionary[key]);
                    }
                }
                sqlConnection.Open();
                var sqlReader = command.ExecuteReader();
                while (sqlReader.Read())
                {
                    result.Add(rowMapper.MapRow(sqlReader));
                }
                sqlConnection.Close();
                return result;
            }
        }

        public object QueryForObject(Query query)
        {
            using (var sqlConnection = new SqlConnection(_dbConfigAdo.GetDbConnectionString()))
            {
                var paramsDictionary = query.QueryParamsDictionary;
                var command = new SqlCommand(query.QueryString, sqlConnection);
                if (paramsDictionary != null)
                {
                    foreach (var key in paramsDictionary.Keys)
                    {
                        command.Parameters.AddWithValue(key, paramsDictionary[key]);
                    }
                }
                sqlConnection.Open();
                var result = command.ExecuteScalar();
                sqlConnection.Close();
                return result;
            }
        }
    }
}