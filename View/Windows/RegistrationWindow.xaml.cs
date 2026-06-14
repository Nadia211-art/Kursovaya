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
using static System.Collections.Specialized.BitVector32;

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

            GroupCmb.SelectedValuePath = "IdGroup";
            GroupCmb.DisplayMemberPath = "Name";
            GroupCmb.ItemsSource = App.context.Group.ToList();
        }



        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            string phone = PhoneTb.Text;
            string password = PasswordPb.Password;
            string password1 = RepeatPasswordPb.Password;
            if (string.IsNullOrEmpty(FullnameTb.Text) || string.IsNullOrEmpty(PhoneTb.Text) || string.IsNullOrEmpty(EmailTb.Text) || string.IsNullOrEmpty(PasswordPb.Password) || string.IsNullOrEmpty(RepeatPasswordPb.Password)||GroupCmb.SelectedItem==null)
            {
                MessageBox.Show("Заполните все поля!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;


            }
            if(PasswordPb.Password!=RepeatPasswordPb.Password )
            {
                MessageBox.Show("Пароли не совпадают!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Проверка длины
            if (password.Length < 8)
            {
                MessageBox.Show("Символов должно быть больше 8!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (password.Length > 16)
            {
                MessageBox.Show("Пароль не должен превышать 20 символов", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // Проверка наличия цифр
            if (!password.Any(char.IsDigit))
            {
                MessageBox.Show("Пароль должен содержать хотя бы одну цифру", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
            }
                
            if (phone.Length < 11&& phone.Length!=11 && phone[0] != '8' && phone[1] != '9')
            {
                // Все цифры проверим через TryParse или All
                bool isDigitsOnly = phone.All(c => char.IsDigit(c));

                MessageBox.Show("Неверный формат номера телефона! Формат: 89#########", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            string email = EmailTb.Text;
            if (!email.EndsWith("@mail.ru") && !email.EndsWith("@gmail.com") && !email.EndsWith("@icloud.com") && !email.EndsWith("@yandex.ru"))
            {
                MessageBox.Show("Email должен оканчиваться на @mail.ru,yandex.ru, icloud.com или @gmail.com",
                                "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
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
                    IdGroup= ((Group)GroupCmb.SelectedItem).IdGroup

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
