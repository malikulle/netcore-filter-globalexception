using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Backend.API.Filters;
using Backend.API.Models;
using Backend.Core.Entities;
using Backend.Core.Services;
using Backend.Core.UnitOfWork;

namespace Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productService = productService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetAllAsync();

            var map = _mapper.Map<IEnumerable<ProductDto>>(products);

            return Ok(map);
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            var product = await _productService.GetByIdAsync(id);

            var map = _mapper.Map<ProductDto>(product);

            return Ok(map);
        }

        [ValidationFilters]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDto model)
        {
            var entity = _mapper.Map<Product>(model);

            await _productService.AddAsync(entity);
            await _unitOfWork.CommitAsync();

            return Ok(entity);
        }

        [ValidationFilters]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id,[FromBody] ProductDto model)
        {
            var entity = _mapper.Map<Product>(model);

             _productService.Update(entity);
            await _unitOfWork.CommitAsync();

            return Ok(entity);
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var entity = await _productService.GetByIdAsync(id);

            _productService.Remove(entity);

            await _unitOfWork.CommitAsync();
            return Ok();
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}/category")]
        public async Task<IActionResult> GetProductWithCategory([FromRoute] int id)
        {
            var product = await _productService.GetWithCategoryById(id);

            var map = _mapper.Map<ProductWithCategoryDto>(product);

            return Ok(map);
        }
    }
}
 