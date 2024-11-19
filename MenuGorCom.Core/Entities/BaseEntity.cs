// File: MenuGorCom.Core/Entities/BaseEntity.cs
// Namespace: MenuGorCom.Core.Entities
using System;

namespace MenuGorCom.Core.Entities
{
    public abstract class BaseEntity
    {
        // Benzersiz kimlik (Primary Key)
        public int Id { get; set; }

        // Kaydın oluşturulma zamanı
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Kaydın güncellenme zamanı
        public DateTime? UpdatedAt { get; set; }

        // Kaydın silinme durumu ve zamanı
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }

        // Ekleyenin veya güncelleyenin bilgisi
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
