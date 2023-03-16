using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ScheduleWPF.Models;

public partial class Lecturer
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? MiddleName { get; set; }

    public virtual ICollection<Lecture> Lectures { get; } = new List<Lecture>();



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
                this.Surname + " " + StringDotFormat(this.FirstName) : 
                this.Surname + " " + StringDotFormat(this.FirstName) + StringDotFormat(this.MiddleName);
            return fullName;
        }
    }
    private string StringDotFormat(string name)
    {
        return name.Substring(0, 1) + ". ";
    }
}
