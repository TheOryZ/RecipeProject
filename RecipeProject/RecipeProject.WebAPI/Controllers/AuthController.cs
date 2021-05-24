using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeProject.Business.Interfaces;
using RecipeProject.DTO.Dtos.AppUserDtos;
using RecipeProject.DTO.Dtos.Token;
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
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;
        private readonly IAppUserService _appUserService;
        public AuthController(IJwtService jwtService, IAppUserService appUserService, IMapper mapper)
        {
            _jwtService = jwtService;
            _mapper = mapper;
            _appUserService = appUserService;
        }

        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignIn(AppUserLoginDto appUserLoginDto)
        {
            var appUser = await _appUserService.FindByUserNameAsync(appUserLoginDto.UserName);
            if (appUser == null)
            {
                return BadRequest("Username or password is wrong.");
            }
            else
            {
                if(appUserLoginDto.Password == appUser.Password)
                {
                    var role = appUser.AppRole;
                    var token = _jwtService.GenerateJwtToken(appUser, role);
                    JwtAccessToken jwtAccessToken = new JwtAccessToken();
                    jwtAccessToken.token = token;
                    return Created("", jwtAccessToken);
                }
                return BadRequest("Username or password is wrong.");
            }
        }

        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignUp(AppUserAddDto appUserAddDto)
        {
            var appUser = await _appUserService.FindByUserNameAsync(appUserAddDto.UserName);
            if (appUser != null)
                return BadRequest($"{appUserAddDto.UserName} username is already taken");
            await _appUserService.AddAsync(_mapper.Map<AppUser>(appUserAddDto));
            return Created("", appUserAddDto);
        }

        [HttpGet("[action]")]
        [Authorize]
        public async Task<IActionResult> ActiveUser()
        {
            var user = await _appUserService.FindByUserNameAsync(User.Identity.Name);
            AppUserListDto appUserDto = new AppUserListDto()
            {
                Id = user.Id,
                UserName = user.UserName,
                Name = user.Name,
                AppRole = user.AppRole.RoleName
            };
            return Ok(appUserDto);
        }
    }
}
