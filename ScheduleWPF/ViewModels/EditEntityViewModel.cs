using CommunityToolkit.Mvvm.ComponentModel;
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

        //[ObservableProperty]
        //private KeyValuePair<List<TEntity>, string> _selectedEntity;
        //private ObservableCollection<TEntity> _selectedEntityData;
        [ObservableProperty]
        private ObservableCollection<TEntity> _selectedEntityData;
        public EditEntityViewModel() 
        {
            SelectedEntityData = new(Helper.GetContext<TEntity>());
        }
    }
}
