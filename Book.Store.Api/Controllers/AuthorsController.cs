using BookStore.Bussiness.Abstract;
using BookStore.Entities.DTOs.Author;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Store.Api.Controllers
{

    public class AuthorsController : BaseAdminController
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _authorService.GetAllAsync();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AuthorCreateDto authorCreateDto)
        {
            var result = await _authorService.AddAsync(authorCreateDto);
            return result.IsSuccess ? Created("", result) : BadRequest(result);
        }
    }
}
