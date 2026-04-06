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
    /// Логика взаимодействия для EditSectionWindow.xaml
    /// </summary>
    public partial class EditSectionWindow : Window
    {
        private Model.Section selectedSection;

        public EditSectionWindow()
        {
            InitializeComponent();
        }

        public EditSectionWindow(Model.Section selectedSection)
        {
            InitializeComponent();
            this.selectedSection = selectedSection;
            DataContext = selectedSection;
        }

        private void LoadFromPCBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                selectedSection.Photo = openFileDialog.FileName;
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            App.context.SaveChanges();

            MessageBox.Show("Секция успешно отредактирована", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            DialogResult = true;
        }
    }
}
