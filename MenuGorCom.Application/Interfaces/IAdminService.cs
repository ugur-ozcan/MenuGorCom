// File: IAdminService.cs
using System.Collections.Generic;
using MenuGorCom.Application.DTOs;

namespace MenuGorCom.Application.Interfaces
{
    public interface IAdminService
    {
        List<AdminDto> GetAllAdmins();
        AdminDto GetAdminById(int id);
        void AddAdmin(AdminDto adminDto);
        void UpdateAdmin(AdminDto adminDto);
        void DeleteAdmin(int id); // Pasife alma    }
    }
