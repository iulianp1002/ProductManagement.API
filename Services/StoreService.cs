using ProductManagement.API.DomainModels;
using ProductManagement.API.Repository;

namespace ProductManagement.API.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;

        public StoreService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public async Task<int> CreateAsync(Store store)
        {
            return await _storeRepository.CreateAsync(store);
        }

        public async Task<int> DeleteAsync(string codMagazin)
        {
            return await _storeRepository.DeleteAsync(codMagazin);
        }

        public async Task<List<Store>> GetAllStoresAsync()
        {
            return await _storeRepository.GetAllStoresAsync();
        }

        public async Task<Store> GetByCodMagazinAsync(string codMagazin)
        {
            return await _storeRepository.GetByCodMagazinAsync(codMagazin);
        }

        public async Task<Store> GetByNameAsync(string name)
        {
            return await GetByCodMagazinAsync(name);
        }

        public async Task<int> UpdateAsync(Store store)
        {
            return await _storeRepository.UpdateAsync(store);
        }
    }
}
