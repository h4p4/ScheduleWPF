using System;
using System.Collections.Generic;

namespace ScheduleWPF.Models;

public partial class Time
{
    public int Id { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public virtual ICollection<Lecture> Lectures { get; } = new List<Lecture>();
}
