using ScheduleWPF.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleWPF.Models;

public partial class Room
{
    [Browsable(false)]
    public int Id { get; set; }

    [DisplayName("Номер аудитории")]
    public string Title { get; set; } = null!;
    [Browsable(false)]
    public virtual ICollection<Lecture> Lectures { get; } = new List<Lecture>();

}
