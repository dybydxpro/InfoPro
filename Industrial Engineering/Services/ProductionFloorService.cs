using Industrial_Engineering.Data;
using Industrial_Engineering.Modals;
using Industrial_Engineering.Services.Context;
using Microsoft.EntityFrameworkCore;

namespace Industrial_Engineering.Services
{
    public class ProductionFloorService : IProductionFloorService
    {
        protected readonly IndustrialEngineeringDbContext _context;
        protected readonly IIndustrialEngineeringUnitOfWork _unitOfWork;

        public ProductionFloorService(IndustrialEngineeringDbContext context, IIndustrialEngineeringUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public List<ProductionFloor> GetProductionFloors()
        {
            List<ProductionFloor> productionFloors = _unitOfWork.ProductionFloorRepository.GetAll()
                .Include(p => p.Style)
                .Include(p => p.FlowWorkers).ThenInclude(p => p.Employee).ToList();
            return productionFloors;
        }

        public ProductionFloor GetProductionFloorById(int id)
        {
            ProductionFloor productionFloor = _unitOfWork.ProductionFloorRepository.GetAll()
                .Include(p => p.Style).Include(p => p.FlowWorkers).Where(d => d.Id == id).FirstOrDefault();
            return productionFloor;
        }

        public ProductionFloor CreateProductionFloor(ProductionFloor productionFloor)
        {
            List<FlowWorker> flowWorkers = productionFloor.FlowWorkers;
            productionFloor.FlowWorkers = null;

            _unitOfWork.ProductionFloorRepository.Insert(productionFloor);
            _unitOfWork.SaveChanges();
            _unitOfWork.ProductionFloorRepository.Reload(productionFloor);

            foreach(var worker in flowWorkers)
            {
                worker.ProductionFloorId = productionFloor.Id;
                _unitOfWork.FlowWorkerRepository.Insert(worker);
                _unitOfWork.SaveChanges();
                _unitOfWork.FlowWorkerRepository.Reload(worker);
            }

            return productionFloor;
        }

        public ProductionFloor UpdateProductionFloor(ProductionFloor productionFloor)
        {
            _unitOfWork.ProductionFloorRepository.Update(productionFloor);
            _unitOfWork.SaveChanges();
            _unitOfWork.ProductionFloorRepository.Reload(productionFloor);
            return productionFloor;
        }

        public ProductionFloor DeleteProductionFloor(int id)
        {
            ProductionFloor productionFloor = GetProductionFloorById(id);
            if (productionFloor == null)
                throw new Exception("Designation not found!");

            _unitOfWork.ProductionFloorRepository.Delete(productionFloor);
            _unitOfWork.SaveChanges();
            return productionFloor;
        }
    }
}
