// File: MenuGorCom.Core/DTOs/AdminUpdateDto.cs
namespace MenuGorCom.Core.DTOs
{
    public class AdminUpdateDto
    {
        public int Id { get; set; } // Güncellenecek kaydın Id'si
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; } // Kullanıcı aktif/pasif durumu
    }
}
