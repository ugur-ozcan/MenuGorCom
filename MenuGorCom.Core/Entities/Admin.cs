// File: MenuGorCom.Core/Entities/Admin.cs
// Namespace: MenuGorCom.Core.Entities
using System;

namespace MenuGorCom.Core.Entities
{
    public class Admin : BaseEntity
    {
        // Kullanıcı adı
        public string Username { get; set; }

        // Email adresi
        public string Email { get; set; }

        // Şifre (Hashlenmiş olarak saklanacak)
        public string PasswordHash { get; set; }

        // Ad ve soyad
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Aktiflik durumu
        public bool IsActive { get; set; } = true;

        // Rol bilgisi (Admin, Süper Admin gibi)
        public string Role { get; set; }
    }
}
