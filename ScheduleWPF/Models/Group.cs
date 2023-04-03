using ScheduleWPF.Utilities;
using System;
using System.Collections.Generic;

namespace ScheduleWPF.Models;

public partial class Group
{
    internal int Id { get; set; }

    public string Title { get; set; } = null!;

    internal virtual ICollection<Lecture> Lectures { get; } = new List<Lecture>();

}
