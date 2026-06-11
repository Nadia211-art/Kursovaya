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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

      

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(FullnameTb.Text) || string.IsNullOrEmpty(PhoneTb.Text) || string.IsNullOrEmpty(EmailTb.Text) || string.IsNullOrEmpty(PasswordPb.Password) || string.IsNullOrEmpty(RepeatPasswordPb.Password))
            {
                MessageBox.Show("Заполните все поля!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);


            }
            if(PasswordPb.Password!=RepeatPasswordPb.Password)
            {
                MessageBox.Show("Пароли не совпадают!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            string phone = PhoneTb.Text;

            if (phone.Length != 11 && phone[0] != '8' && phone[1] != '9')
            {
                //// Все цифры проверим через TryParse или All
                //bool isDigitsOnly = phone.All(c => char.IsDigit(c));

                MessageBox.Show("Неверный формат номера телефона!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            string email = EmailTb.Text;
            if (!email.EndsWith("@mail.ru") && !email.EndsWith("@gmail.com"))
            {
                MessageBox.Show("Email должен оканчиваться на @mail.ru или @gmail.com",
                                "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {

                User user = new User()
                {
                    FullName = FullnameTb.Text,
                    Phone = PhoneTb.Text,
                    Email = EmailTb.Text,
                    Password = PasswordPb.Password,
                    IdRole = 2,

                };

                App.context.User.Add(user);
                App.context.SaveChanges();
                MessageBox.Show("Вы успешно зарегистрированы", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

                AuthorizationWindow authorizationWindow = new AuthorizationWindow();
                authorizationWindow.Show();
                Close();
            }
        }

    }
}
