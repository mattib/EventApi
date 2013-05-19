using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventApi.Models;

namespace EventApi.DataSource
{
    public interface IEventManager
    {
        MongoDbEvent[] GetEvents(EventSearchQuery eventSearchQuery);

        MongoDbEvent GetEvent(int id);

        MongoDbEvent[] GetUserEvents(int userId, DateTime? lastModified = null);

        void SaveEvents(MongoDbEvent[] events);

        void UpdateEvents(MongoDbEvent[] events);
    }
}
