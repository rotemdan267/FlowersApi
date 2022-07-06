using FlowersApi.DB;
using FlowersApi.DTO;
using FlowersApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowersApi.repos
{
    public class FlowersRepo : IFlowersRepo
    {
        private readonly FlowersContext _context;

        public FlowersRepo(FlowersContext flowersContext)
        {
            _context = flowersContext;
        }

        public async Task<List<FlowerModel>> GetAllFlowersAsync()
        {
            var records = await _context.Flowers.Select(f => new FlowerModel()
            {
                Id = f.Id,
                Name = f.Name,
                Description = f.Description,
                Color = f.Color,
                Price = f.Price,
                Size = f.Size
            }).ToListAsync();

            return records;
        }

        public async Task<FlowerModel> GetFlowerByIdAsync(int id)
        {
            var record = await _context.Flowers
                .Where(x => x.Id == id)
                .Select(f => new FlowerModel()
                {
                    Id = f.Id,
                    Name = f.Name,
                    Description = f.Description,
                    Color = f.Color,
                    Price = f.Price,
                    Size = f.Size
                }).FirstOrDefaultAsync();

            return record;
        }

        public async Task<int> AddFlowerAsync(FlowerModel flowerModel)
        {
            var flower = new Flower
            {
                Name = flowerModel.Name,
                Description = flowerModel.Description,
                Color = flowerModel.Color,
                Size = flowerModel.Size,
                Price = flowerModel.Price
            };
            _context.Flowers.Add(flower);
            await _context.SaveChangesAsync();

            return flower.Id;
        }

        public async Task UpdateFlowerAsync(int flowerId, FlowerModel modifiedFlower)
        {
            var flower = new Flower()
            {
                Id = flowerId,
                Name = modifiedFlower.Name,
                Description = modifiedFlower.Description,
                Color = modifiedFlower.Color,
                Price = modifiedFlower.Price,
                Size = modifiedFlower.Size
            };

            _context.Flowers.Update(flower);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteFlowerAsync(int flowerId)
        {
            var flower = new Flower { Id = flowerId };

            _context.Flowers.Remove(flower);

            await _context.SaveChangesAsync();

        }
    }
}
