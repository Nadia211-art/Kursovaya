using Kursovaya.Model;
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
using static System.Collections.Specialized.BitVector32;

namespace Kursovaya.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminNewsPage.xaml
    /// </summary>
    public partial class AdminNewsPage : Page
    {
        public AdminNewsPage()
        {
            InitializeComponent();
            NewsLb.ItemsSource = App.context.News.ToList();
        }

        private void NewsLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            News selectedNews = NewsLb.SelectedItem as News;

        }

   
      

        private void AddNewsBtn_Click(object sender, RoutedEventArgs e)
        {
            AddNewsWindow addNewsWindow = new AddNewsWindow();
            if (addNewsWindow.ShowDialog() == true)
            {
              
                NewsLb.ItemsSource = App.context.News.ToList();
            }
        }
        

        private void EditNewsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NewsLb.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите новость для редактирования.", "Внимание");
                return;
            }

            var selectedNews = NewsLb.SelectedItem as News;
            var editWindow = new EditNewsWindow(selectedNews);
            if (editWindow.ShowDialog() == true)
            {
                App.context.SaveChanges();
                NewsLb.ItemsSource = App.context.News.ToList();
            }

        }

        private void DeleteNewsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NewsLb.SelectedItem != null)
            {
                News selectedNews = NewsLb.SelectedItem as News;//переменная для хранения выбранного товара
                MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить новость?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    //Удаляем запись
                    News news = App.context.News.Remove(selectedNews);
                    MessageBox.Show("Новость удалена", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    App.context.SaveChanges();
                    NewsLb.ItemsSource = App.context.News.ToList();
                }
            }
        }
    }
}
