using ProductManagement.API.DomainModels;
using ProductManagement.API.Repository;

namespace ProductManagement.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> CreateAsync(Product product)
        {
           return await _productRepository.CreateAsync(product);
        }

        public async Task<int> DeleteAsync(string codIdx, string codIdxAlt)
        {
            return await (_productRepository.DeleteAsync(codIdx, codIdxAlt));
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task<Product> GetByCodAsync(string codIdx, string codIdxAlt)
        {
            return await _productRepository.GetByCodAsync(codIdx, codIdxAlt);
        }

        public async Task<Product> GetByNameAsync(string denumire)
        {
            return await _productRepository.GetByNameAsync(denumire);
        }

        public async Task<int> UpdateAsync(Product product)
        {
            return await _productRepository.UpdateAsync(product);
        }
    }
}
