using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.IRepository;
using Core.Models;
using Core.Repository;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace ProjectQLBH.ViewModel
{
    public class RegisterViewModel : BaseViewModel
    {
        public ICommand RegisterCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand RepeatPasswordChangedCommand { get; set; }
        private string userName;
        public string UserName { get => userName; set { userName = value; OnPropertyChanged(); } }
        private string email;
        public string Email { get => email; set { email = value; OnPropertyChanged(); } }
        private string password;
        public string Password { get => password; set { password = value; OnPropertyChanged(); } }
        private string repeatPassword;
        public string RepeatPassword { get => repeatPassword; set { repeatPassword = value; OnPropertyChanged(); } }
        IUserRepository managerRepository;
        public RegisterViewModel()
        {
            managerRepository = new UserRepository();
            RegisterCommand = new ReplayCommand<Window>((p) => { return true; }, (p) => { Register(p); });
            PasswordChangedCommand = new ReplayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });
            RepeatPasswordChangedCommand = new ReplayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                RepeatPassword = p.Password;


            });


        }
        public void Register(Window p)
        {
            User user = null;
            if (p == null) return;
            if (RepeatPassword.Equals(Password))
            {
                user = managerRepository.GetUserByName(UserName);
                if (user != null)
                {
                    MessageBox.Show("UserName is exists!");

                }
                else
                {
                    user = managerRepository.GetUserByEmail(Email);
                    if (user != null)
                    {
                        MessageBox.Show("Email is exists!");

                    }
                    else
                    {
                        if (MessageBox.Show("Do you want register user?", "Register", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            user = new User()
                            {
                                UserName = UserName,
                                Password = Password,
                                Email = Email
                            };
                            managerRepository.Insert(user);
                            MessageBox.Show("Registe is successful!");
                            p.Close();
                            Login login = new Login();
                            login.Show();
                        }
                    }
                }
            }
            else
            {

                MessageBox.Show("Repeat password is not same Password");
            }
        }
    }
}
