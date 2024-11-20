using MenuGorCom.Application.DTOs;

namespace MenuGorCom.Application.ViewModels
{
    public class AdminListViewModel
    {
        public string Filter { get; set; } // Aktif, Pasif, Silinmiş
        public IEnumerable<AdminDto> Admins { get; set; }
    }
}
