using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain;

namespace PromoCodeFactory.DataAccess.Repositories
{
    public abstract class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DbContext Context;
        private readonly DbSet<T> _entitySet;

        private static readonly char[] IncludeSeparator = [','];

        protected EfRepository(DbContext context)
        {
            Context = context;
            _entitySet = Context.Set<T>();
        }

        /// <summary>
        /// Получить сущность по Id.
        /// </summary>
        /// <param name="id"> Id сущности. </param>
        /// <param name="cancellationToken"></param>
        /// <returns> Cущность. </returns>
        public virtual async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken, string includes = null)
        {
            IQueryable<T> query = _entitySet;

            if (includes != null && includes.Any())
            {
                foreach (var includeEntity in includes.Split(IncludeSeparator, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeEntity);
                }
            }

           return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public virtual IQueryable<T> GetAll()
        {
            return _entitySet.AsNoTracking();
        }

        /// <summary>
        /// Запросить все сущности в базе.
        /// </summary>
        /// <param name="cancellationToken"> Токен отмены </param>
        /// <param name="asNoTracking"> Вызвать с AsNoTracking. </param>
        /// <returns> Список сущностей. </returns>
        public Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return _entitySet.AsNoTracking().ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Добавить в базу одну сущность.
        /// </summary>
        /// <param name="entity"> Сущность для добавления. </param>
        /// <returns> Добавленная сущность. </returns>
        public virtual async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
        {
            return (await _entitySet.AddAsync(entity, cancellationToken)).Entity;
        }

        /// <summary>
        /// Добавить в базу массив сущностей.
        /// </summary>
        /// <param name="entities"> Массив сущностей. </param>
        public virtual async Task AddRangeAsync(ICollection<T> entities, CancellationToken cancellationToken)
        {
            if (entities == null || !entities.Any())
            {
                return;
            }

            await _entitySet.AddRangeAsync(entities, cancellationToken);
        }


        /// <summary>
        /// Для сущности проставить состояние - что она изменена.
        /// </summary>
        /// <param name="entity"> Сущность для изменения. </param>
        public void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }


        /// <summary>
        /// Удалить сущность.
        /// </summary>
        /// <param name="id"> Id удалённой сущности. </param>
        /// <returns> Была ли сущность удалена. </returns>
        public virtual bool Delete(Guid id)
        {
            var obj = _entitySet.Find(id);
            if (obj == null)
            {
                return false;
            }

            _entitySet.Remove(obj);
            return true;
        }

        /// <summary>
        /// Сохранить изменения.
        /// </summary>
        public virtual void SaveChanges()
        {
            Context.SaveChanges();
        }

        /// <summary>
        /// Сохранить изменения.
        /// </summary>
        public virtual async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await Context.SaveChangesAsync(cancellationToken);
        }
    }
}