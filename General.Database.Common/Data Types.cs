namespace General.Database.Common
{
    public class OpenDatabaseParameters
    {
        public string DatabaseType { get; set; }
        public string DatabaseName { get; set; }
        public string DatabaseTables { get; set; }
        public string DatabaseTableFieldsCsvPath { get; set; }
        public string DatabaseIpAddress { get; set; }
        public string DatabaseIpPort { get; set; }
        public string DatabaseConnectionString { get; set; }
        public string DatabaseUsername { get; set; }
        public string DatabasePassword { get; set; }
    }
}
