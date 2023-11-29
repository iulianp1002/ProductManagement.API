using ProductManagement.API.DomainModels;

namespace ProductManagement.API.Services
{
    public interface IProductService
    {
        public Task<List<Product>> GetAllProductsAsync();
        public Task<Product> GetByCodAsync(string codIdx, string codIdxAlt);
        public Task<Product> GetByNameAsync(string denumire);

        public Task<int> CreateAsync(Product product);
        public Task<int> UpdateAsync(Product product);
        public Task<int> DeleteAsync(string codIdx, string codIdxAlt);
    }
}
