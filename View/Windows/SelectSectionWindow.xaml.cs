using Kursovaya.Classes;
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
    /// Логика взаимодействия для SelectSectionWindow.xaml
    /// </summary>
    public partial class SelectSectionWindow : Window
    {
        public SelectSectionWindow()
        {
            InitializeComponent();
            SectionLb.ItemsSource = App.context.Section.ToList();
        }

        private void SectionLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SectionLb.SelectedItem is Kursovaya.Model.Section selectedSection)
            {
                SessionData.SelectedSection = selectedSection;
                NewApplicationWindow newApplicationWindow = new NewApplicationWindow();
                newApplicationWindow.Show();
                this.Close();
            }
        }
    }
}
