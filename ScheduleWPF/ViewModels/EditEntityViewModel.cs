using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using ScheduleWPF.Models.DataProviders;
using ScheduleWPF.Utilities.DataTypes.Collections;
using ScheduleWPF.Utilities.Helpers;

namespace ScheduleWPF.ViewModels
{
    public partial class EditEntityViewModel<TEntity> : ObservableObject where TEntity : class
    {
        private readonly ContextProvider _contextProvider = new ContextProvider();
        [ObservableProperty] private BindableCollection<TEntity> _selectedEntityData;
        private TEntity _selectedEntityInstance;
        public TEntity SelectedEntityInstance
        {
            get => _selectedEntityInstance; 
            set 
            {
                if (value == null) return;
                if (!SetProperty(ref _selectedEntityInstance, value)) return;
                _contextProvider.Context.Update(SelectedEntityInstance);
                
            }
        }

        public EditEntityViewModel() 
        {
            SelectedEntityData = new(_contextProvider.GetContext<TEntity>());
        }
        [RelayCommand] private void SaveChanges()
        {

            ThrowHelper.ThrowUnless<DbUpdateException>(_contextProvider.TrySaveChanges(), "Не удалось сохранить изменения!");
        }
    }
}
