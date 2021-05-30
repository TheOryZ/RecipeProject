using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeProject.Business.Interfaces;
using RecipeProject.Core.StringInfos;
using RecipeProject.DTO.Dtos.CategoryDtos;
using RecipeProject.Entities.Concrete;
using RecipeProject.WebAPI.CustomFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<CategoryListDto>>(await _categoryService.GetAllAsync()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(string id)
        {
            var category = await _categoryService.FindByIdAsync(id);
            if (category != null)
                return Ok(_mapper.Map<CategoryListDto>(category));
            return BadRequest("Category not found");
        }
        [HttpPost]
        [Authorize(Roles = RoleInfos.Admin)]
        [ValidModel]
        public async Task<IActionResult> Add(CategoryAddDto categoryAddDto)
        {
            await _categoryService.AddAsync(_mapper.Map<Category>(categoryAddDto));
            return Created("", categoryAddDto);
        }
        [HttpPut]
        [Authorize(Roles = RoleInfos.Admin)]
        [ValidModel]
        public async Task<IActionResult> Update(string id, CategoryUpdateDto categoryUpdateDto)
        {
            var recipe = await _categoryService.FindByIdAsync(id);
            if (recipe != null)
            {
                await _categoryService.UpdateAsync(id, _mapper.Map<Category>(categoryUpdateDto));
                return NoContent();
            }
            return BadRequest("Category not found");

        }
        [HttpDelete("{id}")]
        [Authorize(Roles = RoleInfos.Admin)]
        public async Task<IActionResult> Remove(string id)
        {
            var category = await _categoryService.FindByIdAsync(id);
            if (category != null)
            {
                await _categoryService.RemoveAsync(id);
                return NoContent();
            }
            return BadRequest("Category not found");
        }
    }
}
