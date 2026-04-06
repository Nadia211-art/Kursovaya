using Kursovaya.Classes;
using Kursovaya.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using MyApplication = Kursovaya.Model.Application;

namespace Kursovaya.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для NewApplicationWindow.xaml
    /// </summary>
    public partial class NewApplicationWindow : Window
    {
        private Kursovaya.Model.Section _selectedSection;
        public NewApplicationWindow()
        {
            InitializeComponent();
            // Устанавливаем DataContext для привязки данных
            this.DataContext = App.currentUser;
            // Альтернативный способ установки текста напрямую
            if (App.currentUser != null)
            {
                FullnameTb.Text = App.currentUser.FullName;
            }
            FullnameTb.DataContext = App.currentUser.FullName;
            _selectedSection = SessionData.SelectedSection;
            SelectedSectionTbl.Text = SessionData.SelectedSection.Title;

        }

        private void RecordBtn_Click(object sender, RoutedEventArgs e)
        {
           
            
                MyApplication application= new MyApplication
                {
                    IdStudent = App.currentUser.IdUser,
                    IdSection = SessionData.SelectedSection.IdSection,
                    ApplicationDate = DateTime.Now,
                    Status = "Новая" // или любой другой статус по умолчанию
                };
                
                App.context.Application.Add(application);
                App.context.SaveChanges();

           
            MessageBox.Show("Заявка успешно отправлена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            
           
            // Возврат к окну выбора секции или закрытие
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            SelectSectionWindow selectSectionWindow = new SelectSectionWindow();
            selectSectionWindow.Show();
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Дополнительная проверка при загрузке окна
            if (App.currentUser != null && string.IsNullOrEmpty(FullnameTb.Text))
            {
                FullnameTb.Text = App.currentUser.FullName;
            }
        }
    }
}
