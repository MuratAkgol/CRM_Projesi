using BusinessLayer.Abstract;
using CRM.Helpers;
using CRM.Models;
using DataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRM.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly Context _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, Context context, ICurrentUserService currentUserService)
        {
            _logger = logger;
            _context = context;
            _currentUserService = currentUserService;
        }

        public IActionResult Index()
        {
            ViewBag.TotalSupp = _context.tbl_suppliers.Select(x=>x.SupplierId).Count();
            ViewBag.ComplatedTotalTasks = _context.tbl_tasks.Where(x => x.TaskStatus.Equals("Tamamlandı")).Count();
            var userName = _currentUserService.UserName;
            ViewBag.UserName = userName;
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