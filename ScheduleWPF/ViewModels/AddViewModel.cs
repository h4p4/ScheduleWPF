using CommunityToolkit.Mvvm.ComponentModel;
using ScheduleWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleWPF.ViewModels
{
    public partial class AddViewModel : EditAddViewModelBase
    {
        private DateOnly _dateOnly;
        private Group _group;
        private ObservableCollection<Lecture> _lectures;

        [ObservableProperty]
        private Lecturer _lecturer;
        [ObservableProperty]
        private Room _room;
        [ObservableProperty]
        private Subject _subject;
        [ObservableProperty]
        private Time _time;
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
            Helper.Add(Lecture, _lectures);
            base.SaveChanges();
            Helper.MainViewModel.UpdateView();
        }
    }
}
