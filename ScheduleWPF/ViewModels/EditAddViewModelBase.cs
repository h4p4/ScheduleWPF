using CommunityToolkit.Mvvm.ComponentModel;
using ScheduleWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleWPF.ViewModels
{
    public partial class EditAddViewModelBase : ObservableObject
    {
        private const int FullLectureInMunutes = 95;
        private const int ShortLectureInMunutes = 60;

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
        private Lecture? _lecture;
        [ObservableProperty]
        private string? _description;
        [ObservableProperty]
        private DateOnly _date;
        private Time? _time;
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
        public void IsShortDaySetWithoutUpdate(bool value)
        {
            SetProperty(ref _isShortDay, value);
            Handle();
        }
        public EditAddViewModelBase()
        {
            _roomList = new ObservableCollection<Room>(Helper.GetContext().Rooms);
            _subjectList = new ObservableCollection<Subject>(Helper.GetContext().Subjects);
            _date = DateOnly.FromDateTime(DateTime.Now);
            _allTimeList = new ObservableCollection<Time>(Helper.GetContext().Times);
        }
        private void Handle()
        {

            TimeList = new (IsShortDay ? _allTimeList.Where(x => x.DiffInMinutes == ShortLectureInMunutes) : 
                                          _allTimeList.Where(x => x.DiffInMinutes == FullLectureInMunutes));
        }
    }
}
