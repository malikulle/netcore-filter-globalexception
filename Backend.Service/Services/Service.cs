using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.Repository;
using Backend.Core.Services;
using Backend.Core.UnitOfWork;

namespace Backend.Service.Services
{
    public class Service <TEntity> : IService<TEntity> where TEntity : class,new()
    {
        private readonly IRepository<TEntity> _repository;

        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<TEntity> GetByIdAsync(int Id)
            => await _repository.GetByIdAsync(Id);

        public async Task<IEnumerable<TEntity>> GetAllAsync()
            => await _repository.GetAllAsync();

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
            => _repository.Find(predicate);

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
            => await _repository.SingleOrDefaultAsync(predicate);

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _repository.AddRangeAsync(entities);
            return entities;
        }

        public void Remove(TEntity entity)
            => _repository.Remove(entity);

        public void RemoveRange(IEnumerable<TEntity> entities)
            => _repository.RemoveRange(entities);

        public TEntity Update(TEntity entity)
            => _repository.Update(entity);

    }
}

