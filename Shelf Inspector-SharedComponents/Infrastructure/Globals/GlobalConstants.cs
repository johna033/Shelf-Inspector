namespace ShelfInspectorDataModel.Infrastructure.Globals {
    class GlobalConstants{

        public const string InfoMessageBoxCaption = "Lab Manager v 1.0.1";
        public const string ErrorMessageBoxCaption = "Lab Manager v 1.0.1";
        public const string ManageDbCaption = "Lab Manager v 1.0.1";

        public const string PathToDbSettings = "config\\dbSettings.xml";

        public const string ServerName = "server-name";
        public const string DbName = "db-name"; 
        public const string IntegratedSecurity = "integrated-security";
        public const string UserName = "userid";
        public const string Password = "password";

        public const byte ManageDbSettings = 0;
        public const byte CreateDb = 1;

        public const string UserAdministratorRole = "Administrator";
        public const string UserInvestigatorRole = "Investigator";

        public const string GedCode = "ged";
        public const string DefaultAdminName = "default_admin";

        public const string SavingSettingsException = "Exception while trying to save DB connection settings!";
        public const string LoadingSettingsException = "Exception while trying to load DB connection settings!";

    }
}
