using ClothingApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

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
            IEnumerable<T_Shirt> t_Shirts = await repository.GetAllAsync<T_Shirt>();
            return Ok(t_Shirts);
        }

        [HttpPost]
        public async Task<ActionResult> Post(T_Shirt t_Shirt)
        {
            await repository.AddAsync(t_Shirt);
            return CreatedAtAction(nameof(Get),new { Id=t_Shirt.Id}, t_Shirt);
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult> Patch(int id,[FromQuery] T_Shirt? t_shirt)
        {
            PropertyInfo[] properties = typeof(T_Shirt).GetProperties();
            
            foreach(PropertyInfo prop in properties)
            {
                   
            }

            return Ok(t_shirt.Name);
        }

    }
}
