using MenuGorCom.Application.DTOs;
using MenuGorCom.Core.DTOs;
using System.Collections.Generic;

namespace MenuGorCom.Application.Interfaces
{
    public interface IAdminService
    {
        //IEnumerable<AdminDetailDto> GetAllAdmins(); // Tüm adminleri getir
        IEnumerable<AdminDetailDto> GetActiveAdmins(); // Aktif adminleri getir
        IEnumerable<AdminDetailDto> GetDeletedAdmins(); // Silinmiş adminleri getir
        IEnumerable<AdminDetailDto> GetPassiveAdmins(); // Pasif adminleri getir

        AdminDetailDto GetAdminById(int id); // Belirli bir adminin detaylarını getir
        void AddAdmin(AdminCreateDto adminCreateDto); // Yeni admin ekle
        void UpdateAdmin(AdminUpdateDto adminUpdateDto); // Admin güncelle
        void DeleteAdmin(int id); // Admini pasif yap (silme yerine)
        IEnumerable<AdminDto> GetAllAdmins(); // Tüm adminleri getir
     }
}
