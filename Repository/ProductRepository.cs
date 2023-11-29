using ProductManagement.API.DomainModels;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace ProductManagement.API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration _config;

        private const string SPFindProductByName = "dbo.sp_FindProductByName";
        public ProductRepository(IConfiguration config)
        {
            _config = config;
        }
        public async Task<int> CreateAsync(Product product)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var result = await connection.ExecuteAsync("Insert into Produse(CodIdx,CodIdxAlt,CodMagazin,Denumire,DataInregistrare,Cantitate,PretUnitar) " +
                "                                       Values(@CodIdx,@CodIdxAlt,@CodMagazin,@Denumire,@DataInregistrare,@Cantitate,@PretUnitar)",
                                                        param: new { CodIdx = product.CodIdx, 
                                                                     CodIdxAlt = product.CodIdxAlt, 
                                                                     CodMagazin = product.CodMagazin, 
                                                                     Denumire = product.Denumire,
                                                                     DataInregistrare = product.DataInregistrare,
                                                                     Cantitate = product.Cantitate,
                                                                     PretUnitar = product.PretUnitar},
                                                        commandType: CommandType.Text);
            return result;
        }

        public async Task<int> DeleteAsync(string codIdx, string codIdxAlt)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            return await connection.ExecuteAsync("delete from Produse where CodIdx = @CodIdx AND CodIdxAlt = @CodIdxAlt", new { CodIdx = codIdx, CodIdxAlt = codIdxAlt });
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var products = await connection.QueryAsync<Product>("Select * from Produse");

            return products.ToList();
        }

        public async Task<Product> GetByCodAsync(string codIdx, string codIdxAlt)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var product = await connection.QueryFirstAsync<Product>("Select * from Produse where CodIdx=@CodIdx AND CodIdxAlt=@CodIdxAlt", new { CodIdx = codIdx, CodIdxAlt = codIdxAlt });

            return product;
        }

        public async Task<Product> GetByNameAsync(string denumire)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var result = await connection.QueryAsync<Product>(SPFindProductByName, new
            {
                Name = denumire
            }, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault() ?? new Product();
        }

        public async Task<int> UpdateAsync(Product product)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var updatedproduct = await connection.ExecuteAsync("Update Produse Set CodMagazin = @CodMagazin,Denumire=@Denumire, DataInregistrare = @DataInregistrare, Cantitate = @Cantitate, PretUnitar = @PretUnitar WHERE CodIdx =@CodIdx AND CodIdxAlt = @CodIdxAlt",
                                                            param: new { CodIdx = product.CodIdx, CodIdxAlt = product.CodIdxAlt,CodMagazin = product.CodMagazin, Denumire = product.Denumire, DataInregistrare = product.DataInregistrare, Cantitate = product.Cantitate, PretUnitar = product.PretUnitar },
                                                            commandType: CommandType.Text);

            return updatedproduct;
        }
    }
}
