// File: AdminDto.cs
namespace MenuGorCom.Application.DTOs
{
    public class AdminDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }

    }
}
