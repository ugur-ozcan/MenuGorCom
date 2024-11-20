// File: MenuGorCom.Core/DTOs/AdminCreateDto.cs
namespace MenuGorCom.Core.DTOs
{
    public class AdminCreateDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // Kullanıcıdan düz metin olarak alınacak
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; } // Admin, Süper Admin gibi
    }
}
