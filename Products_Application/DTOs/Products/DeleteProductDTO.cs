using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Products_Application.DTOs.Products
{
    public class DeleteProductDTO
    {
        [JsonPropertyName("product_id")]
        public Guid ProductId { get; set; }
    }
}
