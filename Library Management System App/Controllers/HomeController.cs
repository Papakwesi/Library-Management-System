using Library_Management_System_App.Models;
using LibraryManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Library_Management_System_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.totalBooks = _context.Books.Count();
            ViewBag.totalQuantity = _context.Books.Sum(b => b.Quantity);
            ViewBag.activeBorrowers = _context.BorrowRecords.Count(b => b.ReturnDate == null);

            var overdueCount = _context.BorrowRecords
                .Count(b => b.DueDate < DateTime.Now);

            ViewBag.OverdueCount = overdueCount;

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
