using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Radon.Server.Repositories;
using Radon.Server.Resources;
using Radon.Data.Queries;

namespace Radon.Server.Services
{
    public abstract class ResourceService<T> : IResourceService<T> where T : IResource
    {
        private readonly IResourceRepository<T> _repository;

        protected ResourceService(IResourceRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual bool Insert(T entity)
        {
            return _repository.Insert(entity);
        }

        public virtual bool InsertGraph(T entity)
        {
            return _repository.InsertGraph(entity);
        }

        public virtual bool InsertRange(IEnumerable<T> entities)
        {
            return _repository.InsertRange(entities);
        }

        public virtual bool InsertGraphRange(IEnumerable<T> entities)
        {
            return _repository.InsertGraphRange(entities);
        }

        public virtual IQueryable<T> SelectQuery(string query, params object[] parameters)
        {
            return _repository.SelectQuery(query, parameters);
        }

        public virtual IQueryable<T> Queryable()
        {
            return _repository.Queryable();
        }

        public virtual T Find(params object[] keyValues)
        {
            return _repository.Find(keyValues);
        }

        public virtual bool Update(T entity)
        {
            return _repository.Update(entity);
        }

        public virtual bool InsertOrUpdate(T entity)
        {
            return _repository.InsertOrUpdate(entity);
        }

        public virtual bool InsertOrUpdateGraph(T entity)
        {
            return _repository.InsertOrUpdateGraph(entity);
        }

        public virtual bool Delete(object id)
        {
            return _repository.Delete(id);
        }

        public virtual bool Delete(T entity)
        {
            return _repository.Delete(entity);
        }

        public virtual async Task<bool> InsertAsync(T entity)
        {
            return await _repository.InsertAsync(entity);
        }

        public virtual async Task<bool> InsertAsync(CancellationToken cancellationToken, T entity)
        {
            return await _repository.InsertAsync(cancellationToken, entity);
        }

        public virtual async Task<bool> InsertGraphAsync(T entity)
        {
            return await _repository.InsertGraphAsync(entity);
        }

        public virtual async Task<bool> InsertGraphAsync(CancellationToken cancellationToken, T entity)
        {
            return await _repository.InsertGraphAsync(cancellationToken, entity);
        }

        public virtual async Task<bool> InsertRangeAsync(IEnumerable<T> entities)
        {
            return await _repository.InsertRangeAsync(entities);
        }

        public virtual async Task<bool> InsertRangeAsync(CancellationToken cancellationToken, IEnumerable<T> entities)
        {
            return await _repository.InsertRangeAsync(cancellationToken, entities);
        }

        public virtual async Task<bool> InsertGraphRangeAsync(IEnumerable<T> entities)
        {
            return await _repository.InsertGraphRangeAsync(entities);
        }

        public virtual async Task<bool> InsertGraphRangeAsync(CancellationToken cancellationToken, IEnumerable<T> entities)
        {
            return await _repository.InsertGraphRangeAsync(cancellationToken, entities);
        }

        public virtual async Task<T> FindAsync(params object[] keyValues)
        {
            return await _repository.FindAsync(keyValues);
        }

        public virtual async Task<T> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            return await _repository.FindAsync(cancellationToken, keyValues);
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        public virtual async Task<bool> UpdateAsync(CancellationToken cancellationToken, T entity)
        {
            return await _repository.UpdateAsync(cancellationToken, entity);
        }

        public virtual async Task<bool> InsertOrUpdateAsync(T entity)
        {
            return await _repository.InsertOrUpdateAsync(entity);
        }

        public virtual async Task<bool> InsertOrUpdateAsync(CancellationToken cancellationToken, T entity)
        {
            return await _repository.InsertOrUpdateAsync(cancellationToken, entity);
        }

        public virtual async Task<bool> InsertOrUpdateGraphAsync(T entity)
        {
            return await _repository.InsertOrUpdateGraphAsync(entity);
        }

        public virtual async Task<bool> InsertOrUpdateGraphAsync(CancellationToken cancellationToken, T entity)
        {
            return await _repository.InsertOrUpdateGraphAsync(cancellationToken, entity);
        }

        public virtual async Task<bool> DeleteAsync(params object[] keyValues)
        {
            return await _repository.DeleteAsync(keyValues);
        }

        public virtual async Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            return await _repository.DeleteAsync(cancellationToken, keyValues);
        }

        public virtual IQueryFluent<T> Query(IQueryObject<T> queryObject)
        {
            return _repository.Query(queryObject);
        }

        public virtual IQueryFluent<T> Query(Expression<Func<T, bool>> query)
        {
            return _repository.Query(query);
        }

        public virtual IQueryFluent<T> Query()
        {
            return _repository.Query();
        }

        public virtual async Task<T> InsertAndReturnAsync(T entity)
        {
            return await _repository.InsertAndReturnAsync(entity);
        }

        public virtual async Task<T> UpdateAndReturnAsync(T entity)
        {
            return await _repository.UpdateAndReturnAsync(entity);
        }

        public Task<T> DeleteAndReturnAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}