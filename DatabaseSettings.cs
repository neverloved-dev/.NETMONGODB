namespace MongoCrudTest
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; } = null;
        public string DatabaseName { get; set; } = null;
        public string TestCollectionName { get; set; } = null;
        public string SecondCollectionName { get; set; } = null;
    }
}
