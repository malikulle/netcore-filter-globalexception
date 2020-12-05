using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.Repository;

namespace Backend.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }
        IPersonRepository Person { get; }
        Task CommitAsync();
        void Commit();
    }
}
