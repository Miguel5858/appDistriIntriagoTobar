using ECommerce_NetCore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_NetCore.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        public readonly List<Category> _caterogyListServicio = new();

        public BaseApiController(List<Category> caterogyListServicio)
        {
            _caterogyListServicio = caterogyListServicio;
        }

       /* [HttpGet]
        public List<Category> GetCategory()
        {

            List<Category> caterogyListServicio = new List<Category>();
            
            Category category = new Category();
            category.Id = "1";//Guid.NewGuid().ToString();
            category.Name = "Categoria 1";

            Category category2 = new Category();
            category2.Id = "2"; Guid.NewGuid().ToString();
            category2.Name = "Categoria 2";


            Category category3 = new Category();
            category3.Id = "3"; // Guid.NewGuid().ToString();
            category3.Name = "Categoria 3";


            caterogyListServicio.Add(category);
            caterogyListServicio.Add(category2);
            caterogyListServicio.Add(category3);

            return caterogyListServicio;
        }*/

        [HttpGet]
        public IActionResult GetCategory()
        {
            return Ok(_caterogyListServicio);
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult GetCategory(string id)
        {
            var result = _caterogyListServicio.FirstOrDefault(x => x.Id == id);
            //Where(p => p.Id == id).ToList();

            if (result == null)
            {
                return BadRequest(result);
            }
            else
            {

                return Ok(result);
            }
        }

        [HttpPost]
        public IActionResult PostCategory([FromBody] ParametroRequest request)
        {
            Category category = new();
            category.Id = Guid.NewGuid().ToString();
            category.Name = request.Name;
            category.Description = request.Description;

            _caterogyListServicio.Add(category);
            return Ok(_caterogyListServicio);
        }



        [HttpPut]
        [Route("{id}")]
        public IActionResult PutCategory(string id, [FromBody] ParametroRequest request)
        {
            var result = _caterogyListServicio.FirstOrDefault(x => x.Id == id);
            if (result == null)
            {
                return NotFound(id);
            }

            result.Description = request.Description;
            result.Name = request.Name;

            return Ok(_caterogyListServicio);
        }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteCategory(string id)
        {
            var result = _caterogyListServicio.FirstOrDefault(x => x.Id == id);
            if (result == null)
            {
                return NotFound(id);
            }

            _caterogyListServicio.Remove(result);

            return Ok(_caterogyListServicio);
        }



    }
}
