using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using ScheduleWPF.Models;
using ScheduleWPF.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ScheduleWPF.ViewModels
{
    public partial class EditAddViewModelBase : ObservableObject
    {
        private Time? _time;
        private bool _isShortDay;
        private Time _defaultTime = new Time();
        private ObservableCollection<Time> _allTimeList;
        [ObservableProperty]
        private ObservableCollection<Time> _timeList;
        [ObservableProperty]
        private ObservableCollection<Subject> _subjectList;
        [ObservableProperty]
        private ObservableCollection<Room> _roomList;
        [ObservableProperty]
        private ObservableCollection<Lecturer> _lecturerList;
        [ObservableProperty]
        private Lecture? _lecture;
        [ObservableProperty]
        private string? _description;
        [ObservableProperty]
        private DateOnly _date;
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
            Helper.DeleteChanges(Lecture);
            _date = DateOnly.FromDateTime(DateTime.Now);
            _roomList = new ObservableCollection<Room>(Helper.Context.Rooms);
            _subjectList = new ObservableCollection<Subject>(Helper.Context.Subjects);
            _allTimeList = new ObservableCollection<Time>(Helper.Context.Times);
            _lecturerList = new ObservableCollection<Lecturer>(Helper.Context.Lecturers);
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
            ThrowHelper.ThrowUnless<DbUpdateException>(Helper.SaveChanges());
        }
        [RelayCommand]
        protected virtual void CancelChanges()
        {
            Helper.DeleteChanges(Lecture);
            Helper.MainViewModel.UpdateView();

        }
    }
}
