using Microsoft.EntityFrameworkCore;
using ScheduleWPF.Models.DataControllers;
using ScheduleWPF.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScheduleWPF.Models.DataProviders
{
    public class ContextProvider : IProvideContext<ScheduleContext>
    {
        private static ScheduleContext _context;

        private static readonly ScheduleContext _globalContext = new ScheduleContext();
        private readonly ScheduleContext _localContext;

        public static ScheduleContext GlobalContext => _globalContext;
        public ScheduleContext Context => _localContext;
        
        public ContextProvider()
        {
            _context = new ScheduleContext();
        }

        public static List<TEntity> GetContext<TEntity>(ScheduleContext? context = null) where TEntity : ProvidableEntity
        {
            SetContext(context);
            DbSet<TEntity> entities = _context.Set<TEntity>();
            return entities.ToList();
        }

        public List<TEntity> GetContext<TEntity>() where TEntity : ProvidableEntity => GetContext<TEntity>(this._localContext);

        public static bool TryUpdateEntity<TEntity>(TEntity entity, ScheduleContext? context = null) where TEntity : ProvidableEntity
        {
            SetContext(context);
            bool result = true;
            if (entity == null) result = false;
            try
            {
                _context.Update(entity);
            }
            catch (System.InvalidOperationException)
            {
                result = false;
            }
            return result;
        }

        public bool TryUpdateEntity<TEntity>(TEntity entity) where TEntity : ProvidableEntity => TryUpdateEntity(entity, this._localContext);

        public static bool TrySaveChanges(ScheduleContext? context = null)
        {
            SetContext(context);
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

        public bool TrySaveChanges() => TrySaveChanges(this._localContext);

        public static void CancelChanges(object? objectWithChanges, ScheduleContext? context = null)
        {
            SetContext(context);
            if (objectWithChanges == null) return;
            _context.Entry(objectWithChanges).Reload();
            _context.Update(objectWithChanges);
        }

        public void CancelChanges(object? objectWithChanges) => CancelChanges(objectWithChanges, this._localContext);

        private static void SetContext(ScheduleContext? context)
        {
            if (context == null)
            {
                _context = _globalContext;
                return;
            }
            _context = context;
        }
    }
}

