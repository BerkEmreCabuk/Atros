using Atros.Common.Enums;
using Atros.Common.Models;
using Atros.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Atros.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IBaseEntity, new()
    {
        private readonly AtrosDbContext _context;
        private DbSet<TEntity> _entities;
        private readonly ILogger<Repository<TEntity>> _logger;

        public Repository(
            AtrosDbContext context,
            ILogger<Repository<TEntity>> logger
            )
        {
            _context = context;
            _entities = context.Set<TEntity>();
            _logger = logger;
        }

        private DbSet<TEntity> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<TEntity>();
                }
                return _entities;
            }
        }

        public IQueryable<TEntity> Query() => Entities;
        public virtual Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate) => Entities.AnyAsync(predicate);
        public virtual Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate) => Entities.FirstOrDefaultAsync(predicate);
        public virtual Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate) => Entities.AsNoTracking().Where(predicate).ToListAsync<TEntity>();
        public virtual Task<List<TEntity>> GetListAsync() => Entities.AsNoTracking().ToListAsync<TEntity>();
        public async virtual Task<int> BulkSynchronizeAsync(List<TEntity> entities)
        {
            await _context.Set<TEntity>().BulkSynchronizeAsync<TEntity>(entities);
            var result = await _context.SaveChangesAsync();
            return result;
        }
        public virtual void Add(TEntity entity)
        {
            entity.Status = Status.Active;
            entity.CreateDate = DateTime.UtcNow;
            Entities.Add(entity);
        }

        public virtual void Modify(TEntity entity)
        {
            entity.UpdateDate = DateTime.UtcNow;
            if (_context.Entry(entity).State == EntityState.Detached)
                Entities.Update(entity);
        }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => await _context.SaveChangesAsync(cancellationToken);
    }
}
