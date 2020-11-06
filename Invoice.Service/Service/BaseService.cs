using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Invoice.Data.Context;
using Invoice.Service.IService;

namespace Invoice.Service.Service
{
    public class BaseService<TEntity, TRequest, TResponse, TKey>
        : IBaseService<TRequest, TResponse, TKey> where TEntity : class
    {

        public virtual async Task<List<TResponse>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> GetById(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> Create(TRequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> Update(TKey id, TRequest entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(TKey id)
        {
            throw new NotImplementedException();
        }
    }
}
