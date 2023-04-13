using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleWPF.Utilities
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
