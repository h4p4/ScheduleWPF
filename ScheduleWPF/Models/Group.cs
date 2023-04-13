using System.Collections.Generic;
using System.ComponentModel;

namespace ScheduleWPF.Models;

public partial class Group
{
    [Browsable(false)]
    public int Id { get; set; }
    [DisplayName("Номер группы")]
    public string Title { get; set; } = null!;
    [Browsable(false)]
    public virtual ICollection<Lecture> Lectures { get; } = new List<Lecture>();

}
