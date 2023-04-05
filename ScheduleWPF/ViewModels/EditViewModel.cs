using CommunityToolkit.Mvvm.ComponentModel;
using ScheduleWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace ScheduleWPF.ViewModels
{
    public partial class EditViewModel : EditAddViewModelBase
    {
        public EditViewModel(Lecture lecture) : base()
        {
            Lecture = lecture;
            if (lecture == null || lecture.Time == null) return;
            SetIsShortDayWithoutUpdate(lecture.Time.Length == Utilities.LectureLength.Short);
        }
    }
}
