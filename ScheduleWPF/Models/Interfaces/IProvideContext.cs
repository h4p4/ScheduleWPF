using Microsoft.EntityFrameworkCore;
using ScheduleWPF.Models.DataControllers;
using System;
using System.Collections.Generic;

namespace ScheduleWPF.Models.Interfaces
{
    public interface IProvideContext<TContext> where TContext : DbContext
    {
        public TContext Context { get; }
        public List<TEntity> GetContext<TEntity>() where TEntity : ProvidableEntity;
        public bool TryUpdateEntity<TEntity>(TEntity entity) where TEntity : ProvidableEntity;
        public bool TrySaveChanges();
        public void CancelChanges(object? objectWithChanges);

    }
}
