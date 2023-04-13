using CommunityToolkit.Mvvm.Input;
using System;

namespace ScheduleWPF.Utilities.Extensions
{
    public static class IRelayCommandExtension
    {
        public static bool TryExecute(this IRelayCommand? command, object parameter = null)
        {
            if (command == null) return false;
            try
            {
                command.Execute(null);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
