using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Products_Domain.Models.Roles;

namespace Products_Domain.Models.Permissions
{
    [Table("permission")]
    public class Permission
    {
        [Column("permission_id")]
        public Guid Id { get; set; }

        [Column("permission_name")]
        public string PermissionName { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}
