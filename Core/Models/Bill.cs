using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Bill
    {
        public int BillId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; } = null!;
        public string? Phone { get; set; }
        public string ProductId { get; set; } = null!;
        public int Number { get; set; }
        public int NumberGiven { get; set; }
        public long OriginalPrice { get; set; }
        public long FinalPrice { get; set; }
        public string? Event { get; set; }
        public bool GoToShop { get; set; }
        public long? MoneyTaken { get; set; }
        public long? MoneyExchange { get; set; }
        public string? Address { get; set; }
        public long? Deposit { get; set; }
        public long? Ship { get; set; }
        public long? MoneyWillGet { get; set; }
        public string Status { get; set; } = null!;
    }
}
