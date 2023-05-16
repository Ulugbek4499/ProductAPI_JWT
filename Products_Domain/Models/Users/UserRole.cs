using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Products_Domain.Models.Roles;

namespace Products_Domain.Models.Users
{
    [Table("user_role")]
    public class UserRole
    {
        [Column("user_role_id")]
        public Guid Id { get; set; }

        [ForeignKey("user_id")]
        [Column("user_id")]

        public Guid UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("role_id")]
        [Column("role_id")]

        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}