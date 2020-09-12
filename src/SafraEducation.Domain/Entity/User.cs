using System;

namespace SafraEducacional.Domain.Entity
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? BirthOn { get; set; }
        public string Ddd { get; set; }
        public string Phone { get; set; }
        public string PasswordDigest { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}