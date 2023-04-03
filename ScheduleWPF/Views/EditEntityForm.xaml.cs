using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ScheduleWPF.Models;
using ScheduleWPF.Utilities;
using ScheduleWPF.ViewModels;
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

namespace ScheduleWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для EditModelForm.xaml
    /// </summary>
    public partial class EditEntityForm : Page
    {
        public Dictionary<string, string> EditableEntities { get; set; }

        public EditEntityForm()
        {
            InitializeComponent();
            EditableEntities = new Dictionary<string, string>
            {
                { nameof(Group) , "Группа" },
                { nameof(Lecturer), "Преподаватель" },
                { nameof(Room), "Аудитория" },
                { nameof(Subject), "Предмет" }
            };
            EditCBox.ItemsSource = EditableEntities;
            EditCBox.SelectedItem = EditableEntities.First();
        }
        private void InitDataContext(string model)
        {
            Type genericClass = typeof(EditEntityViewModel<>);
            Type constructedClass = genericClass.MakeGenericType(Type.GetType("ScheduleWPF.Models." + model));
            object created = Activator.CreateInstance(constructedClass);
            this.DataContext = created;
        }

        private void EditCBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InitDataContext(EditableEntities.ElementAt(EditCBox.SelectedIndex).Key);
        }
    }
}
