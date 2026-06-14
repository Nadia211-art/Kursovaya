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
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using static System.Collections.Specialized.BitVector32;

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
            GroupCmb.SelectedValuePath = "IdGroup";
            GroupCmb.DisplayMemberPath = "Name";
            GroupCmb.ItemsSource = App.context.Group.ToList();
            DataContext = App.currentUser;
            // Заполняем поля текущими данными
            FullNameTb.Text = currentUser.FullName;
            DateOfBirthDp.SelectedDate = currentUser.DateOfBirth;
            PhoneTb.Text = currentUser.Phone;
            EmailTb.Text = currentUser.Email;
            PhotoTb.Text=currentUser.Photo;
            GroupCmb.Text = currentUser.Group.Name;
            if (!string.IsNullOrEmpty(currentUser.Photo) && File.Exists(currentUser.Photo))
            {
                LoadImage(currentUser.Photo);
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
          
            App.currentUser.FullName = FullNameTb.Text;
            App.currentUser.DateOfBirth = DateOfBirthDp.SelectedDate;
            App.currentUser.Phone = PhoneTb.Text;
            App.currentUser.Email = EmailTb.Text;
            App.currentUser.Photo = PhotoTb.Text;
            App.currentUser.IdGroup = ((Group)GroupCmb.SelectedItem).IdGroup;


            MessageBox.Show("Данные профиля успешно изменены", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            App.context.SaveChanges();
           
            
        }

        private void EditPhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                openFileDialog.Filter = "Изображения|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Все файлы|*.*";
                PhotoTb.Text = openFileDialog.FileName;
                string filePath = openFileDialog.FileName;

                // Загружаем изображение в Image控件
                LoadImage(filePath);
            }

          
        }
        private void LoadImage(string filePath)
        {
            try
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(filePath);
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
                PhotoImg.Source = bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки изображения: {ex.Message}",
                                "Ошибка",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }

    }
}
