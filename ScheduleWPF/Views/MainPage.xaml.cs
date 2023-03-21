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
        private List<DataGrid> weekDataGrids;
        private MainPageEditAddSubPage _editAddSubPage;
        private MainPageEditAddSubPage? EditAddSubPage
        {
            set
            {
                _editAddSubPage = value;
                EditAddFrame.Content = _editAddSubPage;
            }
        }
        public MainPage()
        {
            InitializeComponent();
            Helper.GetContext().Lectures.Load();
            this.DataContext = new MainViewModel();
            weekDataGrids = new List<DataGrid>(LecturesGrid.Children.OfType<DataGrid>().Where(n => n.Name.EndsWith("LecturesDataGrid")));
        }

        private void LecturesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedLecture = (DataGrid)sender;
            EditAddSubPage = new MainPageEditAddSubPage((Lecture)selectedLecture.SelectedItem);
        }

        private void AnyCBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditAddSubPage = null;
        }
    }
}
