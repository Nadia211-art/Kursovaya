using Kursovaya.Model;
using Microsoft.Win32;
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

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            // Обновляем данные новости
            App.currentUser.FullName = FullNameTb.Text;
            App.currentUser.DateOfBirth = DateOfBirthDp.SelectedDate;
            App.currentUser.Phone = PhoneTb.Text;
            App.currentUser.Email = EmailTb.Text;
            //currentUser.Photo = PhotoImg.Photo;

            App.context.SaveChanges();

            MessageBox.Show("Данные профиля успешно изменены", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            DialogResult = true;
        }

        private void EditPhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //if (openFileDialog.ShowDialog() == true)
            //{
            //    PhotoImg. = openFileDialog.FileName;
            //}
        }
    }
}
