using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProniaOnion.Application;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.BlogDto;


namespace ProniaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService _service;
        private readonly IValidator<CreateBlogDto> _validator;
        public BlogsController(IBlogService service, IValidator<CreateBlogDto> validator)
        {
            _validator = validator;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int take = 3)
        {
            return Ok(await _service.GetAllAsync(page, take));
        }

        [HttpGet("{Id}")]

        public async Task<IActionResult> Get(int Id)
        {
            if (Id < 1) return BadRequest();
            var blogDto = await _service.GetbyIdAsync(Id);
            if (blogDto == null) return NotFound();
            return Ok(blogDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateBlogDto blogDto)
        {
            await _service.CreateAsync(blogDto);
            return NoContent();
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, [FromForm] UpdateBlogDto blogDto)
        {
            if (Id < 1) return BadRequest();
            await _service.UpdateAsync(Id,blogDto);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id < 1) return BadRequest();
            await _service.DeleteAsync(Id);
            return NoContent();
        }
    }
}
