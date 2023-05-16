using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Products_Domain.Models.Products
{
    [Table ("product")]
    public class Product
    {
        [Column("product_id")]
        public Guid ProductId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("price")]
        public decimal Price { get; set; }
    }
}
