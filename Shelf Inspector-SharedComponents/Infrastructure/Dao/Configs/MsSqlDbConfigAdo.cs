using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using ShelfInspectorDataModel.Infrastructure.Dto;
using ShelfInspectorDataModel.Infrastructure.Globals;
using ShelfInspectorDataModel.Infrastructure.Interfaces;

namespace ShelfInspectorDataModel.Infrastructure.Dao.Configs{

     sealed internal class MsSqlDbConfigAdo: IDbConfigAdo {

         private static  MsSqlDbConfigAdo _instance;
         private readonly Dictionary<string, string> _configParamNameToXmlNodeAttribute;

         private string _dbConnectionString;
         private string _dbMasterConnectionString;



         private  MsSqlDbConfigAdo()
         {
             _configParamNameToXmlNodeAttribute = new Dictionary<string, string>
             {
                 {GlobalConstants.ServerName, @"uri"},
                 {GlobalConstants.DbName, @"name"},
                 {GlobalConstants.IntegratedSecurity, @"set"},
                 {GlobalConstants.UserName, @"name"},
                 {GlobalConstants.Password, @"value"}
             };

             MakeConnectionStrings(LoadXml());
         }

         public static MsSqlDbConfigAdo GetInstance()
         {
             if (_instance == null){
                 _instance = new MsSqlDbConfigAdo();
             }
             return _instance;
         }

         public string GetDbConnectionString()
         {
             return _dbConnectionString;
         }

         public string GetDbMasterConnectionString()
         {
             return _dbMasterConnectionString;
         }

         public List<ConfigParam> GetSettings()
         {
             return LoadXml();
         }

         public void SetSettings(List<ConfigParam> settings)
         {
             SaveToXmlAndUpdateConnectionStrings(settings);
         }


         private List<ConfigParam> LoadXml(){
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(GlobalConstants.PathToDbSettings);

             try
             {
                 var dbConfig = _configParamNameToXmlNodeAttribute.Keys.Select(nodeName =>
                     new ConfigParam(GlobalConstants.ServerName,
                         xmlDocument.SelectSingleNode(String.Format("//{0}", nodeName))
                             .Attributes[_configParamNameToXmlNodeAttribute[nodeName]]
                             .InnerText)).ToList();
                 return dbConfig;
             }
             catch (NullReferenceException e)
             {
                 throw new Exception();
             }
        }

        private void SaveToXmlAndUpdateConnectionStrings(List<ConfigParam> settings){
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(GlobalConstants.PathToDbSettings);

            foreach (var param in settings)
            {
                try
                {
                    xmlDocument.SelectSingleNode(String.Format("//{0}", param.ParamName)).Attributes[
                        _configParamNameToXmlNodeAttribute[param.ParamName]].InnerText =
                        param.ParamValue;
                }
                catch (NullReferenceException e)
                {
                    throw new Exception(String.Format("{0} prameter name:{1}", GlobalConstants.SavingSettingsException, param.ParamName));
                }
            }

            xmlDocument.Save(GlobalConstants.PathToDbSettings);
            MakeConnectionStrings(settings);
        }

         private void MakeConnectionStrings(List<ConfigParam> settings)
         {
             var integratedSecurity = "";
             var serverName = "";
             var dbName = "";
             var username = "";
             var password = "";

             foreach (var configParam in settings)
             {
                 if (configParam.ParamName.Equals(GlobalConstants.IntegratedSecurity))
                 {
                     integratedSecurity = configParam.ParamValue;
                 }
                 if (configParam.ParamName.Equals(GlobalConstants.ServerName))
                 {
                     serverName = configParam.ParamValue;
                 }
                 if (configParam.ParamName.Equals(GlobalConstants.DbName))
                 {
                     dbName = configParam.ParamValue;
                 }
                 if (configParam.ParamName.Equals(GlobalConstants.UserName))
                 {
                     username = configParam.ParamValue;
                 }
                 if (configParam.ParamName.Equals(GlobalConstants.Password))
                 {
                     password = configParam.ParamValue;
                 }
             }
             // For connection string
             if( integratedSecurity.Equals("True"))
             {
                 _dbConnectionString = String.Format("Data Source={0};Initial Catalog={1};Integrated Security=True;",serverName
                     , dbName);
             }

             _dbConnectionString = String.Format("Data Source={0};Initial Catalog={1};Integrated Security=False;User ID={2}; Password = {3};",
                 serverName, dbName, username, password); //todo make this without initial catalog for connection testing

             //For master connection string
             dbName = @"master";

             if (integratedSecurity.Equals("True"))
             {
                 _dbMasterConnectionString = String.Format("Data Source={0};Initial Catalog={1};Integrated Security=True;", serverName
                     , dbName);
             }

                _dbMasterConnectionString = String.Format("Data Source={0};Initial Catalog={1};Integrated Security=False;User ID={2}; Password = {3};",
                 serverName, dbName, username, password); //todo make this without initial catalog for connection testing



         }
     }
}