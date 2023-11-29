using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.API.DomainModels;
using ProductManagement.API.Services;

namespace ProductManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        /// <summary>
        /// Get the list of all products
        /// </summary>
        /// <returns></returns>
        [HttpGet("ProductList")]
        public async Task<ActionResult<List<Store>>> GetAllProducts()
        {
            try
            {
                var products = await _productService.GetAllProductsAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetAllStores - " + ex.Message, ex);
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Get a product by its codes
        /// </summary>
        /// <param name="codeIdx">the code</param>
        /// <param name="codeIdxAlt">the alternative code</param>
        /// <returns></returns>
        [HttpGet("{codeIdx}/{codeIdxAlt}")]
        public async Task<ActionResult<Store>> GetProduct(string codeIdx, string codeIdxAlt)
        {
            try
            {
                var product = await _productService.GetByCodAsync(codeIdx,codeIdxAlt);

                if (product == null)
                {
                    return BadRequest("Product does not exist!");
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetProduct - " + ex.Message, ex);
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Get a product by its name
        /// </summary>
        /// <param name="name">name of a producxt</param>
        /// <returns>the product</returns>
        [HttpGet("{name}")]
        public async Task<ActionResult<Store>> GetProductByName(string name)
        {
            try
            {
                var product = await _productService.GetByNameAsync( name);

                if (product == null)
                {
                    return BadRequest("Product does not exist!");
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetProduct by name - " + ex.Message, ex);
                return BadRequest(ex.Message);
            }

        }


        /// <summary>
        /// Create a product
        /// </summary>
        /// <param name="product">the product details </param>
        /// <returns>returns the result of created product</returns>
        [HttpPost]
        public async Task<ActionResult<int>> CreateStore(Product product)
        {
            try
            {
                var result = await _productService.CreateAsync(product);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("CreateProduct - " + ex.Message, ex);
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Update the product
        /// </summary>
        /// <param name="product"></param>
        /// <returns>result of the updated product</returns>
        [HttpPut]
        public async Task<ActionResult<int>> UpdateProduct(Product product)
        {
            try
            {
                var result = await _productService.UpdateAsync(product);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("UpdateProduct - " + ex.Message, ex);
                return BadRequest(ex.Message);
            }

        }
       
        /// <summary>
        /// Delete product based on codIdx and codIdxAlt
        /// </summary>
        /// <param name="codIdx">codIdx</param>
        /// <param name="codIdxAlt">codIdxAlt</param>
        /// <returns>result of the deleted product</returns>
        [HttpDelete()]
        public async Task<ActionResult<int>> DeleteProduct(string codIdx, string codIdxAlt)
        {
            try
            {
                var result = await _productService.DeleteAsync(codIdx, codIdxAlt);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("DeleteProduct - " + ex.Message, ex);
                return NotFound(ex.Message);
            }


        }
    }
}
