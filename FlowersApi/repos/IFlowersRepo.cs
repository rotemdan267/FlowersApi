using FlowersApi.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowersApi.repos
{
    public interface IFlowersRepo
    {
        Task<List<FlowerModel>> GetAllFlowersAsync();
        Task<FlowerModel> GetFlowerByIdAsync(int id);
        Task<int> AddFlowerAsync(FlowerModel flowerModel);
        Task UpdateFlowerAsync(int flowerId, FlowerModel modifiedFlower);
        Task DeleteFlowerAsync(int flowerId);


    }
}