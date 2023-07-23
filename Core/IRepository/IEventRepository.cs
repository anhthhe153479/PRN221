using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.IRepository
{
    public interface IEventRepository
    {

        List<Event> GetEvent();
        void InsertEvent(Event events);
        void DeleteEvent(Event events);
        Event GetEventById(int id);

    }
}
