using EventApi.Models;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Bson;
using MongoDB;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace EventApi.DataSources
{
    public class MongoDbManager
    {
        private MongoDatabase Database
        {
            get
            {
                MongoUrl mongoUrl = new MongoUrl(GetMongoDbConnectionString());

                return  MongoDatabase.Create(mongoUrl);
            }
        }

        private string GetMongoDbConnectionString()
        {
            return ConfigurationManager.AppSettings.Get("MONGOLAB_URL");
        }

        public MongoCollection<T> GetEventsCollection<T>(string databaseName)
        {
            var collections = Database.GetCollection<T>(databaseName);

            return collections;
        }
    }
}