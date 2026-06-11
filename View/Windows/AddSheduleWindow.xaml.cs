using Kursovaya.Model;
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
using System.Data.Entity;
using System.Text.RegularExpressions;

namespace Kursovaya.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddSheduleWindow.xaml
    /// </summary>
    public partial class AddSheduleWindow : Window
    {
        public AddSheduleWindow()
        {
            InitializeComponent();

            DatePicker.SelectedDate = DateTime.Now;

            
            SectionCmb.SelectedValuePath = "IdSection";
            SectionCmb.DisplayMemberPath = "Title";
            SectionCmb.ItemsSource = App.context.Section.ToList();
            LoadUsersByRole();
        }

        private void LoadUsersByRole()
        {
            try
            {
                var users = App.context.User
                    .Include("Role")
                    .Where(u => u.Role.Role1 == "Тренер")
                    .OrderBy(u => u.FullName)  // Сортировка по имени
                    .ToList();

                CoachCmb.SelectedValuePath = "IdUser";
                CoachCmb.DisplayMemberPath = "FullName";
                CoachCmb.ItemsSource = users;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки пользователей: {ex.Message}");
            }
        }
        private bool IsValidTimeFormat(string time)
        {
            return Regex.IsMatch(time, @"^([01]\d|2[0-3]):([0-5]\d)$");
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

            if (DatePicker.SelectedDate == null ||
                string.IsNullOrWhiteSpace(StartTimeTb.Text) ||
                string.IsNullOrWhiteSpace(EndTimeTb.Text) ||
                CoachCmb.SelectedItem == null ||
                SectionCmb.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            // Проверка формата (только ЧЧ:ММ)
            if (!IsValidTimeFormat(StartTimeTb.Text))
            {
                MessageBox.Show("Неверный формат времени начала! Используйте ЧЧ:ММ (например: 14:30)",
                                "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!IsValidTimeFormat(EndTimeTb.Text))
            {
                MessageBox.Show("Неверный формат времени конца! Используйте ЧЧ:ММ (например: 17:00)",
                                "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Преобразуем в TimeSpan
            TimeSpan startTime = TimeSpan.Parse(StartTimeTb.Text);
            TimeSpan endTime = TimeSpan.Parse(EndTimeTb.Text);

            // Проверяем, что время начала меньше времени конца
            if (startTime >= endTime)
            {
                MessageBox.Show("Время начала должно быть меньше времени конца!",
                                "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        
       

        Schedule schedule = new Schedule
            {
                Date = (DateTime)DatePicker.SelectedDate,
                StartTime = startTime,
                EndTime = endTime,
                Coach = ((User)CoachCmb.SelectedItem).IdUser,
                IdSection = ((Model.Section)SectionCmb.SelectedItem).IdSection
            };

            App.context.Schedule.Add(schedule);
            App.context.SaveChanges();

            MessageBox.Show("Занятие успешно добавлено.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            DialogResult = true;

        }
    }
}
