using Microsoft.AspNetCore.Mvc;
using PortfolioWebsite.Models;
using PortfolioWebsite.Data;
using System.Diagnostics;


namespace PortfolioWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

       
        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

       
        [HttpPost]
        public async Task<IActionResult> Contact(string name, string email, string subject, string message)
        {
            if (ModelState.IsValid)
            {
                var contactMessage = new ContactMessage
                {
                    Name = name,
                    Email = email,
                    Subject = subject,
                    Message = message
                };

               
                _context.ContactMessages.Add(contactMessage);
                await _context.SaveChangesAsync();

                
                TempData["SuccessMessage"] = "Thank you for reaching out! We'll get back to you soon.";

               
                return RedirectToAction("Contact");
            }

            
            return View("~/Views/Portfolio/Contact.cshtml");
        }

        
        [HttpGet]
        public IActionResult Contact()
        {
            return View("~/Views/Portfolio/Contact.cshtml");
        }

    
        public IActionResult ViewMessages()
        {
            var messages = _context.ContactMessages.ToList();
            return View("~/Views/Portfolio/ViewMessages.cshtml", messages);
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
