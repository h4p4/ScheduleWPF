using ScheduleWPF.Models.DataControllers;
using ScheduleWPF.Models.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace ScheduleWPF.Models;

public partial class Room : ProvidableEntity
{
    [Browsable(false)]
    public int Id { get; set; }

    [DisplayName("Номер аудитории")]
    public string Title { get; set; } = null!;
    [Browsable(false)]
    public virtual ICollection<Lecture> Lectures { get; } = new List<Lecture>();

}
