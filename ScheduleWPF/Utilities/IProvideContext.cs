using Microsoft.EntityFrameworkCore;
using ScheduleWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleWPF.Utilities
{
    public interface IProvideContext<TContext> where TContext : DbContext
    {
        public static TContext Context { get; }
        public static List<TEntity> GetContext<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }
        public static bool TrySaveChanges()
        {
            throw new NotImplementedException();
        }
        public static void CancelChanges(object? objectWithChanges)
        {
            throw new NotImplementedException();
        }

    }
}
