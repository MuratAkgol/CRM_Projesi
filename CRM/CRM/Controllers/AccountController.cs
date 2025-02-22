using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using CRM.Helpers;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;

namespace CRM.Controllers
{
    public class AccountController : Controller
    {
        private readonly Context _context;

        public AccountController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(Users user)
        {
            if (await _context.tbl_users.AnyAsync(x => x.UserName == user.UserName || x.Email == user.Email))
            {
                ViewBag.Error = "Bu kullanıcı adı veya e-posta zaten kullanılıyor!";
                return View();
            }
            user.Password = PasswordHelper.HashPassword(user.Password);
            user.AdminApprove = false;
            user.IsActive = true;
            _context.tbl_users.Add(user);
            await _context.SaveChangesAsync();
            ViewBag.Message = "Kullanıcı başarıyla oluşturuldu!";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string username, string password, bool rememberMe)
        {

            var user = await _context.tbl_users.FirstOrDefaultAsync(u => u.UserName == username);

            if (user == null || !PasswordHelper.VerifyPassword(password, user.Password) || !user.IsActive || !user.AdminApprove)
            {
                ViewBag.Error = "Geçersiz kullanıcı adı veya şifre!";
                return View();
            }


            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, user.Role ?? "User"),
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
        };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties { IsPersistent = rememberMe };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            return RedirectToAction("Index", "Home");

        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
    }
}
