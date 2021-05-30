using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeProject.Business.Interfaces;
using RecipeProject.Core.StringInfos;
using RecipeProject.DTO.Dtos.RecipeDtos;
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
    public class RecipesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRecipeService _recipeService;
        public RecipesController(IRecipeService recipeService, IMapper mapper)
        {
            _mapper = mapper;
            _recipeService = recipeService;
        }

        [HttpGet]
        [Authorize(Roles = RoleInfos.Admin + "," + RoleInfos.Moderator)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<RecipeListDto>>(await _recipeService.GetAllAsync()));
        }
        [HttpGet("{id}")]
        [Authorize(Roles = RoleInfos.Admin + "," + RoleInfos.Moderator)]
        public async Task<IActionResult> FindById(string id)
        {
            var recipe = await _recipeService.FindByIdAsync(id);
            if(recipe != null)
                return Ok(_mapper.Map<RecipeListDto>(recipe));
            return BadRequest("Recipe not found");
        }
        [HttpPost]
        [Authorize(Roles = RoleInfos.Moderator)]
        [ValidModel]
        public async Task<IActionResult> Add(RecipeAddDto recipeAddDto)
        {
            await _recipeService.AddAsync(_mapper.Map<Recipe>(recipeAddDto));
            return Created("", recipeAddDto);
        }
        [HttpPut]
        [Authorize(Roles = RoleInfos.Moderator)]
        [ValidModel]
        public async Task<IActionResult> Update(string id, RecipeUpdateDto recipeUpdateDto)
        {
            var recipe = await _recipeService.FindByIdAsync(id);
            if(recipe != null)
            {
                await _recipeService.UpdateAsync(id, _mapper.Map<Recipe>(recipeUpdateDto));
                return NoContent();
            }
            return BadRequest("Recipe not found");
                
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = RoleInfos.Moderator)]
        public async Task<IActionResult> Remove(string id)
        {
            var recipe = await _recipeService.FindByIdAsync(id);
            if (recipe != null)
            {
                await _recipeService.RemoveAsync(id);
                return NoContent();
            }
            return BadRequest("Recipe not found");
        }

    }
}
