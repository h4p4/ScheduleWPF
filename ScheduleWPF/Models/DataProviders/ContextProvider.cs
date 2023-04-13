using Microsoft.EntityFrameworkCore;
using ScheduleWPF.Models.DataControllers;
using ScheduleWPF.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleWPF.Models.DataProviders
{
    public class ContextProvider : IProvideContext<ScheduleContext>
    {
        private static readonly ScheduleContext _globalContext;
        private readonly ScheduleContext _context;
        static ContextProvider()
        {
            _globalContext = new ScheduleContext();
        }
        public ContextProvider()
        {
            _context = new ScheduleContext();
        }
        public static ScheduleContext GlobalContext => _globalContext;
        public static List<TEntity> GetContext<TEntity>(object obj = null) where TEntity : class
        {
            DbSet<TEntity> entities = _globalContext.Set<TEntity>();
            return entities.ToList();
        }
        public static bool TrySaveChanges(object obj = null)
        {
            try
            {
                _globalContext.SaveChanges(true);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public static void CancelChanges(object? objectWithChanges, object obj = null)
        {
            if (objectWithChanges == null) return;
            _globalContext.Entry(objectWithChanges).Reload();
            _globalContext.Update(objectWithChanges);
        }
        public ScheduleContext Context => _context;
        public List<TEntity> GetContext<TEntity>() where TEntity : class
        {
            DbSet<TEntity> entities = _context.Set<TEntity>();
            return entities.ToList();
        }
        public bool TrySaveChanges()
        {
            try
            {
                _context.SaveChanges(true);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public void CancelChanges(object? objectWithChanges)
        {
            if (objectWithChanges == null) return;
            _context.Entry(objectWithChanges).Reload();
            _context.Update(objectWithChanges);
        }

    }
}
