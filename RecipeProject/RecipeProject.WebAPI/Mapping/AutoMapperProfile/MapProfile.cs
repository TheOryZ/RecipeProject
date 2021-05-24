using AutoMapper;
using RecipeProject.DTO.Dtos.AppRoleDtos;
using RecipeProject.DTO.Dtos.AppUserDtos;
using RecipeProject.DTO.Dtos.CategoryDtos;
using RecipeProject.DTO.Dtos.RecipeDtos;
using RecipeProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeProject.WebAPI.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AppRoleListDto, AppRole>().ReverseMap();

            CreateMap<AppUserListDto, AppUser>().ReverseMap();
            CreateMap<AppUserAddDto, AppUser>().ReverseMap();
            CreateMap<AppUserLoginDto, AppUser>().ReverseMap();

            CreateMap<CategoryListDto, Category>().ReverseMap();
            CreateMap<CategoryAddDto, Category>().ReverseMap();
            CreateMap<CategoryUpdateDto, Category>().ReverseMap();

            CreateMap<RecipeListDto, Recipe>().ReverseMap();
            CreateMap<RecipeAddDto, Recipe>().ReverseMap();
            CreateMap<RecipeUpdateDto, Recipe>().ReverseMap();
        }
    }
}
