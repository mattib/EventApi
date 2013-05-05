using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EventApi.DataSource;
using EventApi.Models;

namespace EventApi.Controllers
{
    public class EventController : ApiController
    {
        private IEventManager m_eventManager;

        public EventController()
        {
            m_eventManager = new EventManagerEmulator();
        }

        // GET api/event
        public IEnumerable<Event> Get()
        {
            var result = m_eventManager.GetEvents(new EventSearchQuery());
            return result;
        }

        // GET api/event/5
        public Event Get(int id)
        {
            var result = m_eventManager.GetEvent(id);
            return result;
        }

        // GET api/event/?userId=4
        public IEnumerable<Event> GetByUser(int userId)
        {
            var eventSearchQuery = new EventSearchQuery {UserId = userId};
            var result = m_eventManager.GetEvents(eventSearchQuery);
            return result;
        }

        public IEnumerable<Event> GetByUserAndTime(int userId, string time)
        {
            var dateTime = DateTime.Parse(time);

            var eventSearchQuery = new EventSearchQuery { UserId = userId, LastModified = dateTime};
            var result = m_eventManager.GetEvents(eventSearchQuery);
            return result;
        }

        // POST api/event - ?
        public void Post(Event value) // [FromBody]string value
        {
            m_eventManager.SaveEvents(new Event[]{value});
        }

        // PUT api/event/5  -- ?
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/event/5
        public void Delete(int id)
        {
            var @event = m_eventManager.GetEvent(id);
            @event.RowStatus = 1;
            m_eventManager.UpdateEvents(new [] {@event});
        }
    }
}
