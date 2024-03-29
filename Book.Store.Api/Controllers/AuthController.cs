﻿using BookStore.Bussiness.Abstract;
using BookStore.Core.DTO;
using BookStore.Core.Jwt;
using BookStore.Entities.DTOs.User;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Book.Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly JwtTokenGenerator _jwtTokenGenerator;

        public AuthController(IAuthService authService, JwtTokenGenerator jwtTokenGenerator)
        {
            _authService = authService;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(UserCreateDto userCreateDto)
        {
            var result = await _authService.RegisterAsync(userCreateDto);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var result = await _authService.GetUserAsync(userLoginDto.Email, userLoginDto.Password);
            if (result.IsSuccess)
            {
                var token = _jwtTokenGenerator.GenerateToken(
                    new UserReponseDto
                {
                    Email = result.Data.Email,
                    Id = result.Data.Id,
                    Role = result.Data.Role.Name
                });

                return Ok(token);
            }
            return BadRequest(result);
        }
    }
}
