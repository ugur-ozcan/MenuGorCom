// File: IAdminService.cs
using System.Collections.Generic;
using MenuGorCom.Application.DTOs;

namespace MenuGorCom.Application.Interfaces
{
    public interface IAdminService
    {
        List<AdminDto> GetAllAdmins();
    }
}
