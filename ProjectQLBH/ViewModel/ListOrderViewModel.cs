using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class ListOrderViewModel : BaseViewModel
    {

        IBillRepository billRepository;

        private IEnumerable<Bill> listbills;
        public IEnumerable<Bill> ListBills { get { return listbills; } set { listbills = value; OnPropertyChanged(); } }


        private string _address;
        public string address { get => _address; set { _address = value; OnPropertyChanged(); } }


        private long _editDeposit;
        public long editDeposit { get => _editDeposit; set { _editDeposit = value; OnPropertyChanged(); } }


        private long _Shipcost;
        public long Shipcost { get => _Shipcost; set { _Shipcost = value; OnPropertyChanged(); } }


        private long _editMoneyWillGet;
        public long editMoneyWillGet { get => _editMoneyWillGet; set { _editMoneyWillGet = value; OnPropertyChanged(); } }

        private string _Phone;
        public string Phone { get => _Phone; set { _Phone = value; OnPropertyChanged(); } }


        private int _Quanlity;
        public int Quanlity { get => _Quanlity; set { _Quanlity = value; OnPropertyChanged(); } }

        private long _Give;
        public long Give { get => _Give; set { _Give = value; OnPropertyChanged(); } }

        private long _OldPrice;
        public long OldPrice { get => _OldPrice; set { _OldPrice = value; OnPropertyChanged(); } }

        private long _NewPrice;
        public long NewPrice { get => _NewPrice; set { _NewPrice = value; OnPropertyChanged(); } }

        private string _event;
        public string disevent { get => _event; set { _event = value; OnPropertyChanged(); } }

        private bool _btnstatus;
        public bool btnstatus { get => _btnstatus; set { _btnstatus = value; OnPropertyChanged(); } }

        public ICommand Donecommand { get; set; }
        public ICommand Viewcommand { get; set; }
        public ICommand Cancelcommand { get; set; }
        public ICommand SelectedItemChangedCommand { get; set; }



        private Bill _SelectedItem;

        public Bill SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    address = SelectedItem.Address;
                    editDeposit = (long)SelectedItem.Deposit;
                    editMoneyWillGet = (long)SelectedItem.MoneyWillGet;
                    Phone = SelectedItem.Phone;
                    Quanlity = SelectedItem.Number;
                    Give = SelectedItem.NumberGiven;
                    OldPrice = SelectedItem.OriginalPrice;
                    NewPrice = SelectedItem.FinalPrice;
                    disevent = SelectedItem.Event;
                    Shipcost = (long)SelectedItem.Ship;

                    //update btnstatus
                    btnstatus = false;
                    if (SelectedItem.Status == "Chưa hoàn thành")
                    {
                        btnstatus = true;
                    }

                }
            }
        }

        private ObservableCollection<string> _comboItems;
        public ObservableCollection<string> ComboItems
        {
            get { return _comboItems; }
            set
            {
                _comboItems = value;
                OnPropertyChanged("ComboItems");
            }
        }
        private string _selectedStatus;
        public string SelectedStatus
        {
            get => _selectedStatus;
            set
            {
                _selectedStatus = value;
                OnPropertyChanged("SelectedStatus");
            }
        }
        public ListOrderViewModel()
        {
            billRepository = new BillRepository();
            ListBills = billRepository.GetBill();
            ComboItems = new ObservableCollection<string>() { "Tất cả Hóa Đơn", "Xem Đơn Đã Hoành Thành", "Xem Đơn Đã Hủy", "Xem Đơn Chưa Hoàn Thành" };


            Donecommand = new ReplayCommand<object>(
                (p) =>
                {
                    if (SelectedItem == null)
                    {
                        return false;
                    }
                    return true;
                },
                (p) =>
                {
                    var update = billRepository.GetBillById(SelectedItem.BillId);
                    if (update != null)
                    {
                        update.Status = "Đã Hoàn Thành";
                        if (MessageBox.Show("Xác Nhận Đã Hoàn Thành Đơn Hàng?", "Xác Nhận", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            billRepository.UpdateBill(update);
                            ListBills = billRepository.GetBill();
                        }
                    }
                });

            Cancelcommand = new ReplayCommand<object>(
            (p) =>
            {
                if (SelectedItem == null)
                {
                    return false;
                }
                return true;
            },
            (p) =>
            {
                var update = billRepository.GetBillById(SelectedItem.BillId);
                if (update != null)
                {
                    update.Status = "Đã Hủy";
                    if (MessageBox.Show("Xác Nhận Hủy Đơn Hàng đang Giao?", "Hủy Đơn", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        billRepository.UpdateBill(update);
                        ListBills = billRepository.GetBill();
                    }
                }
            });

            SelectedItemChangedCommand = new ReplayCommand<object>(
                (p) =>
                {
                    if (SelectedStatus == null || billRepository == null)
                    {
                        return false;
                    }
                    return true;
                },
                (p) =>
                {
                    ListBills = billRepository.GetListBillByStatusOrderByDate(SelectedStatus.ToString());
                });
        }

    }
}
