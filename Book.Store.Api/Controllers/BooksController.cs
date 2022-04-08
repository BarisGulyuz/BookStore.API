using BookStore.Bussiness.Abstract;
using BookStore.Entities.DTOs.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Store.Api.Controllers
{

    public class BooksController : BaseAdminController
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll(int categoryId, int authorId, int pageSize = 10, int pageNumber = 1)
        {
            var result = await _bookService.GetAllAsync(categoryId, authorId, pageSize, pageNumber);
            return result.IsSuccess ? Ok(result.Data) : BadRequest(result);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _bookService.GetByIdAsync(id);
            return result.IsSuccess ? Ok(result.Data) : BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] BookCreateDto bookCreateDto)
        {
            var result = await _bookService.AddAsync(bookCreateDto);
            return result.IsSuccess ? Created("", result) : BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] BookUpdateDto bookUpdateDto)
        {
            var result = await _bookService.UpdateAsync(bookUpdateDto);
            return result.IsSuccess ? NoContent() : BadRequest(result);
        }
        [HttpPut("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _bookService.DeleteAsync(id);
            return result.IsSuccess ? NoContent() : BadRequest(result);
        }
        [HttpDelete]
        public async Task<IActionResult> HardDelete(int id)
        {
            var result = await _bookService.HardDelete(id);
            return result.IsSuccess ? NoContent() : BadRequest(result);
        }

    }
}
