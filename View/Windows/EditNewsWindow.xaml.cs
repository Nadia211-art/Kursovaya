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
    /// Логика взаимодействия для EditNewsWindow.xaml
    /// </summary>
    public partial class EditNewsWindow : Window
    {
        private News selectedNews;
        public EditNewsWindow(News selectedNews)
        {

            InitializeComponent();

            this.selectedNews = selectedNews;
            DataContext = selectedNews;
            // Заполняем поля текущими данными
            TitleTb.Text = selectedNews.Title;
            ContentTb.Text = selectedNews.NewContent;
            PublishDatePicker.SelectedDate = selectedNews.Date;
            PhotoTb.Text = selectedNews.Photo;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            // Обновляем данные новости
            selectedNews.Title = TitleTb.Text;
            selectedNews.NewContent = ContentTb.Text;
            selectedNews.Date = PublishDatePicker.SelectedDate ?? DateTime.Now;
            selectedNews.Photo = PhotoTb.Text;
            App.context.SaveChanges();

            MessageBox.Show("Новость успешно изменена", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
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
