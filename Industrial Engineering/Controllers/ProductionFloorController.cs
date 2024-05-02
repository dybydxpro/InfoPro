using Industrial_Engineering.Modals;
using Industrial_Engineering.Services;
using Industrial_Engineering.Services.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Industrial_Engineering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionFloorController : ControllerBase
    {
        protected readonly IProductionFloorService _productionFloorService;

        public ProductionFloorController(IProductionFloorService productionFloorService)
        {
            _productionFloorService = productionFloorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductionFloor>>> GetProductionFloors()
        {
            return _productionFloorService.GetProductionFloors();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ProductionFloor>> GetProductionFloorById(int id)
        {
            return _productionFloorService.GetProductionFloorById(id);
        }

        [HttpPost]
        public async Task<ActionResult<ProductionFloor>> PostProductionFloor(ProductionFloor productionFloor)
        {
            return _productionFloorService.CreateProductionFloor(productionFloor);
        }

        [HttpPut]
        public async Task<ActionResult<ProductionFloor>> PutProductionFloor(ProductionFloor productionFloor)
        {
            return _productionFloorService.UpdateProductionFloor(productionFloor);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<ProductionFloor>> DeleteProductionFloor(int id)
        {
            return _productionFloorService.DeleteProductionFloor(id);
        }
    }
}
