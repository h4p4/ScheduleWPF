using ScheduleWPF.Models;
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
    /// Логика взаимодействия для MainPageEditAddSubPage.xaml
    /// </summary>
    public partial class MainPageEditAddSubPage : Page
    {
        private Lecture? _lecture;
        public MainPageEditAddSubPage(Lecture lecture)
        {
            InitializeComponent();
            _lecture = lecture;
            this.DataContext = new EditViewModel(lecture);
        }
        public MainPageEditAddSubPage()
        {
            InitializeComponent();
            this.DataContext = new AddViewModel();
        }

        private void IsShortDayChBox_Click(object sender, RoutedEventArgs e)
        {
            TimeCBox.SelectedIndex = 0;
        }
    }
}
