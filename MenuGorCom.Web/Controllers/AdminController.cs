// File: AdminController.cs
using Microsoft.AspNetCore.Mvc;
using MenuGorCom.Application.Interfaces;
using MenuGorCom.Application.DTOs;

namespace MenuGorCom.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public IActionResult AdminList()
        {
            var adminList = _adminService.GetAllAdmins();
            return View(adminList);
        }
    }
}
