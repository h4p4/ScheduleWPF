using ScheduleWPF.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleWPF.Models;

public partial class Room
{
    internal int Id { get; set; }

    public string Title { get; set; } = null!;

    internal virtual ICollection<Lecture> Lectures { get; } = new List<Lecture>();

}
