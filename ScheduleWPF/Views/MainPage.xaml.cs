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
using Microsoft.EntityFrameworkCore;
using ScheduleWPF.Models;
using ScheduleWPF.ViewModels;

namespace ScheduleWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        //private List<DataGrid> weekDataGrids;
        private MainPageEditAddSubPage? _editAddSubPage;
        private MainViewModel _viewModel;

        private MainPageEditAddSubPage? EditAddSubPage
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
            //weekDataGrids = new List<DataGrid>(LecturesGrid.Children.OfType<DataGrid>().Where(n => n.Name.EndsWith("LecturesDataGrid")));
        }

        private void LecturesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditAddSubPage = new MainPageEditAddSubPage((Lecture)((DataGrid)sender).SelectedItem);
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
            EditAddSubPage = new MainPageEditAddSubPage(ref ViewModel._allLectures, ViewModel.SelectedDoubleDate.FirstDate.AddDays(dow), ViewModel.SelectedGroup);
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
    }
}
