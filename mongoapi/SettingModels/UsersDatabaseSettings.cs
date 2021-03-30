using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mongoapi.SettingModels
{
    // class used for storing appsettings.json file's UsersDatabaseSettings property values
    public class UsersDatabaseSettings : IUsersDatabaseSettings
    {
        public string UsersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IUsersDatabaseSettings
    {
        string UsersCollectionName { get; set; } // collection name
        string ConnectionString { get; set; } // connection string
        string DatabaseName { get; set; } // db name
    }
}
