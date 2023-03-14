using System;
using System.Collections.Generic;

namespace ScheduleWPF.Models;

public partial class Subject
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Lecture> Lectures { get; } = new List<Lecture>();
}
