using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(ICategoryService categoryService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _categoryService = categoryService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            var mapper = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return Ok(mapper);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var entity = await _categoryService.GetByIdAsync(id);
            var map = _mapper.Map<CategoryDto>(entity);
            return Ok(map);
        }

        [ValidationFilters]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryDto model)
        {

            var entity = _mapper.Map<Category>(model);

            await _categoryService.AddAsync(entity);

            await _unitOfWork.CommitAsync();

            return Ok(entity);
        }

        [ValidationFilters]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CategoryDto model)
        {

            var category = _mapper.Map<Category>(model);

            _categoryService.Update(category);

            await _unitOfWork.CommitAsync();

            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            if (category == null)
                return BadRequest();

            _categoryService.Remove(category);

            await _unitOfWork.CommitAsync();

            return Ok();
        }

        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetWithProductById(int id)
        {
            var category = await _categoryService.GetWithProductsByIdAsync(id);

            if (category == null)
                return BadRequest();

            var map = _mapper.Map<CategoryWithProductDto>(category);
            return Ok(map);
        }
    }
}
