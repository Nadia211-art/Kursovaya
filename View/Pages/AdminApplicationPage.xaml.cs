using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Kursovaya.Model;
using MyApplication = Kursovaya.Model.Application;
namespace Kursovaya.View.Pages
{
    public partial class AdminApplicationPage : Page
    {
        private List<MyApplication> _allApplications;
        private MyApplication _selectedApplication;

        public AdminApplicationPage()
        {
            InitializeComponent();
            LoadApplications();
        }

        private void LoadApplications()
        {
            try
            {
                _allApplications = App.context.Application
                    .Include("User")
                    .Include("Section")
                    .OrderByDescending(a => a.ApplicationDate)
                    .ToList();

                ApplicationLv.ItemsSource = _allApplications;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void FilterApplications(string status)
        {
            if (_allApplications == null) return;

            if (status == "All")
            {
                ApplicationLv.ItemsSource = _allApplications;
            }
            else
            {
                ApplicationLv.ItemsSource = _allApplications
                    .Where(a => a.Status == status)
                    .ToList();
            }
        }

        private void StatusFilterCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StatusFilterCombo.SelectedItem is ComboBoxItem item)
            {
                FilterApplications(item.Tag.ToString());
            }
        }

        private void ApplicationLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedApplication = ApplicationLv.SelectedItem as MyApplication;

            if (_selectedApplication != null)
            {
                SelectedInfoText.Text = $"Заявка: {_selectedApplication.User?.FullName} - {_selectedApplication.Section?.Title}";

                // Активируем кнопки только для новых заявок
                bool isNew = _selectedApplication.Status == "Новая";
                AcceptButton.IsEnabled = isNew;
                RejectButton.IsEnabled = isNew;
            }
            else
            {
                SelectedInfoText.Text = "Выберите заявку";
                AcceptButton.IsEnabled = false;
                RejectButton.IsEnabled = false;
            }
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedApplication != null && _selectedApplication.Status == "Новая")
            {
                var result = MessageBox.Show(
                    $"Принять заявку от {_selectedApplication.User?.FullName}?",
                    "Подтверждение",  MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        _selectedApplication.Status = "Принята";
                        App.context.SaveChanges();

                        // Обновляем список
                        LoadApplications();
                        StatusFilterCombo.SelectedIndex = 0;

                        MessageBox.Show("Заявка принята!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }

        private void RejectButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedApplication != null && _selectedApplication.Status == "Новая")
            {
                var result = MessageBox.Show(
                    $"Отклонить заявку от {_selectedApplication.User?.FullName}?",
                    "Подтверждение",
                    MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        _selectedApplication.Status = "Отклонена";
                        App.context.SaveChanges();

                        // Обновляем список
                        LoadApplications();
                        StatusFilterCombo.SelectedIndex = 0;

                        MessageBox.Show("Заявка отклонена!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }
    }
}