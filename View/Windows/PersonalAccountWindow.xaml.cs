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
    /// Логика взаимодействия для PersonalAccountWindow.xaml
    /// </summary>
    public partial class PersonalAccountWindow : Window
    {
        public PersonalAccountWindow(User currentUser)
        {
            InitializeComponent();

            DataContext = App.currentUser;
            // Заполняем поля текущими данными
            FullNameTb.Text = currentUser.FullName;
            DateOfBirthDp.SelectedDate = currentUser.DateOfBirth;
            PhoneTb.Text = currentUser.Phone;
            EmailTb.Text = currentUser.Email;
        }
    }
}
