using appDist.Event.MQ.Src.Bus;
using ECommerce_NetCore.Dto.Request;
using ECommerce_NetCore.Dto.Response;
using ECommerce_NetCore.Messages.Commands;
using ECommerce_NetCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;
        private readonly IEventBus _eventBus;

        public CategoriesController(ICategoryService service, IEventBus eventBus)
        {
            _service = service;
            _eventBus = eventBus;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _service.ListAsync());
        }

        [HttpGet]
        [Route("id/{id?}")]
        public async Task<IActionResult> GetCategories(string id)
        {
            var response = await _service.GetAsync(id);

            if (!response.Success)
            {
                return NotFound(response);
            }

            await _eventBus.SendCommand(new TransactionHistoryCreateCommand(response.Result));
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> PostCategories([FromBody] CategoryRequest request)
        {
            var response = await _service.CreateAsync(request);

            return CreatedAtAction("GetCategories", new
            {
                id = response.Result
            }, response);
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> PutCategories(string id, [FromBody] CategoryRequest request)
        {
            return Ok(await _service.UpdateAsync(id, request));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCategories(string id)
        {

            var categoriaD = await _service.GetAsync(id);

            //var response = new BaseResponse<string>();

            var response = await _service.DeleteAsync(id);

            if (response.Success)
            {

                await _eventBus.SendCommand(new TransactionHistoryCreateCommand(categoriaD.Result));
                return Ok(response);
            }
            else {

                return BadRequest(response);
            }


           
        }

    }

}