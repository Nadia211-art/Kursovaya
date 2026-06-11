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
using MySection = Kursovaya.Model.Section;
namespace Kursovaya.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddSectionWindow.xaml
    /// </summary>
    public partial class AddSectionWindow : Window
    {
        private MySection selectedSection;
        public AddSectionWindow()
        {
            InitializeComponent();
        }
        public AddSectionWindow(MySection selectedSection)
        {
            InitializeComponent();
            this.selectedSection = new MySection();
            DataContext = this.selectedSection;
        }


      

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(NameTb.Text) && !string.IsNullOrEmpty(PhotoTb.Text))
            {
                MySection newSection = new MySection()
                {
                    Title = NameTb.Text,
                    Photo = PhotoTb.Text,
                    Description= DescriptionTb.Text
                };

                MySection section = App.context.Section.Add(newSection);
                App.context.SaveChanges();

                MessageBox.Show("Секция успешно добавлена", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
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
