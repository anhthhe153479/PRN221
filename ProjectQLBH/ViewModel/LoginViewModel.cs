using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.IRepository;
using Core.Repository;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace ProjectQLBH.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public bool IsLogin { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand LoadRegisterWindown { get; set; }
        private string userName;
        public string UserName { get => userName; set { userName = value; OnPropertyChanged(); } }
        private string password;
        public string Password { get => password; set { password = value; OnPropertyChanged(); } }
        IUserRepository managerRepository;

        public LoginViewModel()
        {
            managerRepository = new UserRepository();
            IsLogin = false;
            LoginCommand = new ReplayCommand<Window>((p) => { return true; }, (p) => { Login(p); });
            CloseCommand = new ReplayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });

            PasswordChangedCommand = new ReplayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });
            LoadRegisterWindown = new ReplayCommand<Window>((p) => { return true; }, (p) =>
            {
                p.Close();
                SignUp signUp = new SignUp();
                signUp.ShowDialog();

            });
        }
        public void Login(Window p)
        {

            if (p == null) return;

            var user = managerRepository.GetUserByName(UserName);
            if (user != null)
            {
                if (user.Password.Equals(Password))
                {
                    IsLogin = true;
                    p.Close();

                }
                else
                {
                    IsLogin = false;
                    MessageBox.Show("Password is wrong!");

                }
            }
            else
            {
                IsLogin = false;
                MessageBox.Show("Username is wrong!");


            }
        }
    }
}
