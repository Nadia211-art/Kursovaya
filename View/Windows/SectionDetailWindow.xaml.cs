using Kursovaya.Model;
using Kursovaya.View.Pages;
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
    /// Логика взаимодействия для SectionDetailWindow.xaml
    /// </summary>
    public partial class SectionDetailWindow : Window
    {

        private MySection _selectedSection; // Используем псевдоним

        // Конструктор принимает выбранную секцию
        public SectionDetailWindow(MySection selectedSection)
        {
            InitializeComponent();
            _selectedSection = selectedSection;
            LoadSectionDetails();
        }

        private void LoadSectionDetails()
        {
            if (_selectedSection != null)
            {
                // Название секции (используйте правильные имена свойств из вашей модели)
                TitleTbl.Text = _selectedSection.Title;
                //CoachTbl.Text = _selectedSection.;
                DescriptionTbl.Text = _selectedSection.Description;
                PhotoImg.Source = new BitmapImage(new Uri(_selectedSection.Photo, UriKind.RelativeOrAbsolute));
            }
        }
    }
}
