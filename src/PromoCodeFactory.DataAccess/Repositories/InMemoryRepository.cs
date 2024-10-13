using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain;
namespace PromoCodeFactory.DataAccess.Repositories
{
    public class InMemoryRepository<T>: IRepositoryOld<T> where T: BaseEntity
    {
        protected IEnumerable<T> Data { get; set; }

        public InMemoryRepository(IEnumerable<T> data)
        {
            Data = data;
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            return Task.FromResult(Data);
        }

        public Task<T> GetByIdAsync(Guid id)
        {
            return Task.FromResult(Data.FirstOrDefault(x => x.Id == id));
        }

        public Task AddAsync(T entity)
        {
            List<T> currentlist = Data as List<T>;
            currentlist.Add(entity);

            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
            List<T> currentlist = Data as List<T>;
            currentlist.RemoveAll(x => x.Id == id);

            return Task.CompletedTask;
        }

        public Task UpdateAsync(T entity)
        {
            var dataList = Data.ToList();
            var itemIndex = dataList.FindIndex(x => x.Id == entity.Id);

            if (itemIndex != -1)
            {
                dataList[itemIndex] = entity;
            }
            Data = dataList;

            return Task.CompletedTask;
        }
    }
}