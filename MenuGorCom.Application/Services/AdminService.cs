// File: AdminService.cs
using System.Collections.Generic;
using System.Linq;
using MenuGorCom.Application.DTOs;
using MenuGorCom.Application.Interfaces;
using MenuGorCom.Infrastructure.Data;

namespace MenuGorCom.Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly MenuGorDbContext _context;

        public AdminService(MenuGorDbContext context)
        {
            _context = context;
        }

        public List<AdminDto> GetAllAdmins()
        {
            return _context.Admins
                .Select(a => new AdminDto
                {
                    Id = a.Id,
                    Username = a.Username,
                    Email = a.Email,
                    LastLogin = a.LastLogin,
                    IsActive = a.IsActive
                }).ToList();
        }
    }
}
