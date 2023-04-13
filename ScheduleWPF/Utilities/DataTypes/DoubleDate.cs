using System;

namespace ScheduleWPF.Utilities.DataTypes
{
    public class DoubleDate
    {
        public DateOnly FirstDate { get; private set; }
        public DateOnly LastDate { get; private set; }
        public DoubleDate(DateOnly firstDate)
        {
            FirstDate = firstDate;
            LastDate = FirstDate.AddDays(5);
        }
        public DoubleDate(DateOnly firstDate, DateOnly lastDate)
        {
            FirstDate = firstDate;
            LastDate = lastDate;
        }
        public string View
        {
            get => FirstDate.ToString("m") + " - " + LastDate.ToString("m");
        }
        public bool IsInRange(DateOnly dateToCheck) => dateToCheck >= FirstDate && dateToCheck <= LastDate.AddDays(1);

    }
}
