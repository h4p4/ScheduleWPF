﻿using CommunityToolkit.Mvvm.ComponentModel;
using ScheduleWPF.Models;
using ScheduleWPF.Models.DataProviders;
using ScheduleWPF.Utilities.Helpers;
using System;
using System.Collections.ObjectModel;

namespace ScheduleWPF.ViewModels
{
    public partial class AddViewModel : EditAddViewModelBase
    {
        private DateOnly _dateOnly;
        private Group _group;
        private ObservableCollection<Lecture> _lectures;
        [ObservableProperty] private Lecturer _lecturer;
        [ObservableProperty] private Room _room;
        [ObservableProperty] private Subject _subject;
        [ObservableProperty] private Time _time;
        public AddViewModel(DateOnly dateOnly, Group group) : base()
        {
            _lectures = Helper.MainViewModel.AllLectures;
            _dateOnly = dateOnly;
            _group = group;
            Lecture = new();
        }
        protected override void SaveChanges()
        {
            Lecture.Date = _dateOnly;
            Lecture.Group = _group;
            _lectures.Add(Lecture);
            ContextProvider.GlobalContext.ChangeTracker.Clear();
            ContextProvider.GlobalContext.Update(Lecture);
            base.SaveChanges();
            Helper.MainViewModel.UpdateView();
        }
    }
}
