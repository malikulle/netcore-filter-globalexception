using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.Entities;

namespace Backend.Core.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetWithCategoryById(int ProductId);
    }
}
