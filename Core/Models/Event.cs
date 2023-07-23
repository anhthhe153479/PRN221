using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Event
    {
        public int EventId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public int? Sale { get; set; }
        public int? BuyGetBuy { get; set; }
        public int? BuyGetGet { get; set; }
    }
}
