using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.VisualBasic;
using ScheduleWPF.Models;
using ScheduleWPF.Utilities;

namespace ScheduleWPF.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private string _selectedYear;
        private Group _selectedGroup;
        private DoubleDate _selectedDoubleDate;
        private Lecture _selectedLecture;

        private ObservableCollection<string> _allYears;
        private ObservableCollection<Lecture> _allLectures;
        private ObservableCollection<DoubleDate> _doubleDates;


        [ObservableProperty]
        private ObservableCollection<Lecture> _mondayLectures;
        [ObservableProperty]
        private ObservableCollection<Lecture> _tuesdayLectures;
        [ObservableProperty]
        private ObservableCollection<Lecture> _wednesdayLectures;
        [ObservableProperty]
        private ObservableCollection<Lecture> _thursdayLectures;
        [ObservableProperty]
        private ObservableCollection<Lecture> _fridayLectures;
        [ObservableProperty]
        private ObservableCollection<Lecture> _saturdayLectures;
        [ObservableProperty]
        private ObservableCollection<Group> _allGroups;
        [ObservableProperty]
        private ObservableCollection<DateOnly> _allDates;


        public ObservableCollection<DoubleDate> DoubleDates
        {
            get { return _doubleDates; }
            set { _doubleDates = value; SetProperty(ref _doubleDates, value); }
        }
        public ObservableCollection<string> AllYears
        {
            get { return _allYears; }
            set { _allYears = value; SetProperty(ref _allYears, value); }
        }
        public ObservableCollection<ObservableCollection<Lecture>> Lectures { get; set; }
        public Group SelectedGroup
        {
            get { return _selectedGroup; }
            set { SetProperty(ref _selectedGroup, value); Handle(); }
        }
        public DoubleDate SelectedDoubleDate
        {
            get { return _selectedDoubleDate; }
            set { SetProperty(ref _selectedDoubleDate, value); Handle(); }
        }
        public Lecture SelectedLecture
        {
            get { return _selectedLecture; }
            set { SetProperty(ref _selectedLecture, value); /*Handle();*/ }
        }
        public string SelectedYear
        {
            get { return _selectedYear; }
            set { SetProperty(ref _selectedYear, value); Handle(); }
        }

        public MainViewModel()
        {
            InitializeData();
        }
        private void InitializeData()
        {
            InitLectures();
            InitYears(); //years cbox
            InitDates(); //dates cbox
            InitGroups(); //groups cbox
            InitLecturesPool(); //all lectures pool
        }
        private void InitYears()
        {
            _allYears = new();
            for (int y = 2005; y < 2099; y++)
            {
                _allYears.Add(y.ToString());
                if (DateTime.Now.Year.ToString() == y.ToString())
                    _selectedYear = y.ToString();
            }
        }
        private void InitDates()
        {
            DoubleDates = new ObservableCollection<DoubleDate>();
            DateTime date = new DateTime(Convert.ToInt32(_selectedYear), 1, 1);
            while (date.DayOfWeek != DayOfWeek.Monday)
                date = date.AddDays(1);
            DoubleDate selectedDoubleDate = null;
            do
            {
                DoubleDates.Add(new DoubleDate(DateOnly.FromDateTime(date)));
                for (int i = 0; i <= 6; i++)
                    date = date.AddDays(1);
                if (DoubleDates.Last().IsInRange(DateOnly.FromDateTime(DateTime.Now)) && selectedDoubleDate == null)
                    selectedDoubleDate = DoubleDates.Last();
            } while (date.Year.ToString() != (Convert.ToInt32(_selectedYear) + 1).ToString());
            _selectedDoubleDate = selectedDoubleDate;
        }
        private void InitGroups()
        {
            _allGroups = new ObservableCollection<Group>(Helper.GetContext().Groups);
            _allGroups.Insert(0, new Group { Title = "Выберите группу", Id = -1 });
            _selectedGroup = AllGroups.First();
        }
        private void InitLecturesPool()
        {
            _allLectures = new ObservableCollection<Lecture>(
                                Helper.GetContext()
                                      .Lectures.Include(x => x.Subject)
                                      .Include(x => x.Group)
                                      .Include(x => x.Room)
                                      .Include(x => x.Time)
                                      .Include(x => x.Lecturer)
                                );
        }
        private void InitLectures()
        {
            Lectures = new();
            MondayLectures = new();
            TuesdayLectures = new();
            WednesdayLectures = new();
            ThursdayLectures = new();
            FridayLectures = new();
            SaturdayLectures = new();
            Lectures.Add(MondayLectures);
            Lectures.Add(TuesdayLectures);
            Lectures.Add(WednesdayLectures);
            Lectures.Add(ThursdayLectures);
            Lectures.Add(FridayLectures);
            Lectures.Add(SaturdayLectures);
        }

        private void Handle()
        {
            ClearLectures();
            if (_selectedGroup.Id != -1)
                UpdateLectures();
        }
        private void UpdateLectures()
        {

            for (int i = 0; i < 6; i++)
                foreach (var l in (_allLectures.Where(x => (x.Group.Id == _selectedGroup.Id) && x.Date == SelectedDoubleDate.FirstDate.AddDays(i))))
                    Lectures.ElementAt(i).Add(l);
        }
        private void ClearLectures()
        {
            foreach (var l in Lectures)
                l.Clear();
        }
    }
}
