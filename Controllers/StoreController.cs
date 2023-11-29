using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.API.DomainModels;
using ProductManagement.API.Services;

namespace ProductManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;
        private readonly ILogger<StoreController> _logger;

        public StoreController(IStoreService storeService, ILogger<StoreController> logger)
        {
            _storeService = storeService;
            _logger = logger;
        }
        /// <summary>
        /// Get the list of all stores
        /// </summary>
        /// <returns></returns>
        [HttpGet("StoreList")]
        public async Task<ActionResult<List<Store>>> GetAllStores()
        {
            try
            {
                var stores = await _storeService.GetAllStoresAsync();
                return Ok(stores);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetAllStores - " + ex.Message, ex);
                return BadRequest(ex.Message);
            }

        }
        /// <summary>
        /// Get a store
        /// </summary>
        /// <param name="code">code of the store</param>
        /// <returns>the store</returns>
        [HttpGet("{code}")]
        public async Task<ActionResult<Store>> GetAuthor(string code)
        {
            try
            {
                var store = await _storeService.GetByCodMagazinAsync(code);

                if (store == null)
                {
                    return BadRequest("Store does not exist!");
                }

                return Ok(store);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetStore - " + ex.Message, ex);
                return BadRequest(ex.Message);
            }

        }
        /// <summary>
        /// Create a store
        /// </summary>
        /// <param name="store">store </param>
        /// <returns>returns the result of created store</returns>
        [HttpPost]
        public async Task<ActionResult<int>> CreateStore(Store store)
        {
            try
            {
                var result = await _storeService.CreateAsync(store);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("CreateStore - " + ex.Message, ex);
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Update the store
        /// </summary>
        /// <param name="store"></param>
        /// <returns>result of the updated store</returns>
        [HttpPut]
        public async Task<ActionResult<int>> UpdateStore(Store store)
        {
            try
            {
                var result = await _storeService.UpdateAsync(store);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("UpdateStore - " + ex.Message, ex);
                return BadRequest(ex.Message);
            }

        }
        /// <summary>
        /// Delete the store
        /// </summary>
        /// <param name="code">code of a store</param>
        /// <returns>result of the deleted store </returns>
        [HttpDelete("code")]
        public async Task<ActionResult<int>> DeleteAuthor(string code)
        {
            try
            {
                var result = await _storeService.DeleteAsync(code);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("DeleteStore - " + ex.Message, ex);
                return NotFound(ex.Message);
            }


        }
    }
}
