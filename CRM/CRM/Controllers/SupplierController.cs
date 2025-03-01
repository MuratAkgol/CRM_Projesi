using CRM.LogicControl;
using DataLayer;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
            var suppliers = _context.tbl_suppliers.Include(x => x.User).Include(x => x.SupplierGroup).ToList();
            return View(suppliers);
        }
        public IActionResult AddSupplier()
        {
            ViewBag.Users = new SelectList(_context.tbl_users, "UserId", "UserName");
            ViewBag.SupplierGroups = new SelectList(_context.tbl_supplierGroups, "GroupId", "GroupName");
            return View(new Suppliers());
        }
        [HttpPost]
        public IActionResult AddSupplier(Suppliers supplier)
        {
            bool vknControl = vknControll.IsVKNV(supplier.TaxNumber);

            if (!string.IsNullOrEmpty(supplier.IdentityNumber) && supplier.IdentityNumber.Length > 0)
            {
                if (identiyControll.IsValidIdentity(supplier.IdentityNumber))
                {
                    _context.tbl_suppliers.Add(supplier);
                    _context.SaveChanges();
                    return Json(new
                    {
                        success = true,
                        redirectUrl = Url.Action("Details", new { id = supplier.SupplierId })
                    });
                }
                else
                {
                    return Json(new
                    {
                        success = false,
                        message = "T.c. Kimlik numarası doğru değil!"
                    });
                }

            }
            else
            {
                if (vknControl)
                {
                    _context.tbl_suppliers.Add(supplier);
                    _context.SaveChanges();

                    return Json(new
                    {
                        success = true,
                        redirectUrl = Url.Action("Details", new { id = supplier.SupplierId })
                    });
                }
                else
                {
                    return Json(new
                    {
                        success = false,
                        message = "Vergi numarası doğru değil!"
                    });
                }
            }
        }


        public async Task<IActionResult> Details(int id)
        {
            var context = _context.tbl_suppliers.FirstOrDefault(x => x.SupplierId.Equals(id));

            ViewBag.StatusOptions = new List<SelectListItem>
{
    new SelectListItem { Text = "Aktif", Value = "true", Selected =  context.Status},
    new SelectListItem { Text = "Pasif", Value = "false", Selected = !context.Status }
};
            var users = await _context.tbl_users
        .Select(u => new SelectListItem
        {
            Value = u.UserId.ToString(),
            Text = u.UserName
        }).ToListAsync();

            ViewBag.TypeOptions = new List<SelectListItem>
{
    new SelectListItem { Text = "Müşteri", Value = "Müşteri" },
    new SelectListItem { Text = "Tedarikçi", Value = "Tedarikçi" },
    new SelectListItem { Text = "Resmi", Value = "Resmi" },
    new SelectListItem { Text = "Diğer", Value = "Diğer" }
};

            // Seçili olanı işaretle
            foreach (var option in ViewBag.TypeOptions as List<SelectListItem>)
            {
                option.Selected = option.Value == context.Type;
            }

            ViewBag.Users = users;
            ViewBag.SupplierGroups = new SelectList(_context.tbl_supplierGroups, "GroupId", "GroupName");
            var supplier = await _context.tbl_suppliers.FirstOrDefaultAsync(x => x.SupplierId.Equals(id));
            return View(supplier);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateDetails(Suppliers supplier)
        {
            if (vknControll.IsVKNV(supplier.TaxNumber) || identiyControll.IsValidIdentity(supplier.IdentityNumber))
            {
                _context.tbl_suppliers.Update(supplier);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "İşlem başarıyla tamamlandı!";
                return RedirectToAction("Details", new { id = supplier.SupplierId });
            }
            else
            {
                TempData["FailMessage"] = "Vergi numarası ya da T.C. Kimlik No alanını tekrar kontrol ediniz!";
                return RedirectToAction("Details", new { id = supplier.SupplierId });
            }

        }
    }
}
