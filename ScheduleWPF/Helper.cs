using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ScheduleWPF.Models;
using ScheduleWPF.ViewModels;

namespace ScheduleWPF
{
    public static class Helper
    {
        private static readonly ScheduleContext _context = new ScheduleContext();
        private static MainViewModel _mainViewModel;
        public static MainViewModel MainViewModel
        {
            get => _mainViewModel;
            set => _mainViewModel = value;
        }

        public static ScheduleContext Context => _context;
        public static List<TEntity> GetContext<TEntity>() where TEntity : class
        {
            DbSet<TEntity> entities = _context.Set<TEntity>();
            return entities.ToList();
        }
        public static bool SaveChanges()
        {
            try
            {
                _context.SaveChanges(true);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public static void DeleteChanges(object? objectWithChanges)
        {
            if (objectWithChanges == null) return;
            _context.Entry(objectWithChanges).Reload();
            _context.Update(objectWithChanges);
        }
        public static void Add<T>(T objectToAdd, ObservableCollection<T> collection)
        {
            collection.Add(objectToAdd);
            _context.Update(objectToAdd);
        }
        public static void AddRange<T>(List<T> deleteRange, ObservableCollection<T> collection)
        {
            foreach (var item in deleteRange)
            {
                collection.Add(item);
                _context.Update(item);
            }
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
    }
}
