using System.Collections.Generic;
using System.Threading.Tasks;

namespace Invoice.Service.IService
{
    public interface IBaseService<in TRequest, TResponse, in TKey>
    {
        Task<List<TResponse>> GetAll();
        Task<TResponse> GetById(TKey id);
        Task<TResponse> Create(TRequest entity);
        Task<TResponse> Update(TKey id, TRequest entity);
        Task Delete(TKey id);
    }
}
