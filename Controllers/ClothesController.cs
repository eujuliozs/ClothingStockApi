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
    public class ClothesController : ControllerBase
    {
        private readonly Repository repository;

        public ClothesController(Repository repo)
        {
            repository = repo;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            IEnumerable<Clothes> Clothes = await repository.GetAllAsync<Clothes>();
            return Ok(Clothes);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            Clothes query = repository.GetByIdAsync<Clothes>(id).Result;
            return Ok(query);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Clothes piece)
        {
            await repository.AddAsync(piece);
            return CreatedAtAction(nameof(Get),new { Id=piece.Id}, piece);
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult> Patch(int id,[FromQuery] Clothes? piece)
        {

            if(await repository.GetByIdAsync<Clothes>(id) is null)
            {
                return StatusCode(400);
            }
            await repository.PatchAsync(id, piece);

            return StatusCode(201, await repository.GetByIdAsync<Clothes>(id));
        }

        [HttpPut]
        public async Task<ActionResult> Put(Clothes piece)
        {
            if(piece is null)
            {
                return StatusCode(400);
            }

            await repository.AddAsync(piece);
            return CreatedAtAction(nameof(GetById), new {piece.Id}, piece);
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            Clothes piece = await repository.GetByIdAsync<Clothes>(id);
            if (piece == null)
            {
                return StatusCode(404, new { Message = "Not Entity In database with such id" });
            }
            await repository.DeleteAsync(piece);
            return StatusCode(204, piece);
        }

    }
}
