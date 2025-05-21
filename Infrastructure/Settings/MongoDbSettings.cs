﻿namespace Infrastructure.Settings
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public CollectionsSettings Collections { get; set; } = null!;
    }

    public class CollectionsSettings
    {
        public string ProductCollection { get; set; } = null!;

    }
}
