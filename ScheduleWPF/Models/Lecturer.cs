using ScheduleWPF.Models.DataControllers;
using ScheduleWPF.Models.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleWPF.Models;

public partial class Lecturer : ProvidableEntity
{
    [Browsable(false)]
    public int Id { get; set; }
    [DisplayName("Имя")]
    public string FirstName { get; set; } = null!;
    [DisplayName("Фамилия")]
    public string Surname { get; set; } = null!;
    [DisplayName("Отчество")]
    public string? MiddleName { get; set; }
    [Browsable(false)]
    public virtual ICollection<Lecture> Lectures { get; } = new List<Lecture>();



    ///////////////////////////////////////////////////////////////////////////////
    // !!FOLLOWING CODE WILL DISAPPEAR IF YOU RE-SCAFFOLD MODELS FROM DATABASE!! //
    ///////////////////////////////////////////////////////////////////////////////
    [NotMapped]
    [Browsable(false)]
    public string FormattedFullName
    {
        get 
        {
            var fullName =
                this.MiddleName == null ?
                this.Surname + " " + StringShortNameFormat(this.FirstName) : 
                this.Surname + " " + StringShortNameFormat(this.FirstName) + StringShortNameFormat(this.MiddleName);
            return fullName;
        }
    }
    private string StringShortNameFormat(string name)
    {
        return name.Substring(0, 1) + ". ";
    }
}
