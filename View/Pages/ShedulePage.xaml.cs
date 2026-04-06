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
    /// Логика взаимодействия для ShedulePage.xaml
    /// </summary>
    public partial class ShedulePage : Page
    {
        public ShedulePage()
        {
            InitializeComponent();
            LoadSchedule();
        }

        private void LoadSchedule()
        {
            try
            {
                // Загружаем расписание с сортировкой по дате и времени
                var schedule = App.context.Schedule
                    .OrderBy(s => s.Date)
                    .ThenBy(s => s.StartTime)
                    .ToList();

                SheduleDg.ItemsSource = schedule;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке расписания: {ex.Message}",
                              "Ошибка",
                              MessageBoxButton.OK,
                              MessageBoxImage.Error);
            }
        }

        private void SheduleDg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Здесь можно добавить логику при выборе занятия
            if (SheduleDg.SelectedItem != null)
            {
                // Например, подсветка выбранного элемента
            }
        }

        // Метод для обновления расписания (можно вызвать при необходимости)
        public void RefreshSchedule()
        {
            LoadSchedule();
        }
    }
}