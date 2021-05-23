using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeProject.Business.Interfaces;
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
        private readonly IMapper _mapper;
        private readonly IAppUserService _appUserService;
        public AuthController(IAppUserService appUserService, IMapper mapper)
        {
            _mapper = mapper;
            _appUserService = appUserService;
        }
    }
}
