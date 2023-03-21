using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleWPF.Models;

public partial class Room
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Lecture> Lectures { get; } = new List<Lecture>();

}
