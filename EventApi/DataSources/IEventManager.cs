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
        Event[] GetEvents(EventSearchQuery eventSearchQuery);

        Event GetEvent(int id);

        Event[] GetUserEvents(int userId, DateTime? lastModified = null);

        void SaveEvents(Event[] events);

        void UpdateEvents(Event[] events);
    }
}
