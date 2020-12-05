using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.Entities;
using Backend.Core.Repository;
using Backend.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data.Repositories
{
    public class ProductRepository : Repository<Product> , IProductRepository
    {
        private AppDbContext appDbContext {get => Context as AppDbContext;}
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Product> GetWithCategoryById(int ProductId)
        {
            return await appDbContext.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == ProductId);
        }
    }
}
