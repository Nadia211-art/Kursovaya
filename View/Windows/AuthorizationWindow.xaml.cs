using Kursovaya.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Kursovaya.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LoginTb.Text) || string.IsNullOrEmpty(PasswordPb.Password)) 
            {
                MessageBox.Show("Заполните все поля!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);

               
            }
            else
            {
                App.currentUser = App.context.User.FirstOrDefault(u => u.Email == LoginTb.Text && u.Password == PasswordPb.Password);

                if (App.currentUser != null)
                {
                    MessageBox.Show("Вы успешно авторизовались!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    if (App.currentUser.IdRole == 1)
                    {
                        AdminWindow administratorWindow = new AdminWindow();
                        administratorWindow.Show();


                        Close();
                    }
                    if (App.currentUser.IdRole == 2)
                    {
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();

                        Close();
                    }

                }
                else
                {
                    MessageBox.Show("Вы ввели неверный логин или пароль. Пожалуйста проверьте еще раз введенные данные!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
         
        }
        private void RegictrationBtn_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
        }
    }
}
