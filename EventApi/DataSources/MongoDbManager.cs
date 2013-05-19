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
        private readonly string m_eventsDataBaseName = "events";

        public MongoDatabase Database
        {
            get
            {
                return MongoDatabase.Create(GetMongoDbConnectionString());
            }
        }

        private string GetMongoDbConnectionString()
        {
            return ConfigurationManager.AppSettings.Get("MONGOLAB_URL");
            // ?? ConfigurationManager.AppSettings.Get("MONGOLAB_URI") ??
            //    "mongodb://localhost";
        }
        public void Connect()
        {
            //if (Database.CollectionExists(m_eventsDataBaseName))
            //{
            //    Database.RunCommand(
            //}
            //var mongo = new Mongo();
            //mongo.Connect();
            //var db = mongo.getDB("movieReviews");
            
            var connectionString = GetMongoDbConnectionString();// "mongodb://localhost";
            var client = new MongoClient(connectionString);
            //client.
            var server = client.GetServer();
            var database = server.GetDatabase(m_eventsDataBaseName);
            
            var collection = database.GetCollection<MongoDbEvent>(m_eventsDataBaseName);

            collection.RemoveAll();

            var eventItem = new MongoDbEvent { Text = "MongoDB Test 1", Id= 1, InputType = 0, Time = DateTime.UtcNow };

            collection.Insert(eventItem);
            var id = eventItem.Id;

            var query = Query<MongoDbEvent>.EQ(e => e.Id, id);
            var events = collection.FindAll();

            eventItem.Text = "This is the second test";
            collection.Save(eventItem);

            var update = Update<MongoDbEvent>.Set(e => e.Text, "This is the third tet");
            collection.Update(query, update);

            //collection.Remove(query);
        }

        public MongoCollection<MongoDbEvent> GetEventsCollection()
        {
            MongoUrl mongoUrl = new MongoUrl(ConfigurationManager.AppSettings.Get("MONGOLAB_URL"));
            var connectionString = GetMongoDbConnectionString();// "mongodb://localhost";

            var database = MongoDatabase.Create(mongoUrl);
            //var client = new MongoClient(mongoUrl);

            
            
            //var server = client.GetServer();

            //server.Connect();

            //var database = server.GetDatabase("appharbor_a43b5174-86b3-4950-a8e8-01e79ff5dcc9");
            //if (database == null)
            //{
            //    server.CreateDatabaseSettings(m_eventsDataBaseName);
            //}
            var collections = database.GetCollection<MongoDbEvent>(m_eventsDataBaseName);
            //collections.RemoveAll();
            var tt = collections.FindAll();
            //server.Disconnect();

            return collections;

        }

    }
}