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
using DocumentFormat.OpenXml.Wordprocessing;

namespace ProjectQLBH.ViewModel
{
    public class CreateBillViewModel : BaseViewModel
    {
        public ICommand ListOrderCommand { get; set; }
        public ICommand EventManage { get; set; }

        IBillRepository billRepository { get; set; }
        IEventRepository eventRepository;

        private IEnumerable<Event> _listEvent;
        public IEnumerable<Event> ListEvent { get { return _listEvent; } set { _listEvent = value; OnPropertyChanged(); } }

        private string _ProductId;
        public string ProductId { get => _ProductId; set { _ProductId = value; OnPropertyChanged(); } }

        private string _CustomerName;
        public string CustomerName { get => _CustomerName; set { _CustomerName = value; OnPropertyChanged(); } }

        private string _Phone;
        public string Phone { get => _Phone; set { _Phone = value; OnPropertyChanged(); } }

        private string _address;
        public string address { get => _address; set { _address = value; OnPropertyChanged(); } }

        private int _Quanlity;
        public int Quanlity { get => _Quanlity; set { _Quanlity = value; OnPropertyChanged(); UpdatePrice(); } }


        private int _OldPrice;
        public int OldPrice { get => _OldPrice; set { _OldPrice = value; OnPropertyChanged(); } }

        private int _SellPrice;
        public int SellPrice { get => _SellPrice; set { _SellPrice = value; OnPropertyChanged(); } }

        private int _MoneyTaken;
        public int MoneyTaken { get => _MoneyTaken; set { _MoneyTaken = value; OnPropertyChanged(); UpdateMoney(); } }

        private int _editMoneyExchange;
        public int editMoneyExchange { get => _editMoneyExchange; set { _editMoneyExchange = value; OnPropertyChanged(); } }

        private int _editDeposit;
        public int editDeposit { get => _editDeposit; set { _editDeposit = value; OnPropertyChanged(); UpdateMoney(); } }


        private int _Shipcost;
        public int Shipcost { get => _Shipcost; set { _Shipcost = value; OnPropertyChanged(); UpdateMoney(); } }


        private int _editMoneyWillGet;
        public int editMoneyWillGet { get => _editMoneyWillGet; set { _editMoneyWillGet = value; OnPropertyChanged(); } }


        private bool _isDirectPayment = true;
        public bool IsDirectPayment
        {
            get { return _isDirectPayment; }
            set
            {
                _isDirectPayment = value;
                OnPropertyChanged();
            }
        }

        private bool _isDelivery = false;
        public bool IsDelivery
        {
            get { return _isDelivery; }
            set
            {
                _isDelivery = value;
                OnPropertyChanged();
            }
        }


        private string _NumberGet;
        public string NumberGet { get => _NumberGet; set { _NumberGet = value; OnPropertyChanged(); } }
        private Event _EventItem;
        public Event EventItem
        {
            get => _EventItem; set
            {
                _EventItem = value; OnPropertyChanged();

                if (_EventItem != null)
                {
                    NumberGet = _EventItem.BuyGetGet.ToString();
                }
            }
        }

        public ICommand CfCommand { get; set; }

        public ICommand ShowProductWindowCommand { get; set; }
        IProductRepository productRepository;
        private IEnumerable<Product> products;
        public IEnumerable<Product> Products { get { return products; } set { products = value; OnPropertyChanged(); } }

        private Product product;
        public Product Product
        {
            get => product; set
            {
                product = value; OnPropertyChanged();
                if (product != null)
                {
                    ProductId = product.ProductName;
                    Quanlity = 1;
                    OldPrice = (int)product.SellPrice;
                    SellPrice = (int)product.SellPrice;
                }
            }
        }
        public ICommand SearchCommand { get; set; }
        private string textSearch;
        public string TextSearch { get => textSearch; set { textSearch = value; OnPropertyChanged(); } }
        public CreateBillViewModel()
        {
            productRepository = new ProductRepository();
            Products = productRepository.GetProducts();
            eventRepository = new EventRepository();
            ListEvent = eventRepository.GetEvent();
            SearchCommand = new ReplayCommand<Object>((p) => { return true; }, (p) =>
            {
                Products = productRepository.GetProductsByName(TextSearch);
            });

            CfCommand = new ReplayCommand<object>((p) => { return true; }, (p) =>
            {   
                    var bill = new Bill()
                    {
                        UserId = 1,
                        Date = DateTime.Now,
                        Name = CustomerName,
                        Phone = Phone,
                        ProductId = Product.ProductId.ToString(),
                        Number = Quanlity,
                        OriginalPrice = OldPrice,
                        FinalPrice = SellPrice,
                        Event = EventItem.Name,
                        GoToShop = IsDirectPayment,
                        MoneyTaken = MoneyTaken,
                        MoneyExchange = editMoneyExchange,
                        Address = address,
                        Deposit = editDeposit,
                        Ship = Shipcost,
                        MoneyWillGet = editMoneyWillGet,
                        Status = "Chưa Hoàn Thành"
                    };
                    if (MessageBox.Show("Xác nhận đơn hàng sau khi đã giao Hàng Thành công ?", "Xác Nhận", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        billRepository.AddBill(bill);
                        //ListOrdersWindow listOrder = new ListOrdersWindow();
                        //listOrder.ShowDialog();
                    }
            });

        }

        private void UpdatePrice()
        {
            if (Product != null && EventItem != null)
            {
                if (Quanlity > 0)
                {
                    int PriceSell = (int)product.SellPrice;
                    int Buy = (int)EventItem.BuyGetBuy;
                    int Get = (int)EventItem.BuyGetGet;

                    OldPrice = (int)Product.SellPrice * Quanlity;
                    double sale = (double)(EventItem.Sale * 0.01);

                    if (Quanlity >= Buy)
                    {
                        SellPrice = (int)((PriceSell - (PriceSell * sale)) * (Quanlity - Get));

                    }
                    else
                    {
                        SellPrice = (int)((PriceSell - (PriceSell * sale)) * Quanlity);
                    }
                }


            }
        }

        private void UpdateMoney()
        {
            if (Product != null && EventItem != null)
            {

                if (IsDirectPayment)
                {
                    if (editDeposit > 0)
                    {
                        editDeposit = 0;
                        editMoneyWillGet = 0;
                        if (Shipcost > 0)
                        {
                            Shipcost = 0;
                        }
                    }
                    if (MoneyTaken > 0)
                    {
                        editMoneyExchange = SellPrice - MoneyTaken;
                    }
                }
                else if (IsDelivery)
                {
                    if (MoneyTaken > 0)
                    {
                        editMoneyExchange = 0;
                        MoneyTaken = 0;
                    }
                    if (editDeposit > 0)
                    {

                        editMoneyWillGet = SellPrice - editDeposit + Shipcost;
                    }
                }
            }
        }

    }
}
