using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.Entities;
using Backend.Core.Repository;
using Backend.Core.Services;
using Backend.Core.UnitOfWork;

namespace Backend.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IRepository<Product> repository, IUnitOfWork unitOfWork) : base(repository)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> GetWithCategoryById(int ProductId)
            => await _unitOfWork.Product.GetWithCategoryById(ProductId);
    }
}
