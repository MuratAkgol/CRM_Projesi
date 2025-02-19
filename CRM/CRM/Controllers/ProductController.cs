using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    public class ProductController : Controller
    {
        private readonly Context _context;

        public ProductController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.tbl_products.ToList(); // DbSet ismine dikkat!
            return View(products);
        }
    }
}
