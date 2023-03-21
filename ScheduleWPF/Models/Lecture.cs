using System;
using System.Collections.Generic;

namespace ScheduleWPF.Models;

public partial class Lecture
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public DateOnly Date { get; set; }

    public int? TimeId { get; set; }

    public int RoomId { get; set; }

    public int LecturerId { get; set; }

    public int SubjectId { get; set; }

    public int GroupId { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual Lecturer Lecturer { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;

    public virtual Time? Time { get; set; }
}
