using ScheduleWPF.Views;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Threading;

namespace ScheduleWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        App() 
        {
            DispatcherUnhandledException += Application_UnhandledException;
        }
        private void Application_UnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            var messageBoxResult = MessageBox.Show(
                e.Exception.GetType().Name + ": " +
                e.Exception.Message +
                "\nCode: " +
                e.Exception.HResult +
                "\n\nRestart applicaton?", "Error!", MessageBoxButton.YesNoCancel, MessageBoxImage.Error);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                Restart();
                return;
            }
            if (messageBoxResult == MessageBoxResult.Cancel)
                Application.Current.Shutdown();
        }

        private void Restart()
        {
            MainWindow mn = new MainWindow();
            mn.Show();
            Current.Windows.OfType<MainWindow>().Where(x => x.GetHashCode() != mn.GetHashCode()).ToList().ForEach(mw => mw.Close());
        }
    }
}
