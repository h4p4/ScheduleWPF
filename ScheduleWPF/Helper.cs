using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using ScheduleWPF.Models;
using ScheduleWPF.ViewModels;

namespace ScheduleWPF
{
    public static class Helper
    {
        private static MainViewModel _mainViewModel;
        public static MainViewModel MainViewModel
        {
            get => _mainViewModel;
            set => _mainViewModel = value;
        }
        private static ScheduleContext context = new ScheduleContext();
        public static ScheduleContext GetContext()
        {
            return context;
        }
        public static bool SaveChanges()
        {
            try
            {
                context.SaveChanges(true);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public static void DeleteChanges(object objectWithChanges)
        {
            context.Entry(objectWithChanges).Reload();
        }
        public static void Add<T>(T objectToAdd, ObservableCollection<T> collection)
        {
            collection.Add(objectToAdd);
            context.Update(objectToAdd);
        }
        public static bool ExecuteCommand(IRelayCommand? command)
        {
            if (command == null) return false;
            //if (!command.CanExecute(null)) return false;
            //command.Execute(null);
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
