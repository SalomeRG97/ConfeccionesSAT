using Interfaces.Repository.Base;
using Interfaces.Repository.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using Models.Models;
using Repository.Repositories;

namespace Repository.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ConfeccionesSATDbContext _context;
        private IInputRepository _inputRepository;

        public UnitOfWork(ConfeccionesSATDbContext context)
        {
            _context = context;
        }

        public IInputRepository InputRepository => _inputRepository ??= new InputRepository(_context);

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
