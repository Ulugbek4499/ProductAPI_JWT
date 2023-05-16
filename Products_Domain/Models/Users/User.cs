using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Products_Domain.Models.Users
{
    [Table("user")]
    public class User
    {
        [Column("user_id")]
        [Key]
        [JsonPropertyName("user_id")]
        public Guid UsersId { get; set; }

        [Column("username")]
        public string Username { get; set; }

        [Column("password")]
        public string Password { get; set; }
     
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
