using ECommerce_NetCore.Dto.Request;
using ECommerce_NetCore.Services.Interfaces;
using ECommerceAPI.Dto.Request;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_NetCore.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        //INYECCION DE DEPENDENCIA DE SERVICIO
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _service.ListAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProduct(string id)
        {
            var response = await _service.GetAsync(id);

            if (!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> PostProducts([FromBody] ProductRequest request)
        {
            var response = await _service.CreateAsync(request);

            return CreatedAtAction("GetProducts", new
            {
                id = response.Result
            }, response);
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> PutProducts(string id, [FromBody] ProductRequest request)
        {
            return Ok(await _service.UpdateAsync(id, request));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProducts(string id)
        {
            return Ok(await _service.DeleteAsync(id));
        }

    }
}
