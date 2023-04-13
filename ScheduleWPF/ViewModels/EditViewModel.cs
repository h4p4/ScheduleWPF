using ScheduleWPF.Models;
using ScheduleWPF.Utilities.DataTypes.Enums;

namespace ScheduleWPF.ViewModels
{
    public partial class EditViewModel : EditAddViewModelBase
    {
        public EditViewModel(Lecture lecture) : base()
        {
            Lecture = lecture;
            if (lecture == null || lecture.Time == null) return;
            SetIsShortDayWithoutUpdate(lecture.Time.Length == LectureLength.Short);
        }
    }
}
