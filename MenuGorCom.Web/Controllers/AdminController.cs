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

        // Admin Listesi
        [HttpGet]
        public IActionResult AdminList()
        {
            var adminList = _adminService.GetAllAdmins();
            return View(adminList); // AdminList.cshtml'e veri gönderiliyor
        }

        // Admin Detay Görüntüleme
        [HttpGet]
        public IActionResult AdminDetails(int id)
        {
            var admin = _adminService.GetAdminById(id);
            if (admin == null)
            {
                return NotFound();
            }
            return View(admin); // AdminDetails.cshtml'e veri gönderiliyor
        }

        // Admin Ekleme - GET
        [HttpGet]
        public IActionResult CreateAdmin()
        {
            return View(); // AdminCreate.cshtml sayfasını döndürür
        }

        // Admin Ekleme - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAdmin(AdminDto adminDto)
        {
            if (ModelState.IsValid)
            {
                _adminService.AddAdmin(adminDto);
                return RedirectToAction("AdminList");
            }
            return View(adminDto); // Hatalı form gönderiminde sayfayı geri döndürür
        }

        // Admin Düzenleme - GET
        [HttpGet]
        public IActionResult EditAdmin(int id)
        {
            var admin = _adminService.GetAdminById(id);
            if (admin == null)
            {
                return NotFound();
            }
            return View(admin); // AdminEdit.cshtml sayfasına veri gönderilir
        }

        // Admin Düzenleme - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditAdmin(AdminDto adminDto)
        {
            if (ModelState.IsValid)
            {
                _adminService.UpdateAdmin(adminDto);
                return RedirectToAction("AdminList");
            }
            return View(adminDto);
        }

        // Admin Silme (Pasife Alma)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAdmin(int id)
        {
            var admin = _adminService.GetAdminById(id);
            if (admin == null)
            {
                return NotFound();
            }

            _adminService.DeleteAdmin(id); // Silme yerine pasife alma işlemi yapılır
            return RedirectToAction("AdminList");
        }
    }
}
