using DataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [Authorize]
    public class SupplierController : Controller
    {
        private readonly Context _context;

        public SupplierController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var suppliers = _context.tbl_suppliers.ToList();
            return View(suppliers);
        }
    }
}
