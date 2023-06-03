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
    public class ShortsController : ControllerBase
    {
        private readonly Repository repository;

        public ShortsController(Repository repo)
        {
            repository = repo;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            IEnumerable<Short> tShorts = await repository.GetAllAsync<Short>();
            return Ok(tShorts);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            Short query = repository.GetByIdAsync<Short>(id).Result;
            return Ok(query);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Short Shorts)
        {
            await repository.AddAsync(Shorts);
            return CreatedAtAction(nameof(Get), new { Id = Shorts.Id }, Shorts);
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult> Patch(int id, [FromQuery] Short? Shorts)
        {
            PropertyInfo[] properties = typeof(Short).GetProperties();

            if (await repository.GetByIdAsync<Short>(id) is null)
            {
                return StatusCode(400);
            }
            await repository.PatchAsync(id, Shorts);

            return StatusCode(201, await repository.GetByIdAsync<Short>(id));
        }

        [HttpPut]
        public async Task<ActionResult> Put(Short Shorts)
        {
            if (Shorts is null)
            {
                return StatusCode(400);
            }

            await repository.AddAsync(Shorts);
            return CreatedAtAction(nameof(GetById), new { Shorts.Id }, Shorts);
        }
    }
}
