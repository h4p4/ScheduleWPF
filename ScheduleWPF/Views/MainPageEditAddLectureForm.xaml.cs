using CommunityToolkit.Mvvm.Input;
using ScheduleWPF.Models;
using ScheduleWPF.Utilities;
using ScheduleWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для MainPageEditAddLectureForm.xaml
    /// </summary>
    public partial class MainPageEditAddLectureForm : Page
    {
        private EditAddViewModelBase _editAddViewModel;
        private EditAddViewModelBase EditAddViewModel
        {
            get => _editAddViewModel;
            set
            {
                _editAddViewModel = value;
                this.DataContext = _editAddViewModel;
            }
        }
        public MainPageEditAddLectureForm(Lecture lecture)
        {
            InitializeComponent();
            EditAddViewModel = new EditViewModel(lecture);

        }
        public MainPageEditAddLectureForm(DateOnly dateOnly, Group group)
        {
            InitializeComponent();
            EditAddViewModel = new AddViewModel(dateOnly, group);
        }
        private void IsShortDayChBox_Click(object sender, RoutedEventArgs e)
        {
            TimeCBox.SelectedIndex = 0;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (EditAddViewModel.SaveChangesCommand.TryExecute())
            {
                ExitPage();
                return;
            }
            if (EditAddViewModel is AddViewModel)
                ShowErrorMessage("Не удалось сохранить лекцию.");
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            EditAddViewModel.CancelChangesCommand.TryExecute();
            ExitPage();
        }
        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Ошибка", 
                MessageBoxButton.OK, MessageBoxImage.Error, 
                MessageBoxResult.OK, MessageBoxOptions.ServiceNotification);
        }
        private void ExitPage()
        {
            NavigationService.Navigate(null);
        }
    }
}
