using Microsoft.EntityFrameworkCore;
using PortfolioWebsite.Data;
using PortfolioWebsite.Models;


namespace PortfolioWebsite.Repositories
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<PortfolioRepository> _logger;

        public PortfolioRepository(ApplicationDbContext dbContext, ILogger<PortfolioRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        
        public async Task<IEnumerable<PortfolioItem>> GetAllItemsAsync()
        {
            try
            {
                var items = await _dbContext.PortfolioItems.AsNoTracking().ToListAsync();
                _logger.LogInformation($"Fetched {items.Count} portfolio items.");
                return items;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching all portfolio items.");
                return Enumerable.Empty<PortfolioItem>();
            }
        }

      
        public async Task AddItemAsync(PortfolioItem item)
        {
            try
            {
                await _dbContext.PortfolioItems.AddAsync(item);
                await _dbContext.SaveChangesAsync();
                _logger.LogInformation("Added new portfolio item successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a new portfolio item.");
                throw;
            }
        }

      
        public async Task<PortfolioItem?> GetItemByIdAsync(int id)
        {
            try
            {
                return await _dbContext.PortfolioItems.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while fetching portfolio item with ID {id}.");
                return null;
            }
        }

    
        public async Task UpdateItemAsync(PortfolioItem item)
        {
            try
            {
                _dbContext.PortfolioItems.Update(item);
                await _dbContext.SaveChangesAsync();
                _logger.LogInformation($"Updated portfolio item with ID {item.Id} successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating portfolio item with ID {item.Id}.");
                throw;
            }
        }

       
        public async Task DeleteItemAsync(int id)
        {
            try
            {
                var item = await _dbContext.PortfolioItems.FindAsync(id);
                if (item != null)
                {
                    _dbContext.PortfolioItems.Remove(item);
                    await _dbContext.SaveChangesAsync();
                    _logger.LogInformation($"Deleted portfolio item with ID {id} successfully.");
                }
                else
                {
                    _logger.LogWarning($"Portfolio item with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting portfolio item with ID {id}.");
                throw;
            }
        }
    }
}
