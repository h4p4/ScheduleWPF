using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using ScheduleWPF.Models;

namespace ScheduleWPF.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private List<Lecture> _lectures = new List<Lecture>();

        public MainViewModel()
        {
            _lectures.AddRange(Helper.GetContext().Lectures.ToList());
        }
    }
}
