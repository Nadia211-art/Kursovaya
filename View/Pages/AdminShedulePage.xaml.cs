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

namespace Kursovaya.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminShedulePage.xaml
    /// </summary>
    public partial class AdminShedulePage : Page
    {
        public AdminShedulePage()
        {
            InitializeComponent();
            LoadSchedule();
        }
        private void LoadSchedule()
        {
            try
            {
                // Загружаем расписание с сортировкой
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
        private void AddShedule_Click(object sender, RoutedEventArgs e)
        {
            // Создаем окно для добавления занятия (предположим, что у вас есть такое окно)
            AddSheduleWindow addWindow = new AddSheduleWindow();
            if (addWindow.ShowDialog() == true)
            {
                // После закрытия окна, перезагружаем расписание
                LoadSchedule();
            }
        }

        

        private void SheduleDg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void DeleteShedule_Click(object sender, RoutedEventArgs e)
        {
            var selectedSchedule = SheduleDg.SelectedItem as Schedule; // замените на вашу модель
            if (selectedSchedule == null)
            {
                MessageBox.Show("Пожалуйста, выберите занятие для удаления.", "Удаление", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var result = MessageBox.Show($"Вы уверены, что хотите удалить занятие по {selectedSchedule.Date:dd.MM.yyyy} в {selectedSchedule.StartTime}?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    // Удалите из контекста
                    var scheduleToRemove = App.context.Schedule.Find(selectedSchedule.IdShedule); // предположим, есть Id
                    if (scheduleToRemove != null)
                    {
                        App.context.Schedule.Remove(scheduleToRemove);
                        App.context.SaveChanges();
                        LoadSchedule();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
