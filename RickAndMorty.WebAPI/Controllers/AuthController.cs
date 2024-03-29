﻿using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RickAndMorty.Data.Entities;
using RickAndMorty.Data.Repositories.AuthenticationServices;
using RickAndMorty.Services.Models.UserModels;

namespace RickAndMorty.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationServices _authservice;
        private readonly IMapper _mapper;

        public AuthController(IAuthenticationServices authservice, IMapper mapper)
        {
            _authservice = authservice;
            _mapper = mapper;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterModel userRegisterModel)
        {
            if (userRegisterModel is null)
                return BadRequest("UserRegisterModel objesi null olamaz");

            var userMap = _mapper.Map<User>(userRegisterModel);

            var userRegister = await _authservice.RegisterAsync(userMap);
            if (userRegister is null)
            {
                return BadRequest("Girilen UserName zaten kullanımda");

            }
            var userRegisterMap = _mapper.Map<UserRegisterModel>(userRegister);

            return Ok(userRegisterMap);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (loginModel is null)
                return BadRequest("LoginModel objesi null olamaz");

            var userMap = _mapper.Map<User>(loginModel);
            var userLogin = await _authservice.LoginAsync(userMap);
            var userMapLogin = _mapper.Map<UserModel>(userLogin);

            if (userLogin is null)
                return NotFound("geçersiz username veya password");

            return Ok(userMapLogin);
        }
    }
}
