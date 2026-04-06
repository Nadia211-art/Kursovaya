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

namespace Kursovaya.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для SectionPage.xaml
    /// </summary>
    public partial class SectionPage : Page
    {
        public SectionPage()
        {
            InitializeComponent();
            SectionLb.ItemsSource = App.context.Section.ToList();
        }

        private void SectionLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Section selectedSection = SectionLb.SelectedItem as Section;
        }
    }
}
