using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.IRepository;
using Core.Models;
using Core.Repository;
using System.Windows.Input;
using System.Windows;

namespace ProjectQLBH.ViewModel
{
    public class EventViewModel : BaseViewModel
    {

        IEventRepository eventRepository;

        private IEnumerable<Event> _listEvent;
        public IEnumerable<Event> ListEvent { get { return _listEvent; } set { _listEvent = value; OnPropertyChanged(); } }


        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public EventViewModel()
        {
            eventRepository = new EventRepository();
            ListEvent = eventRepository.GetEvent();


            AddCommand = new ReplayCommand<object>((p) => { return true; }, (p) =>
            {
                var events = new Event()
                {

                    //EventId = EventItem.EventId,
                    Name = EventName,
                    Sale = Sale,
                    BuyGetBuy = EventBuy,
                    BuyGetGet = EventGet,
                    DateBegin = BeginDate,
                    DateEnd = DateEnd,
                };

                if (MessageBox.Show("Do you want insert Event?", "Insert", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    eventRepository.InsertEvent(events);
                    ListEvent = eventRepository.GetEvent();
                }

            });

            DeleteCommand = new ReplayCommand<object>(
                (p) =>
                {

                    if (_EventItem == null)
                    {
                        return false;
                    }
                    var displayEvent = eventRepository.GetEventById(_EventItem.EventId);
                    if (displayEvent == null)
                    {
                        return false;
                    }
                    return true;
                },

                (p) =>
                {
                    var delete = eventRepository.GetEventById(_EventItem.EventId);
                    if (MessageBox.Show("Do you want delete event?", "Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        eventRepository.DeleteEvent(delete);
                        ListEvent = eventRepository.GetEvent();
                    }


                });
        }

        private Event _EventItem;
        public Event EventItem
        {
            get => _EventItem; set
            {
                _EventItem = value; OnPropertyChanged();
                if (_EventItem != null)
                {
                    EventName = _EventItem.Name;
                    Sale = (int)_EventItem.Sale;
                    EventBuy = (int)_EventItem.BuyGetBuy;
                    EventGet = (int)_EventItem.BuyGetGet;
                    BeginDate = _EventItem.DateBegin;
                    DateEnd = _EventItem.DateEnd;
                }
            }
        }

        private string _EventName;
        public string EventName { get => _EventName; set { _EventName = value; OnPropertyChanged(); } }

        private int _Sale;
        public int Sale { get => _Sale; set { _Sale = value; OnPropertyChanged(); } }

        private int _EventBuy;
        public int EventBuy { get => _EventBuy; set { _EventBuy = value; OnPropertyChanged(); } }

        private int _EventGet;
        public int EventGet { get => _EventGet; set { _EventGet = value; OnPropertyChanged(); } }

        private DateTime _BeginDate;
        public DateTime BeginDate { get => _BeginDate; set { _BeginDate = value; OnPropertyChanged(); } }


        private DateTime _DateEnd;
        public DateTime DateEnd { get => _DateEnd; set { _DateEnd = value; OnPropertyChanged(); } }

    }
}
