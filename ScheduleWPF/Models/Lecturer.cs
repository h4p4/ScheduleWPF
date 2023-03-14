using System;
using System.Collections.Generic;

namespace ScheduleWPF.Models;

public partial class Lecturer
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? MiddleName { get; set; }

    public virtual ICollection<Lecture> Lectures { get; } = new List<Lecture>();
}
