﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Products_Application.DTOs.Products
{
    public class ReadProductDTO
    {
        [JsonPropertyName("product_id")]
        public Guid ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
