// File: AdminService.cs
using System.Collections.Generic;
using MenuGorCom.Application.DTOs;
using MenuGorCom.Application.Interfaces;
using MenuGorCom.Core.Entities;
using MenuGorCom.Infrastructure.Data;

namespace MenuGorCom.Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly MenuGorDbContext _dbContext;

        public AdminService(MenuGorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<AdminDto> GetAllAdmins()
        {
            return _dbContext.Admins
                .Where(a => !a.IsDeleted)
                .Select(a => new AdminDto
                {
                    Id = a.Id,
                    Username = a.Username,
                    Email = a.Email,
                    IsActive = a.IsActive,
                    LastLogin = a.LastLogin 
                })
                .ToList();
        }

        public AdminDto GetAdminById(int id)
        {
            var admin = _dbContext.Admins.FirstOrDefault(a => a.Id == id && !a.IsDeleted);
            if (admin == null) return null;

            return new AdminDto
            {
                Id = admin.Id,
                Username = admin.Username,
                Email = admin.Email,
                IsActive = admin.IsActive,
                LastLogin = admin.LastLogin
            };
        }

        public void AddAdmin(AdminDto adminDto)
        {
            var newAdmin = new Admin
            {
                Username = adminDto.Username,
                Email = adminDto.Email,
                PasswordHash = HashPassword(adminDto.Password),
                IsActive = true,
                IsDeleted = false
            };

            _dbContext.Admins.Add(newAdmin);
            _dbContext.SaveChanges();
        }

        public void UpdateAdmin(AdminDto adminDto)
        {
            var admin = _dbContext.Admins.FirstOrDefault(a => a.Id == adminDto.Id);
            if (admin == null) return;

            admin.Username = adminDto.Username;
            admin.Email = adminDto.Email;
            admin.IsActive = adminDto.IsActive;

            _dbContext.SaveChanges();
        }

        public void DeleteAdmin(int id)
        {
            var admin = _dbContext.Admins.FirstOrDefault(a => a.Id == id);
            if (admin == null) return;

            admin.IsDeleted = true;
            _dbContext.SaveChanges();
        }

        private string HashPassword(string password)
        {
            // Şifreleme algoritması eklenebilir (ör. BCrypt veya SHA256)
            return password; // Placeholder
        }
    }
}
