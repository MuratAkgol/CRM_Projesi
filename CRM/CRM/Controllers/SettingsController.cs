﻿using DataLayer;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        private readonly Context _context;

        public SettingsController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UserPermision()
        {
            var users = _context.tbl_users.ToList();
            return View(users);
        }
        [HttpPost]
        public IActionResult Approve(int id)
        {
            var user = _context.tbl_users.FirstOrDefault(x=>x.UserId.Equals(id));
            user.AdminApprove = true;
            _context.tbl_users.Update(user);
            _context.SaveChanges();
            
            return RedirectToAction("UserPermision");
        }
        public IActionResult AddGroup()
        {
            var groups = _context.tbl_supplierGroups.ToList();
            return View(groups);  
        }
        [HttpPost]
        public IActionResult AddGroup(SupplierGroup group) {
            _context.tbl_supplierGroups.Add(group);
            _context.SaveChanges();
            return RedirectToAction("AddGroup");
        }
    }
}
