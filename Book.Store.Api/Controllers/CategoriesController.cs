using BookStore.Bussiness.Abstract;
using BookStore.Entities.DTOs.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Book.Store.Api.Controllers
{
    public class CategoriesController : BaseAdminController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _categoryService.GetAllAsync();
            if (result.IsSuccess) return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [AllowAnonymous]
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _categoryService.GetByIdAsync(id);
            if (result.IsSuccess) return Ok(result.Data);
            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryCreateDto category)
        {
            var result = await _categoryService.AddAsync(category);
            if (result.IsSuccess) return Created("", result);
            return BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdate)
        {
            var result = await _categoryService.UpdateAsync(categoryUpdate);
            if (result.IsSuccess) return NoContent();
            return BadRequest(result);
        }

        [HttpPut("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.DeleteAsync(id);
            if (result.IsSuccess) return NoContent();
            return BadRequest(result);
        }

    }
}
