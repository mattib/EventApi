using EventApi.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace EventApi.DataSources
{
    public class MongoDbTester
    {
        public MongoDatabase Database
        {
            get
            {
                return MongoDatabase.Create(GetMongoDbConnectionString());
            }
        }

        private string GetMongoDbConnectionString()
        {
            return ConfigurationManager.AppSettings.Get("MONGOHQ_URL") ??
                ConfigurationManager.AppSettings.Get("MONGOLAB_URI") ??
                "mongodb://localhost/Things";
        }
        public void Connect()
        {
            var connectionstring = GetMongoDbConnectionString();
            var url = new MongoUrl(connectionstring);
            var client = new MongoClient(url);
            var server = client.GetServer();
            var database = server.GetDatabase(url.DatabaseName);

            var collection = database.GetCollection<Event>("Events");

            // insert object
            collection.Insert(new Event { Id = 1, Text ="This is a test" });

            // fetch all objects
            var thingies = collection.FindAll();
        }
    }
}