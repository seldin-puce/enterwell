using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Invoice.Data.Context;
using Invoice.Service.IService;

namespace Invoice.Service.Service
{
    public class BaseService<TEntity, TRequest, TResponse, TKey>
        : IBaseService<TRequest, TResponse, TKey> where TEntity : class
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        protected BaseService(Context context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public virtual async Task<List<TResponse>> GetAll()
        {
            return _mapper.Map<List<TResponse>>(await _context.Set<TEntity>().ToListAsync());
        }

        public virtual async Task<TResponse> GetById(TKey id)
        {
            return _mapper.Map<TResponse>(await _context.Set<TEntity>().FindAsync(id));
        }

        public virtual async Task<TResponse> Create(TRequest entity)
        {
            TEntity newEntity = _mapper.Map<TEntity>(entity);
            _mapper.Map<TResponse>(_context.Set<TEntity>().Add(newEntity));
            await _context.SaveChangesAsync();
            return _mapper.Map<TResponse>(newEntity);
        }

        public virtual async Task<TResponse> Update(TKey id, TRequest entity)
        {
            TEntity dbEntity = await _context.Set<TEntity>().FindAsync(id);
            _context.Set<TEntity>().Attach(dbEntity ?? throw new InvalidOperationException("Entity does not exist!"));
            _mapper.Map(entity, dbEntity);
            await _context.SaveChangesAsync();
            return _mapper.Map<TResponse>(dbEntity);
        }

        public virtual async Task Delete(TKey id)
        {
            TEntity dbEntity = await _context.Set<TEntity>().FindAsync(id);
            _context.Set<TEntity>().Remove(dbEntity ?? throw new InvalidOperationException("Entity does not exist!"));
            await _context.SaveChangesAsync();
        }
    }
}
