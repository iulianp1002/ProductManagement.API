using ProductManagement.API.DomainModels;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using System.Xml.Linq;

namespace ProductManagement.API.Repository
{
    public class StoreRepository : IStoreRepository
    {
        private readonly IConfiguration _config;

        public StoreRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task<int> CreateAsync(Store store)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var result = await connection.ExecuteAsync("insert into Magazine(CodMagazin,Denumire,Detalii) Values(@CodMagazin,@Denumire,@Detalii)", 
                                                        param: new { CodMagazin = store.CodMagazin,Denumire = store.Denumire, Detalii = store.Detalii },
                                                        commandType: CommandType.Text);
            return result;
        }

        public async Task<int> DeleteAsync(string codMagazin)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            return await connection.ExecuteAsync("delete from Magazine where CodMagazin=@CodMagazin", new { CodMagazin = codMagazin });
        }

        public async Task<List<Store>> GetAllStoresAsync()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var stores = await connection.QueryAsync<Store>("Select * from Magazine");

            return stores.ToList();
        }

        public async Task<Store> GetByCodMagazinAsync(string codMagazin)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var store = await connection.QueryFirstAsync<Store>("Select * from Magazine where CodMagazin=@CodMagazin", new { CodMagazin = codMagazin });

            return store;
        }

        public async Task<Store> GetByNameAsync(string denumire)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var store = await connection.QueryFirstAsync<Store>("Select * from Magazine where Denumire like '%@Denumire%'", new { Denumire = denumire });

            return store;
        }

        public async Task<int> UpdateAsync(Store store)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var updatedStore = await connection.ExecuteAsync("Update Magazine Set Denumire=@Denumire,Detalii = @Detalii where CodMagazin =@CodMagazin", 
                                                            param: new { Denumire = store.Denumire, Detalii = store.Detalii, CodMagazin = store.CodMagazin }, 
                                                            commandType: CommandType.Text);

            return updatedStore;
        }
    }
}
