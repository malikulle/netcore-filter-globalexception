using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.Entities;
using Backend.Core.Repository;
using Backend.Core.Services;
using Backend.Core.UnitOfWork;

namespace Backend.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IRepository<Category> repository, IUnitOfWork unitOfWork) : base(repository)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Category> GetWithProductsByIdAsync(int CategoryId)
        {
            return await _unitOfWork.Category.GetWithProductsByIdAsync(CategoryId);
        }
    }
}
