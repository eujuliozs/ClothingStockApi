using ClothingApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClothingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class T_ShirtsController : ControllerBase
    {
        private readonly Repository repository;

        public T_ShirtsController(Repository repo)
        {
            repository = repo;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            IEnumerable<T_Shirt> t_Shirts = await repository.GetAll<T_Shirt>();
            return Ok(t_Shirts);
        }

        [HttpPost]
        public async Task<ActionResult> Post(T_Shirt t_Shirt)
        {
            await repository.Add(t_Shirt);
            return CreatedAtAction(nameof(Get),new { Id=t_Shirt.Id}, t_Shirt);
        }

    }
}
