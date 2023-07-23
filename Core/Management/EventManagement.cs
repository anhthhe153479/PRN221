using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Management
{
    public class EventManagement
    {
        private static EventManagement instance;
        private static readonly object instanceLock = new object();
        private EventManagement() { }
        public static EventManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new EventManagement();
                    }
                    return instance;
                }

            }
        }



        public List<Event> GetEventList()
        {
            List<Event> events;
            try
            {
                var managerDB = new Management_System_ProjectContext();
                events = managerDB.Events.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return events;
        }
        public Event GetEventByID(int eventId)
        {
            Event events = null;
            try
            {
                var managerDB = new Management_System_ProjectContext();
                events = managerDB.Events.SingleOrDefault(events => events.EventId == eventId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return events;
        }
        public void AddNewEvent(Event events)
        {
            if (events != null)
            {
                try
                {
                    Event _event = GetEventByID(events.EventId);
                    if (_event == null)
                    {
                        var managerDB = new Management_System_ProjectContext();
                        managerDB.Events.Add(events);
                        managerDB.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("The Event is already exist");

                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public void DeleteEvent(Event events)
        {
            try
            {
                Event _event = GetEventByID(events.EventId);
                if (_event != null)
                {
                    var managerDB = new Management_System_ProjectContext();
                    managerDB.Events.Remove(_event);
                    managerDB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
