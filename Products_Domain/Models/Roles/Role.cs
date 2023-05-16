using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Products_Domain.Models.Users;

namespace Products_Domain.Models.Roles
{
    [Table("role")]
    public class Role
    {
        [Column("role_id")]
        public Guid Id { get; set; }

        [Column("name")]
        public string Name { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
