using ClothingApi.Data;
using ClothingApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace ClothingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            T_Shirt query = repository.GetByIdAsync<T_Shirt>(id).Result;
            return Ok(query);
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

            if(await repository.GetByIdAsync<T_Shirt>(id) is null)
            {
                return StatusCode(400);
            }
            await repository.PatchAsync(id, t_shirt);

            return StatusCode(201, await repository.GetByIdAsync<T_Shirt>(id));
        }

        [HttpPut]
        public async Task<ActionResult> Put(T_Shirt t_Shirt)
        {
            if(t_Shirt is null)
            {
                return StatusCode(400);
            }

            await repository.AddAsync(t_Shirt);
            return CreatedAtAction(nameof(GetById), new {t_Shirt.Id}, t_Shirt);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            T_Shirt T_Shirt = await repository.GetByIdAsync<T_Shirt>(id);
            if (T_Shirt == null)
            {
                return StatusCode(404, new { Message = "Not Entity In database with such id" });
            }
            await repository.DeleteAsync(T_Shirt);
            return StatusCode(204, T_Shirt);
        }

    }
}
