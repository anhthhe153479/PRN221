using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.IRepository;
using Core.Models;
using System.Windows.Input;
using System.Windows;

namespace ProjectQLBH.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand LoadedWindownCommand { get; set; }
        public ICommand LoadProductWindowCommand { get; set; }
        public ICommand LoadCategoryWindowCommand { get; set; }
        public ICommand LoadBillWindowCommand { get; set; }
        public ICommand CreateBillCommand { get; set; }

        IProductRepository productRepository;
        private IEnumerable<Product> products;
        public IEnumerable<Product> Products { get { return products; } set { products = value; OnPropertyChanged(); } }

        public bool IsLoad = false;
        public MainViewModel()
        {
            LoadedWindownCommand = new ReplayCommand<Window>((p) => { return true; }, (p) =>
            {
                IsLoad = true;
                if (p == null) return;
                p.Hide();
                Login login = new Login();
                login.Show();
                if (login == null) return;
                var loginVM = login.DataContext as LoginViewModel;

                if (loginVM.IsLogin)
                {

                    p.Show();
                }
                else p.Close();
            });
        }
    }
}
