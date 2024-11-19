using PortfolioWebsite.Models;


namespace PortfolioWebsite.Repositories
{
    public interface IPortfolioRepository
    {
        Task<IEnumerable<PortfolioItem>> GetAllItemsAsync(); 
        Task AddItemAsync(PortfolioItem item);
        Task<PortfolioItem> GetItemByIdAsync(int id);
        Task UpdateItemAsync(PortfolioItem item);
        Task DeleteItemAsync(int id);
    }
}
