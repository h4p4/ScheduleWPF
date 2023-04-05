using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ScheduleWPF.Models;
using ScheduleWPF.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleWPF.ViewModels
{
    public partial class EditEntityViewModel<TEntity> : ObservableObject where TEntity : class
    {
        [ObservableProperty]
        private BindableCollection<TEntity> _selectedEntityData;
        private TEntity _selectedEntityInstance;
        public TEntity SelectedEntityInstance
        {
            get => _selectedEntityInstance; 
            set 
            {
                if (!SetProperty(ref _selectedEntityInstance, value)) return;
                Helper.Context.ChangeTracker.Clear();
                Helper.Context.Update(SelectedEntityInstance);
            }
        }

        public EditEntityViewModel() 
        {
            SelectedEntityData = new(Helper.GetContext<TEntity>());
        }
        [RelayCommand]
        private void SaveChanges()
        {
            ThrowHelper.ThrowUnless<DbUpdateException>(Helper.SaveChanges(), "Не удалось сохранить изменения!");
        }
    }
}
