using MenuGorCom.Application.Interfaces;
using MenuGorCom.Core.DTOs;
using MenuGorCom.Core.Entities;
using MenuGorCom.Infrastructure.Data;
using BCrypt.Net;
using System.Collections.Generic;
using System.Linq;
using MenuGorCom.Application.DTOs;

namespace MenuGorCom.Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly MenuGorDbContext _context;

        public AdminService(MenuGorDbContext context)
        {
            _context = context;
        }

 
        public IEnumerable<AdminDto> GetAllAdmins()
        {
            return _context.Admins
                .Where(a => !a.IsDeleted)
                .Select(a => new AdminDto
                {
                    Id = a.Id,
                    Username = a.Username,
                    Email = a.Email,
                    LastLogin = a.LastLogin,
                    IsActive = a.IsActive,
                    IsDeleted = a.IsDeleted
                }).ToList();
        }


        public IEnumerable<AdminDetailDto> GetActiveAdmins()
        {
            return _context.Admins
                .Where(a => a.IsActive && !a.IsDeleted) // Aktif ve silinmemiş adminler
                .Select(a => new AdminDetailDto
                {
                    Id = a.Id,
                    Username = a.Username,
                    Email = a.Email,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Role = a.Role,
                    LastLogin = a.LastLogin,
                    IsActive = a.IsActive
                })
                .ToList();
        }

        public IEnumerable<AdminDetailDto> GetDeletedAdmins()
        {
            return _context.Admins
                .Where(a => a.IsDeleted) // Silinmiş adminler
                .Select(a => new AdminDetailDto
                {
                    Id = a.Id,
                    Username = a.Username,
                    Email = a.Email,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Role = a.Role,
                    LastLogin = a.LastLogin,
                    IsActive = a.IsActive
                })
                .ToList();
        }

        public IEnumerable<AdminDetailDto> GetPassiveAdmins()
        {
            return _context.Admins
                .Where(a => !a.IsActive && !a.IsDeleted) // Pasif ama silinmemiş adminler
                .Select(a => new AdminDetailDto
                {
                    Id = a.Id,
                    Username = a.Username,
                    Email = a.Email,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Role = a.Role,
                    LastLogin = a.LastLogin,
                    IsActive = a.IsActive
                })
                .ToList();
        }

        public AdminDetailDto GetAdminById(int id)
        {
            var admin = _context.Admins.FirstOrDefault(a => a.Id == id && !a.IsDeleted);
            if (admin == null) return null;

            return new AdminDetailDto
            {
                Id = admin.Id,
                Username = admin.Username,
                Email = admin.Email,
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                Role = admin.Role,
                LastLogin = admin.LastLogin,
                IsActive = admin.IsActive
            };
        }

        public void AddAdmin(AdminCreateDto adminCreateDto)
        {
            var admin = new Admin
            {
                Username = adminCreateDto.Username,
                Email = adminCreateDto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(adminCreateDto.Password),
                FirstName = adminCreateDto.FirstName,
                LastName = adminCreateDto.LastName,
                Role = adminCreateDto.Role,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            _context.Admins.Add(admin);
            _context.SaveChanges();
        }

        public void UpdateAdmin(AdminUpdateDto adminUpdateDto)
        {
            var admin = _context.Admins.FirstOrDefault(a => a.Id == adminUpdateDto.Id && !a.IsDeleted);
            if (admin == null) return;

            admin.Username = adminUpdateDto.Username;
            admin.Email = adminUpdateDto.Email;
            admin.FirstName = adminUpdateDto.FirstName;
            admin.LastName = adminUpdateDto.LastName;
            admin.Role = adminUpdateDto.Role;
            admin.IsActive = adminUpdateDto.IsActive;
            admin.UpdatedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }

        public void DeleteAdmin(int id)
        {
            var admin = _context.Admins.FirstOrDefault(a => a.Id == id && !a.IsDeleted);
            if (admin == null) return;

            admin.IsDeleted = true;
            admin.DeletedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }
    }
}
