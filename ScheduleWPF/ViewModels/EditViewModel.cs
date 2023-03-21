using CommunityToolkit.Mvvm.ComponentModel;
using ScheduleWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleWPF.ViewModels
{
    public partial class EditViewModel : EditAddViewModelBase
    {
        public EditViewModel(Lecture lecture) : base()
        {
            Lecture = lecture;
            if (lecture == null) return;
            IsShortDaySetWithoutUpdate(lecture.Time.DiffInMinutes == 60);
        }
    }
}
