using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using ScheduleWPF.Models;
using ScheduleWPF.Models.DataProviders;
using ScheduleWPF.Utilities.DataTypes.Enums;
using ScheduleWPF.Utilities.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ScheduleWPF.ViewModels
{
    public partial class EditAddViewModelBase : ObservableObject
    {
        private Time? _time;
        private bool _isShortDay;
        private Time _defaultTime = new Time();
        private ObservableCollection<Time> _allTimeList;
        [ObservableProperty] private ObservableCollection<Time> _timeList;
        [ObservableProperty] private ObservableCollection<Subject> _subjectList;
        [ObservableProperty] private ObservableCollection<Room> _roomList;
        [ObservableProperty] private ObservableCollection<Lecturer> _lecturerList;
        [ObservableProperty] private Lecture? _lecture;
        [ObservableProperty] private string? _description;
        [ObservableProperty] private DateOnly _date;
        public Time? Time
        {
            get { return _time; }
            set 
            {
                SetProperty(ref _time, value);
                if (Time.Id == null)
                    TimeList.RemoveAt(0);
            }
        }

        public bool IsShortDay
        {
            get { return _isShortDay; }
            set 
            { 
                SetProperty(ref _isShortDay, value); 
                Handle();
                TimeList.Insert(0, _defaultTime);
                _time = _defaultTime;
            }
        }

        public void SetIsShortDayWithoutUpdate(bool value)
        {
            SetProperty(ref _isShortDay, value);
            Handle();
        }
        public EditAddViewModelBase()
        {
            ContextProvider.CancelChanges(Lecture);
            _date = DateOnly.FromDateTime(DateTime.Now);
            _roomList = new ObservableCollection<Room>(ContextProvider.GlobalContext.Rooms);
            _subjectList = new ObservableCollection<Subject>(ContextProvider.GlobalContext.Subjects);
            _allTimeList = new ObservableCollection<Time>(ContextProvider.GlobalContext.Times);
            _lecturerList = new ObservableCollection<Lecturer>(ContextProvider.GlobalContext.Lecturers);
            Handle();

        }
        private void Handle()
        {
            TimeList = new (IsShortDay ? _allTimeList.Where(x => x.Length == LectureLength.Short) : 
                                          _allTimeList.Where(x => x.Length == LectureLength.Long));
        }

        [RelayCommand]
        protected virtual void SaveChanges()
        {
            ThrowHelper.ThrowUnless<DbUpdateException>(ContextProvider.TrySaveChanges());
        }
        [RelayCommand]
        protected virtual void CancelChanges()
        {
            ContextProvider.CancelChanges(Lecture);
            Helper.MainViewModel.UpdateView();
        }
    }
}
