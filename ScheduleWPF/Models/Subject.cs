using ScheduleWPF.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ScheduleWPF.Models;

public partial class Subject
{
    [Browsable(false)]
    public int Id { get; set; }
    [DisplayName("Название предмета")]
    public string Title { get; set; } = null!;
    [Browsable(false)]
    public virtual ICollection<Lecture> Lectures { get; } = new List<Lecture>();
}
