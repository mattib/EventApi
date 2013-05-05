using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EventApi.Models;

namespace EventApi.DataSource
{
    public class EventManager : IEventManager
    {
        public Event[] GetEvents(EventSearchQuery eventSearchQuery)
        {
            throw new NotImplementedException();
        }

        public Event GetEvent(int id)
        {
            throw new NotImplementedException();
        }

        public Event[] GetUserEvents(int userId, DateTime? lastModified = null)
        {
            throw new NotImplementedException();
        }

        public void SaveEvents(Event[] events)
        {
            throw new NotImplementedException();
        }

        public void UpdateEvents(Event[] events)
        {
            throw new NotImplementedException();
        }
    }
}