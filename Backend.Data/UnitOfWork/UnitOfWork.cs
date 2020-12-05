using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.Repository;
using Backend.Core.UnitOfWork;
using Backend.Data.Context;
using Backend.Data.Repositories;

namespace Backend.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IProductRepository Product => new ProductRepository(_appDbContext);
        public ICategoryRepository Category => new CategoryRepository(_appDbContext);
        public IPersonRepository Person => new PersonRepository(_appDbContext);

        public async Task CommitAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }

        public void Commit()
        {
            _appDbContext.SaveChanges();
        }
    }
}
