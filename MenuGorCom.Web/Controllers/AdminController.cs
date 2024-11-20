using Microsoft.AspNetCore.Mvc;
using MenuGorCom.Application.Interfaces;
using MenuGorCom.Application.DTOs;
using MenuGorCom.Application.ViewModels;
using MenuGorCom.Core.DTOs;

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
        public IActionResult AdminList(string filter = "All")
        {
            IEnumerable<AdminDto> admins = filter switch
            {
                "Active" => _adminService.GetActiveAdmins()
                                         .Select(admin => new AdminDto
                                         {
                                             Id = admin.Id,
                                             Username = admin.Username,
                                             Email = admin.Email,
                                             LastLogin = admin.LastLogin,
                                             IsActive = admin.IsActive,
                                             IsDeleted = admin.IsDeleted
                                         }),
                "Passive" => _adminService.GetPassiveAdmins()
                                          .Select(admin => new AdminDto
                                          {
                                              Id = admin.Id,
                                              Username = admin.Username,
                                              Email = admin.Email,
                                              LastLogin = admin.LastLogin,
                                              IsActive = admin.IsActive,
                                              IsDeleted = admin.IsDeleted
                                          }),
                "Deleted" => _adminService.GetDeletedAdmins()
                                          .Select(admin => new AdminDto
                                          {
                                              Id = admin.Id,
                                              Username = admin.Username,
                                              Email = admin.Email,
                                              LastLogin = admin.LastLogin,
                                              IsActive = admin.IsActive,
                                              IsDeleted = admin.IsDeleted
                                          }),
                _ => _adminService.GetAllAdmins()
                                  .Select(admin => new AdminDto
                                  {
                                      Id = admin.Id,
                                      Username = admin.Username,
                                      Email = admin.Email,
                                      LastLogin = admin.LastLogin,
                                      IsActive = admin.IsActive,
                                      IsDeleted = admin.IsDeleted
                                  })
            };

            var viewModel = new AdminListViewModel
            {
                Filter = filter,
                Admins = admins
            };

            return View(viewModel);
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
            return View(admin);
        }

        // Admin Ekleme - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAdmin(AdminCreateDto adminCreateDto)
        {
            if (ModelState.IsValid)
            {
                _adminService.AddAdmin(adminCreateDto);
                return RedirectToAction("AdminList");
            }

            // Eğer hata varsa listeyi yeniden doldur ve ekleme formunu yeniden göster
            var adminList = _adminService.GetAllAdmins();
            var viewModel = new AdminListViewModel
            {
                Filter = "All",
                Admins = adminList
            };
            return View("AdminList", viewModel);
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

            var adminUpdateDto = new AdminUpdateDto
            {
                Id = admin.Id,
                Username = admin.Username,
                Email = admin.Email,
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                Role = admin.Role,
                IsActive = admin.IsActive
            };

            return View(adminUpdateDto);
        }

        // Admin Düzenleme - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditAdmin(AdminUpdateDto adminUpdateDto)
        {
            if (ModelState.IsValid)
            {
                _adminService.UpdateAdmin(adminUpdateDto);
                return RedirectToAction("AdminList");
            }

            return View(adminUpdateDto);
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

            _adminService.DeleteAdmin(id);
            return RedirectToAction("AdminList");
        }
    }
}
