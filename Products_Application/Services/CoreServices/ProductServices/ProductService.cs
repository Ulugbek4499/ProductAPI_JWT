using Products_Application.Abstraction;
using Products_Application.Interfaces.ServiceInterfaces;
using Products_Domain.Models.Products;

namespace Products_Application.Services.CoreServices.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IApplicationDbContext applicationDbContext;

        public ProductService(IApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async ValueTask<Product> AddProductAsync(Product product)
        {
            product.ProductId = new Guid();
           return await applicationDbContext.AddAsync(product);
        }

        public IQueryable<Product> GetAllProducts() =>
            applicationDbContext.GetAll<Product>();

        public async ValueTask<Product> GetProductByIdAsync(Guid id) =>
           await applicationDbContext.GetAsync<Product>(id);

        public async ValueTask<Product> UpdateProductAsync(Product product) =>
            await applicationDbContext.UpdateAsync(product);

        public async ValueTask<Product> DeleteProductAsync(Guid id)
        {
            Product maybeProduct = await applicationDbContext.GetAsync<Product>(id);

            if (maybeProduct == null)
                throw new ArgumentNullException(nameof(maybeProduct));

            return await applicationDbContext.DeleteAsync(maybeProduct);
        }
    }
}
