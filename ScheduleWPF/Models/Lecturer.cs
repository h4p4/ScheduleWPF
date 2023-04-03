using ScheduleWPF.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ScheduleWPF.Models;

public partial class Lecturer
{
    internal int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? MiddleName { get; set; }

    internal virtual ICollection<Lecture> Lectures { get; } = new List<Lecture>();



    ///////////////////////////////////////////////////////////////////////////////
    // !!FOLLOWING CODE WILL DISAPPEAR IF YOU RE-SCAFFOLD MODELS FROM DATABASE!! //
    ///////////////////////////////////////////////////////////////////////////////
    [NotMapped]
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
