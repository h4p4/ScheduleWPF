using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleWPF.Models;

namespace ScheduleWPF
{
    public static class Helper
    {
        private static ScheduleContext context = new ScheduleContext();
        public static ScheduleContext GetContext()
        {
            return context;
        }
        public static void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
