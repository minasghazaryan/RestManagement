using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestManagement.DataAccess;
using RestManagement.DataAccess.Entities;
using RestManagement.Service.Services.Interfaces;

namespace RestManagement.Service
{
    public class BaseService : IDisposable
    {
        protected readonly AppDbContext _context;
        protected readonly IMapper _mapper;
        protected readonly ICurrentCallContext _currentCallContext;

        private bool disposedValue;

        public BaseService(AppDbContext context, IMapper mapper, ICurrentCallContext currentCallContext)
        {
            _context = context;
            _mapper = mapper;
            _currentCallContext = currentCallContext;
        }


        public Task<int> SaveChangesAsync<T>(T entity,EntityState entityState = EntityState.Added) where T : BaseEntity
        {
            _context.Entry<T>(entity).State = entityState;
            return _context.SaveChangesAsync(_currentCallContext.UserId, _currentCallContext.UtcNow);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
