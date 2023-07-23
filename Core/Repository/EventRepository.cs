using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.IRepository;
using Core.Management;
using Core.Models;

namespace Core.Repository
{
    public class EventRepository : IEventRepository
    {
        public void InsertEvent(Event events) => EventManagement.Instance.AddNewEvent(events);

        public void DeleteEvent(Event events) => EventManagement.Instance.DeleteEvent(events);

        public List<Event> GetEvent() => EventManagement.Instance.GetEventList();

        public Event GetEventById(int id) => EventManagement.Instance.GetEventByID(id);


    }
}
