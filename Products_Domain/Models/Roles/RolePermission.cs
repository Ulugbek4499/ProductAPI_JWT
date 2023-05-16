using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Products_Domain.Models.Permissions;

namespace Products_Domain.Models.Roles
{
    [Table("role_permission")]
    public class RolePermission
    {
        [Column("role_permission_id")]
        public Guid RolePermissionId { get; set; }
        [Column("role_id")]
        public Guid RoleId { get; set; }
        public Role Role { get; set; }

        [Column("permission_id")]
        public Guid PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}
