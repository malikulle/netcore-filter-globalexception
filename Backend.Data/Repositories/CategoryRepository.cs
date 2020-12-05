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
    public class CategoryRepository : Repository<Category>,ICategoryRepository
    {
        private AppDbContext appDbContext { get => Context as AppDbContext; }

        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Category> GetWithProductsByIdAsync(int CategoryId)
        {
            return await appDbContext.Categories.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == CategoryId);
        }
    }
}
