﻿using CommunityToolkit.Mvvm.ComponentModel;
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
        private ObservableCollection<Time> _allTimeList;
        [ObservableProperty]
        private ObservableCollection<Time> _timeList;
        [ObservableProperty]
        private ObservableCollection<Subject> _subjectList;
        [ObservableProperty]
        private Lecture? _lecture;
        [ObservableProperty]
        private string? _description;
        [ObservableProperty]
        private DateOnly _date;
        [ObservableProperty]
        private Time? _time;
        public bool IsShortDay
        {
            get { return _isShortDay; }
            set { SetProperty(ref _isShortDay, value); Handle(); }
        }
        public EditAddViewModelBase()
        {
            _subjectList = new ObservableCollection<Subject>(Helper.GetContext().Subjects);
            _date = DateOnly.FromDateTime(DateTime.Now);
            _allTimeList = new ObservableCollection<Time>(Helper.GetContext().Times);
            IsShortDay = false;
        }
        private void Handle()
        {
            TimeList = new (IsShortDay ? _allTimeList.Where(x => x.DiffInMinutes == ShortLectureInMunutes) : 
                                          _allTimeList.Where(x => x.DiffInMinutes == FullLectureInMunutes));
            if (Time == null) return;
            //if (IsShortDay && _time.DiffInMinutes == FullLectureInMunutes) _timeList.Insert(0, _time);
            //if (!IsShortDay && _time.DiffInMinutes == ShortLectureInMunutes) _timeList.Insert(0, _time);

        }
    }
}
