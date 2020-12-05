using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.Entities;

namespace Backend.Core.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int CategoryId);
    }
}
