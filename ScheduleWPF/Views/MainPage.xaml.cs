using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ScheduleWPF.Models;
using ScheduleWPF.Utilities.Helpers;
using ScheduleWPF.Utilities.Extensions;
using ScheduleWPF.ViewModels;

namespace ScheduleWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        //private List<DataGrid> _weekDataGrids;
        private MainPageEditAddLectureForm? _editAddSubPage;
        private MainViewModel _viewModel;
        private DataGrid? _previousSelectedDGrid;
        private MainPageEditAddLectureForm? EditAddSubPage
        {
            set
            {
                _editAddSubPage = value;
                EditAddFrame.Content = _editAddSubPage;
            }
            get { return _editAddSubPage; }
        }
        private MainViewModel ViewModel
        {
            set 
            { 
                _viewModel = value;
                this.DataContext = _viewModel;
                Helper.MainViewModel = _viewModel;
            }
            get { return _viewModel; }
        }
        public MainPage()
        {
            InitializeComponent();
            ViewModel = new MainViewModel();
            ChangeAddButtonsVisibility(ViewModel.CanAdd);
            //_weekDataGrids = new List<DataGrid>(LecturesGrid.Children.OfType<DataGrid>().Where(n => n.Name.EndsWith("LecturesDataGrid")));
        }

        private void LecturesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid selectedDGrid = (DataGrid)sender;
            EditAddSubPage = new MainPageEditAddLectureForm((Lecture)selectedDGrid.SelectedItem);
            selectedDGrid.SelectionChanged -= LecturesDataGrid_SelectionChanged;
            var focusedElement = FocusManager.GetFocusedElement(selectedDGrid);
            UnfocusPreviousSelection();
            _previousSelectedDGrid = selectedDGrid;
            FocusCurrentSelection();
            selectedDGrid.SelectionChanged += LecturesDataGrid_SelectionChanged;

            void UnfocusPreviousSelection()
            {
                if (_previousSelectedDGrid == null) return;
                if (_previousSelectedDGrid.Name == selectedDGrid.Name) return;
                _previousSelectedDGrid.SelectionChanged -= LecturesDataGrid_SelectionChanged;
                Keyboard.ClearFocus();
                FocusManager.SetFocusedElement(FocusManager.GetFocusScope(_previousSelectedDGrid), null);
                _previousSelectedDGrid.UnselectAll();
                _previousSelectedDGrid.SelectionChanged += LecturesDataGrid_SelectionChanged;
            }
            void FocusCurrentSelection()
            {
                selectedDGrid.Focus();
                Keyboard.Focus(selectedDGrid);
                Keyboard.Focus(focusedElement);
                FocusManager.SetFocusedElement(FocusManager.GetFocusScope(selectedDGrid), focusedElement);
            }
        }
        private void AnyCBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditAddSubPage = null;
            if (GroupsCBox != ((ComboBox)sender)) return;
            ChangeAddButtonsVisibility(ViewModel.CanAdd);

        }
        private void AddLectureBtn_Click(object sender, RoutedEventArgs e)
        {
            int dow = Grid.GetColumn(((Button)sender));
            EditAddSubPage = new MainPageEditAddLectureForm(ViewModel.SelectedDoubleDate.FirstDate.AddDays(dow), ViewModel.SelectedGroup);
        }
        private void DeleteLecture_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите удалить выбранную лекцию?", String.Empty, MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes) return;
            MessageBoxResult messageBoxResult;
            do {
                if (DeleteLecture()) return;
                messageBoxResult = MessageBox.Show("Не удалось удалить лекцию!\nПопробовать еще раз?", "Ошибка", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            } while (messageBoxResult == MessageBoxResult.Yes);
        }

        private void ChangeAddButtonsVisibility(bool isVisible)
        {
            if (isVisible)
            {
                AddBtnsStackPanel.Visibility = Visibility.Visible;
                return;
            }
            AddBtnsStackPanel.Visibility = Visibility.Hidden;
        }
        private bool DeleteLecture()
        {
            if (EditAddSubPage != null)
            {
                var returnValue = ViewModel.DeleteLectureCommand.TryExecute();
                CloseForm();
                return returnValue;
            }
            return ViewModel.DeleteLectureCommand.TryExecute();
        }
        private void CloseForm()
        {
            EditAddFrame.NavigationService.Navigate(null);
        }
    }
}
