using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products_Domain.Models.Products;

namespace Products_Application.Interfaces.ServiceInterfaces
{
    public interface IProductService
    {
        ValueTask<Product> AddProductAsync(Product product);
        IQueryable<Product> GetAllProducts();
        ValueTask<Product> GetProductByIdAsync(Guid id);
        ValueTask<Product> UpdateProductAsync(Product product);
        ValueTask<Product> DeleteProductAsync(Guid id);
    }
}
