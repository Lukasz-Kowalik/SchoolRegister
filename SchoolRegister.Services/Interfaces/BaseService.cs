using SchoolRegister.DAL.EF;
using System;

namespace SchoolRegister.Services.Interfaces
{
    public abstract class BaseService
    {
        protected readonly ApplicationDbContext _dbContext;
        private bool _disposed;

        protected BaseService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _disposed = false;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _dbContext.Dispose();
            }

            _disposed = true;
        }
    }
}