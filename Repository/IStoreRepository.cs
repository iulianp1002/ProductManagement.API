using ProductManagement.API.DomainModels;

namespace ProductManagement.API.Repository
{
    public interface IStoreRepository
    {
        public Task<List<Store>> GetAllStoresAsync();
        public Task<Store> GetByCodMagazinAsync(string codMagazin);
        public Task<Store> GetByNameAsync(string name);

        public Task<int> CreateAsync(Store store);
        public Task<int> UpdateAsync(Store store);
        public Task<int> DeleteAsync(string codMagazin);

    }
}
