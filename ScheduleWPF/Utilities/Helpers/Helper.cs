using ScheduleWPF.ViewModels;

namespace ScheduleWPF.Utilities.Helpers
{
    public static class Helper
    {
        private static MainViewModel _mainViewModel;
        public static MainViewModel MainViewModel
        {
            get => _mainViewModel;
            set => _mainViewModel = value;
        }
    }
}
