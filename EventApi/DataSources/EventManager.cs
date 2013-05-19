using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EventApi.Models;
using EventApi.DataSources;

namespace EventApi.DataSource
{
    public class EventManager //: IEventManager
    {
        private MongoDbEventsDataSource m_eventDataSource;

        public EventManager()
        {
            m_eventDataSource = new MongoDbEventsDataSource();
        }

        public Event[] GetEvents(EventSearchQuery eventSearchQuery)
        {
            var eventsList = new List<Event>();
            
            var result = m_eventDataSource.GetAll();
            foreach (var mongoEvent in result)
            {
                var eventItem = new Event(mongoEvent);
                eventsList.Add(eventItem);
            }

            return eventsList.ToArray();
        }

        public Event GetEvent(int id)
        {
            var mongoEvent = m_eventDataSource.GetEvent(id);

            var result = new Event(mongoEvent);
            
            return result;
        }

        public Event[] GetUserEvents(int userId, DateTime? lastModified = null)
        {
            throw new NotImplementedException();
        }

        public void SaveEvents(Event[] events)
        {
            foreach (var eventItem in events)
            {
                var mongoEvent = new MongoDbEvent(eventItem);
                m_eventDataSource.SaveEvent(mongoEvent);
            }


        }

        public void UpdateEvents(Event[] events)
        {
            throw new NotImplementedException();
        }
    }
}