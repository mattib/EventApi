using EventApi.Models;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventApi.DataSources
{
    public class MongoDbEventsDataSource //: IEventsDataSource
    {
        private MongoDbManager m_dbManager;
        public MongoDbEventsDataSource()
        {
            m_dbManager = new MongoDbManager();
        }

        public MongoDbEvent[] GetAll()
        {
            var eventsCollection = m_dbManager.GetEventsCollection();

            var events = eventsCollection.FindAll();
            return events.ToArray();
        }

        public MongoDbEvent GetEvent(int id)
        {
            var eventsCollection = m_dbManager.GetEventsCollection();
            var query = Query<MongoDbEvent>.EQ(e => e.Id, id);
            var eventItem = eventsCollection.FindOne(query);
            return eventItem;
        }

        public void SaveEvent(MongoDbEvent eventItem)
        {
            var eventsCollection = m_dbManager.GetEventsCollection();
            eventsCollection.Save(eventItem);
        }
    }
}