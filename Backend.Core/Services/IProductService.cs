using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.Entities;

namespace Backend.Core.Services
{
    public interface IProductService : IService<Product>
    {
        Task<Product> GetWithCategoryById(int ProductId);

    }
}
