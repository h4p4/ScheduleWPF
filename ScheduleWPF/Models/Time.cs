using ScheduleWPF.Utilities.DataTypes.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleWPF.Models;

public partial class Time
{
    public int? Id { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public virtual ICollection<Lecture> Lectures { get; } = new List<Lecture>();

    ///////////////////////////////////////////////////////////////////////////////
    // !!FOLLOWING CODE WILL DISAPPEAR IF YOU RE-SCAFFOLD MODELS FROM DATABASE!! //
    ///////////////////////////////////////////////////////////////////////////////
    [NotMapped]
    private string? _defaultValue = "Не установлено";
    [NotMapped]
    public string FormattedDoubleTime => 
        Id == null ? 
        _defaultValue : 
        this.StartTime.ToString("H:mm") + " - " + this.EndTime.ToString("H:mm");
    [NotMapped]
    public LectureLength Length
    {
        get
        {
            var len =  Convert.ToInt32(this.EndTime.ToTimeSpan().TotalMinutes -
                                       this.StartTime.ToTimeSpan().TotalMinutes);
            if (len == (int)LectureLength.Long)
                return LectureLength.Long;
            if (len == (int)LectureLength.Short)
                return LectureLength.Short;
            return LectureLength.None;
        }
    }

}
