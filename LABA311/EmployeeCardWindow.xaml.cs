using System;
using System.Windows;

namespace EmployeeCardApp
{
    public partial class EmployeeCardWindow : Window
    {
        public EmployeeCardWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string lastName = TextBoxLastName.Text.Trim();
            string firstName = TextBoxFirstName.Text.Trim();
            string middleName = TextBoxMiddleName.Text.Trim();
            string position = TextBoxPosition.Text.Trim();
            string department = ComboBoxDepartment.SelectedItem?.ToString() ?? "Не указан";
            DateTime birthDate = DatePickerBirthDate.SelectedDate ?? DateTime.MinValue;

            if (string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(firstName))
            {
                MessageBox.Show("Пожалуйста, заполните обязательные поля: Фамилия и Имя.");
                return;
            }

            if (birthDate == DateTime.MinValue)
            {
                MessageBox.Show("Пожалуйста, выберите дату рождения.");
                return;
            }

            string message = $"Сотрудник:\n{lastName} {firstName} {middleName}\n" +
                             $"Должность: {position}\n" +
                             $"Отдел: {department}\n" +
                             $"Дата рождения: {birthDate.ToShortDateString()}";

            MessageBox.Show(message, "Сохранено успешно");
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            TextBoxLastName.Clear();
            TextBoxFirstName.Clear();
            TextBoxMiddleName.Clear();
            TextBoxPosition.Clear();
            ComboBoxDepartment.SelectedIndex = -1;
            DatePickerBirthDate.SelectedDate = null;
        }
    }
}