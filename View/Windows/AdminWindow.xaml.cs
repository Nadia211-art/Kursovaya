using Kursovaya.Model;
using Kursovaya.View.Pages;
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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            
        }

        private void ApplicationBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AdminApplicationPage());
        }

        private void SectionBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AdminSectionPage());
        }

        private void SheduleBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AdminShedulePage());
        }

        private void NewsBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AdminNewsPage());
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
            Close();
        }

        private void PersonalAccountBtn_Click(object sender, RoutedEventArgs e)
        {
            if (App.currentUser != null)
            {
                PersonalAccountWindow personalAccountWindow = new PersonalAccountWindow(App.currentUser);
                personalAccountWindow.Show();
            }
            else
            {
                MessageBox.Show("Пользователь не авторизован");

            }
        }

        private void PersonalAccountBtn_Click_1(object sender, RoutedEventArgs e)
        {
            if (App.currentUser != null)
            {
                PersonalAccountWindow personalAccountWindow = new PersonalAccountWindow(App.currentUser);
                personalAccountWindow.Show();
            }
            else
            {
                MessageBox.Show("Пользователь не авторизован");

            }
        }
    }
}
