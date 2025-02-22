using BusinessLayer.Abstract;
using CRM.Helpers;
using DataLayer;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly Context _context;
        private readonly ICurrentUserService _currentUserService;

        public TaskController(Context context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public IActionResult Index()
        {
            if (_currentUserService == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var users = _context.tbl_users.ToDictionary(u => u.UserId, u => u.UserName);
            ViewBag.Users = users;
            ViewBag.Role = _currentUserService.UserRole;
            ViewBag.UserId = _currentUserService.UserId;

            var tasks = _currentUserService.UserRole == "Admin"
                ? _context.tbl_tasks.ToList()
                : _context.tbl_tasks.Where(x => x.TaskOwnerId == _currentUserService.UserId).ToList();

            return View(tasks);
        }
        [HttpPost]
        public IActionResult Index(Tasks task)
        {
            task.TaskStatus = "Beklemede";
            task.TaskCreatorId = _currentUserService.UserId;
            //task.TaskOwnerId = _currentUserService.UserId;
            _context.Add(task);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult UpdateStatus(int id)
        {
            var taskStatus = _context.tbl_tasks.FirstOrDefault(x => x.TaskId.Equals(id));

            if (taskStatus.TaskStatus == "Beklemede")
            {
                taskStatus.TaskStatus = "Devam Ediyor";
            }
            else
            {
                taskStatus.TaskStatus = "Tamamlandı";
            }
            _context.Update(taskStatus);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
