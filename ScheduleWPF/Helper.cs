using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
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
            context.Update(objectWithChanges);
        }
        public static void Add<T>(T objectToAdd, ObservableCollection<T> collection)
        {
            collection.Add(objectToAdd);
            context.Update(objectToAdd);
        }
        public static bool ExecuteCommand(IRelayCommand? command)
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
        public static void ThrowIf(bool condition, string message)
        {
            try
            {
                if (condition) throw new Exception(message);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void ThrowIf(bool condition)
        {
            try
            {
                if (condition) throw new Exception();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
