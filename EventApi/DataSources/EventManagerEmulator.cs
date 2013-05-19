using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EventApi.Models;

namespace EventApi.DataSource
{
    public class EventManagerEmulator //: IEventManager
    {
        private List<Event> emulatorEvents; 

        public EventManagerEmulator()
        {
            emulatorEvents = new List<Event>();

            for (var index = 0; index < 10; index++)
            {
                var emulatorEvent = CreateEvent(index);
                emulatorEvents.Add(emulatorEvent);
            }
        }

        private Event CreateEvent(int num)
        {
            var emulatorEvent = new Event
                {
                    Id = num,
                    Text = "This is a test " + num + ".",
                    Time = DateTime.UtcNow.AddHours(-num),
                    UserId = 1,
                    InputType = 0,
                    RowStatus = 0,
                    EventType = 0
                };

            return emulatorEvent;
        }

        public Event[] GetEvents(EventSearchQuery eventSearchQuery)
        {
            var eventsDataSource = QueryEvents(eventSearchQuery);

            return eventsDataSource.ToArray();
        }

        public Event GetEvent(int id)
        {
            var result = emulatorEvents.FirstOrDefault(item => item.Id == id);

            return result;
        }

        public Event[] GetUserEvents(int userId, DateTime? lastModified = null)
        {
            var eventSearchQuery = new EventSearchQuery {UserId = userId, LastModified = lastModified};

            var eventsDataSource = QueryEvents(eventSearchQuery);

            return eventsDataSource.ToArray();
        }

        public void SaveEvents(Event[] events)
        {
            emulatorEvents.AddRange(events);
        }

        public void UpdateEvents(Event[] events)
        {
            foreach (var @event in events)
            {
                var element = emulatorEvents.Where(item => item.Id == @event.Id).FirstOrDefault();
                if (element != null)
                {
                    emulatorEvents.Remove(element);
                    emulatorEvents.Add(@event);
                }
            }
        }

        private IEnumerable<Event> QueryEvents(EventSearchQuery eventSearchQuery)
        {
            IEnumerable<Event> eventsDataSource = emulatorEvents;

            eventsDataSource = FilterUserId(eventSearchQuery, eventsDataSource);

            eventsDataSource = FilterRowStatus(eventSearchQuery, eventsDataSource);

            eventsDataSource = FilterTaskId(eventSearchQuery, eventsDataSource);

            eventsDataSource = FilterTime(eventSearchQuery, eventsDataSource);
            return eventsDataSource;
        }

        private IEnumerable<Event> FilterUserId(EventSearchQuery eventSearchQuery, IEnumerable<Event> events)
        {
            IEnumerable<Event> result = new List<Event>(events);
            if (eventSearchQuery.UserId.HasValue)
            {
                result = result.Where(item => item.UserId == eventSearchQuery.UserId.Value);
            }
            return result.ToArray();
        }

        private IEnumerable<Event> FilterRowStatus(EventSearchQuery eventSearchQuery, IEnumerable<Event> events)
        {
            IEnumerable<Event> result = new List<Event>(events);
            if (eventSearchQuery.RowStatus.HasValue)
            {
                result = result.Where(item => item.RowStatus == eventSearchQuery.RowStatus.Value) as List<Event>;
            }
            return result.ToArray();
        }

        private IEnumerable<Event> FilterTaskId(EventSearchQuery eventSearchQuery, IEnumerable<Event> events)
        {
            IEnumerable<Event> result = new List<Event>(events);
            if (eventSearchQuery.TaskId.HasValue)
            {
                result = result.Where(item => item.TaskId == eventSearchQuery.TaskId.Value) as List<Event>;
            }
            return result.ToArray();
        }

        private IEnumerable<Event> FilterTime(EventSearchQuery eventSearchQuery, IEnumerable<Event> events)
        {
            IEnumerable<Event> result = new List<Event>(events);
            if (eventSearchQuery.LastModified.HasValue)
            {
                result = result.Where(item => item.Time >= eventSearchQuery.LastModified.Value) as List<Event>;
            }
            return result.ToArray();
        }
    }
}