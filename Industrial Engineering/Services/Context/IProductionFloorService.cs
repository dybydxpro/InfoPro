using Industrial_Engineering.Modals;

namespace Industrial_Engineering.Services.Context
{
    public interface IProductionFloorService
    {
        List<ProductionFloor> GetProductionFloors();
        ProductionFloor GetProductionFloorById(int id);
        ProductionFloor CreateProductionFloor(ProductionFloor productionFloor);
        ProductionFloor UpdateProductionFloor(ProductionFloor productionFloor);
        ProductionFloor DeleteProductionFloor(int id);
    }
}
