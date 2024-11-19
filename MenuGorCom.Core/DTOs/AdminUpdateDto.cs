// File: MenuGorCom.Core/DTOs/AdminUpdateDto.cs
namespace MenuGorCom.Core.DTOs
{
    public class AdminUpdateDto
    {
        public int Id { get; set; } // Güncelleme için gerekli
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public string Role { get; set; }
    }
}
