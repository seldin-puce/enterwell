﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Invoice.Service.IService
{
    public interface IBaseService< TRequest, TResponse, TKey>
    {
        Task<List<TResponse>> GetAll();
        Task<TResponse> GetById(TKey id);
        Task<TRequest> GetRequestTypeById(TKey id);
        Task<TResponse> Create(TRequest entity);
        Task<TResponse> Update(TRequest entity, TKey id);
        Task Delete(TKey id);
    }
}
