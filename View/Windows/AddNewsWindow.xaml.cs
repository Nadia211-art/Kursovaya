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
using static System.Collections.Specialized.BitVector32;

namespace Kursovaya.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddNewsWindow.xaml
    /// </summary>
    public partial class AddNewsWindow : Window
    {
        public AddNewsWindow()
        {
            InitializeComponent();
            PublishDatePicker.SelectedDate = DateTime.Now;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            // Создаем новую новость
            News news = new News
            {
                Title = TitleTb.Text,
                NewContent = ContentTb.Text,
                Date = PublishDatePicker.SelectedDate ?? DateTime.Now,
                Photo = PhotoTb.Text
            };

            App.context.News.Add(news);
            App.context.SaveChanges();

            MessageBox.Show("Новость успешно добавлена", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            DialogResult = true;
        }

        private void LoadFromPCBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                PhotoTb.Text = openFileDialog.FileName;
            }
        }
    }
}
