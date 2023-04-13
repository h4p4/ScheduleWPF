using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ScheduleWPF.Models.Interfaces
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
