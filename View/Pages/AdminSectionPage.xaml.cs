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
using MySection = Kursovaya.Model.Section;
namespace Kursovaya.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminSectionPage.xaml
    /// </summary>
    public partial class AdminSectionPage : Page
    {
        public AdminSectionPage()
        {
            InitializeComponent();
            SectionLb.ItemsSource=App.context.Section.ToList();
        }

        private void SectionLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MySection selectedSection = SectionLb.SelectedItem as MySection;
        }

        private void AddSectionBtn_Click(object sender, RoutedEventArgs e)
        {
            AddSectionWindow addSectionWindow = new AddSectionWindow();
            if(addSectionWindow.ShowDialog()==true)
            {
                SectionLb.ItemsSource=App.context.Section.ToList();
            }
        }

        private void EditSectionBtn_Click(object sender, RoutedEventArgs e)
        {
            
            if (SectionLb.SelectedItem != null)
            {
                MySection selectedSection = SectionLb.SelectedItem as MySection;
                EditSectionWindow editSectionWindow = new EditSectionWindow(selectedSection);
                if (editSectionWindow.ShowDialog() == true)
                {
                    App.context.SaveChanges();
                    SectionLb.ItemsSource = App.context.Section.ToList();
                }
            }
        }

        private void DeleteSectionBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SectionLb.SelectedItem != null)
            {
                MySection _selectedSection= SectionLb.SelectedItem as MySection;//переменная для хранения выбранного товара
                MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить секцию?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    //Удаляем запись
                    App.context.Section.Remove(_selectedSection);
                    MessageBox.Show("Секция удалена", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    App.context.SaveChanges();
                    SectionLb.ItemsSource = App.context.Section.ToList();
                }
            }
        }
    }
}
