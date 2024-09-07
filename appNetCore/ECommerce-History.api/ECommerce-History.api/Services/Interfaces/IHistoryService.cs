using ECommerce_History.api.Dto;
namespace ECommerce_History.api.Services.Interfaces
{
    public interface IHistoryService
    {
        Task<List<CategoryHistoryDto>> ListAsync();


        Task<string> CreateAsync(CategoryDto categoryHistory);
    }
}
