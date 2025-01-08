using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProniaOnion.Application.Abstractions.Services;

namespace ProniaOnion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
       
            private readonly IProductService _service;
            public ProductsController(IProductService service)
            {
                _service = service;
            }
            [HttpGet]
            public async Task<IActionResult> Get(int page = 1, int take = 3)
            {
                return Ok(await _service.GetAll(page, take));
            }
            [HttpGet("{Id}")]
            public async Task<IActionResult> Get(int Id)
            {
                if (Id < 1) return BadRequest();
                var productdto = await _service.GetByIdAsync(Id);
                if (productdto == null) return NotFound();
                return Ok(productdto);
            }
        }
    }


