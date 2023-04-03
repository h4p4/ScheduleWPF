using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ScheduleWPF.Models;
using ScheduleWPF.Utilities;
using ScheduleWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ScheduleWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для EditModelForm.xaml
    /// </summary>
    public partial class EditEntityForm : Page
    {
        public Dictionary<string, string> EditableEntities { get; }
        private object Context
        {
            set
            {
                if (value == null) return;
                Type genericClass = typeof(EditEntityViewModel<>);
                Type constructedClass = genericClass.MakeGenericType(Type.GetType(value.ToString()));
                object created = Activator.CreateInstance(constructedClass);
                this.DataContext = created;
            }
        }
        public EditEntityForm()
        {
            InitializeComponent();
            string path = "ScheduleWPF.Models.";
            EditableEntities = new Dictionary<string, string>
            {
                { path + nameof(Group) , "Группа" },
                { path + nameof(Lecturer), "Преподаватель" },
                { path + nameof(Room), "Аудитория" },
                { path + nameof(Subject), "Предмет" },
            };
            EditCBox.ItemsSource = EditableEntities;
            EditCBox.SelectedItem = EditableEntities.First();
        }

        private void EditCBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Context = EditableEntities.ElementAt(EditCBox.SelectedIndex).Key;
        }
        private void EditDGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var displayName = GetPropertyDisplayName(e.PropertyDescriptor);
            if (string.IsNullOrEmpty(displayName)) return;
            e.Column.Header = displayName;
        }
        private static string GetPropertyDisplayName(object descriptor)
        {
            var pd = descriptor as PropertyDescriptor;
            if (pd != null)
            {
                // Check for DisplayName attribute and set the column header accordingly
                var displayName = pd.Attributes[typeof(DisplayNameAttribute)] as DisplayNameAttribute;
                if (IsNullOrDefault(displayName)) return string.Empty;
                return displayName.DisplayName;
            }
            var pi = descriptor as PropertyInfo;
            if (pi == null) return string.Empty;

            // Check for DisplayName attribute and set the column header accordingly
            object[] attributes = pi.GetCustomAttributes(typeof(DisplayNameAttribute), true);
            for (int i = 0; i < attributes.Length; ++i)
            {
                var displayName = attributes[i] as DisplayNameAttribute;
                if (IsNullOrDefault(displayName)) break;
                return displayName.DisplayName;
            }
            return string.Empty;

            bool IsNullOrDefault(DisplayNameAttribute? displayName) => displayName == null || displayName == DisplayNameAttribute.Default;
        }
    }
}
