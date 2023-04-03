using MahApps.Metro.Controls;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private int _pageIndex = 0;
        private int _buttonIndex = 0;
        List<Button> _buttons;
        Brush _defaultBackgroundColor;
        Brush _selectedBackgroundColor;
        private List<Page> _pages = new List<Page>()
        {
            new MainPage(),
            new EditEntityForm()
        };
        public MainWindow()
        {
            InitializeComponent();
            _buttons = new List<Button>(BtnsGrid.Children.OfType<Button>().Where(n => n.Name.StartsWith("Show") && n.Name.EndsWith("Btn")));
            _selectedBackgroundColor = _buttons.ElementAt(0).Background;
            _defaultBackgroundColor = _buttons.ElementAt(1).Background;
            MainFrame.Content = _pages.ElementAt(_pageIndex);
        }

        private void Handle(Button button)
        {
            var prevBtn = _buttons.ElementAt(_buttonIndex);
            prevBtn.FontWeight = FontWeights.Normal;
            prevBtn.Background = _defaultBackgroundColor;

            MainFrame.Content = _pages[_buttons.IndexOf(button)];
            button.FontWeight = FontWeights.Bold;
            button.Background = _selectedBackgroundColor;
            _buttonIndex = _buttons.IndexOf(button);
        }

        private void ShowScheduleBtn_Click(object sender, RoutedEventArgs e)
        {
            Handle(sender as Button);
        }

        private void ShowEditFormBtn_Click(object sender, RoutedEventArgs e)
        {
            Handle(sender as Button);
        }
    }
}
