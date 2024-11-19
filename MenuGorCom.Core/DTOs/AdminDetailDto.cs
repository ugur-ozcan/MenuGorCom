// File: MenuGorCom.Core/DTOs/AdminDetailDto.cs
namespace MenuGorCom.Core.DTOs
{
    public class AdminDetailDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
    }
}
