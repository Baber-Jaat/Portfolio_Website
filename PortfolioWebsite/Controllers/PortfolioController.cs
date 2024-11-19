using Microsoft.AspNetCore.Mvc;
using PortfolioWebsite.Repositories;

namespace PortfolioWebsite.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly IPortfolioRepository _repository;
        private readonly ILogger<PortfolioController> _logger;

        public PortfolioController(IPortfolioRepository repository, ILogger<PortfolioController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        
        public async Task<IActionResult> Index()
        {
            try
            {
               
                var items = await _repository.GetAllItemsAsync();

                
                _logger.LogInformation($"Retrieved {items.Count()} portfolio items.");

                
                return View("~/Views/Portfolio/Index.cshtml", items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching portfolio items.");
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        
        public IActionResult Privacy()
        {
            try
            {
               
                return View("~/Views/Portfolio/Privacy.cshtml");
            }
            catch (Exception ex)
            {
                
                _logger.LogError(ex, "An error occurred while fetching the Privacy page.");

                
                return View("~/Views/Shared/Error.cshtml");
            }
        }


        public IActionResult Contact()
        {
            return View(); 
        }

    }
}
