using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MongoDB.Driver;
using Pcf.GivingToCustomer.Core.Abstractions.Repositories;
using Pcf.GivingToCustomer.Core.Domain;

namespace Pcf.GivingToCustomer.DataAccess.Repositories
{
    public class EfRepository<T>
        : IRepository<T>
        where T: BaseEntity
    {
        protected IMongoCollection<T> _dbCollection;

        public EfRepository(DataContext dataContext, string collectionName)
        {
            _dbCollection = dataContext.Database.GetCollection<T>(collectionName);
        }
        
        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            var entities = await _dbCollection.FindAsync(x => true, cancellationToken: cancellationToken);

            return await entities.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _dbCollection.FindAsync(x => x.Id == id, cancellationToken: cancellationToken).Result.FirstOrDefaultAsync(cancellationToken: cancellationToken);

            return entity;
        }

        public async Task<IEnumerable<T>> GetRangeByIdsAsync(List<Guid> ids, CancellationToken cancellationToken)
        {
            var entities = await _dbCollection.FindAsync(x => ids.Contains(x.Id));
            return await entities.ToListAsync(cancellationToken);
        }

        public async Task<T> GetFirstWhere(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _dbCollection.FindAsync(predicate, cancellationToken: cancellationToken).Result.FirstOrDefaultAsync(cancellationToken: cancellationToken); 
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            var entities = await _dbCollection.FindAsync(predicate);

            return await entities.ToListAsync(cancellationToken);
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken)
        {
           await _dbCollection.InsertOneAsync(entity, cancellationToken: cancellationToken);
        }

        public async Task UpdateAsync(Guid id, T entity, CancellationToken cancellationToken)
        {
            await _dbCollection.ReplaceOneAsync(x => x.Id == id, entity);

        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await _dbCollection.DeleteOneAsync(x => x.Id == id, cancellationToken: cancellationToken);
        }       
    }
}