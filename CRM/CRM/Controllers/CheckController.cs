using BusinessLayer.Concrate;
using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    public class CheckController : Controller
    {
        private readonly Context _checkManager;

        public CheckController(Context checkManager)
        {
            _checkManager = checkManager;
        }

        public IActionResult Index()
        {
            var checks = _checkManager.tbl_checks.ToList();
            return View(checks);
        }
    }
}
