using Kursovaya.Model;
using Kursovaya.View.Pages;
using Kursovaya.View.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kursovaya
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private User currentUser;

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new MainPage());
        }

        private void MainBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MainPage());
        }

        private void SectionBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SectionPage());
        }

        private void SheduleBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ShedulePage());
        }


        private void NewsBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new NewPage());
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authorizationWindow= new AuthorizationWindow();
            authorizationWindow.Show();
            Close();
        }

        private void PersonalAccountBtn_Click(object sender, RoutedEventArgs e)
        {
          if (App.currentUser != null)
{
    PersonalAccountWindow window = new PersonalAccountWindow(App.currentUser);
    window.Show();
}
else
{
    MessageBox.Show("Пользователь не авторизован");
    // перенаправить на окно входа
}
        }
    }
}
