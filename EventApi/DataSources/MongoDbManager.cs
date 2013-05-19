using EventApi.Models;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
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
            var connectionString = GetMongoDbConnectionString();// "mongodb://localhost";
            var client = new MongoClient(connectionString);
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
            var connectionString = GetMongoDbConnectionString();// "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase(m_eventsDataBaseName);
            return database.GetCollection<MongoDbEvent>(m_eventsDataBaseName);

        }

    }
}