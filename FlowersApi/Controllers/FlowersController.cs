using FlowersApi.DB;
using FlowersApi.DTO;
using FlowersApi.repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FlowersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowersController : ControllerBase
    {
        private readonly IFlowersRepo _flowersRepo;
        private readonly FlowersContext _context;

        public FlowersController(IFlowersRepo flowersRepo, FlowersContext flowersContext)
        {
            _flowersRepo = flowersRepo;
            _context = flowersContext;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllFlowers()
        {
            var books = await _flowersRepo.GetAllFlowersAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlowerById([FromRoute] int id)
        {
            var flower = await _flowersRepo.GetFlowerByIdAsync(id);

            if (flower is null)
            {
                return NotFound();
            }

            return Ok(flower);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewFlower([FromBody] FlowerModel flowerModel)
        {
            var id = await _flowersRepo.AddFlowerAsync(flowerModel);
            return CreatedAtAction(nameof(GetFlowerById), new { id = id, controller = "flowers" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFlower([FromRoute] int id, [FromBody] FlowerModel flowerModel)
        {
            await _flowersRepo.UpdateFlowerAsync(id, flowerModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlower([FromRoute] int id)
        {
            await _flowersRepo.DeleteFlowerAsync(id);
            return Ok();
        }
    }
}
