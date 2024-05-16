using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.ML;
using Production.Data;
using Production.Modals;
using Production.Services.Context;

namespace Production.Services
{
    public class ForecastService : IForecastService
    {
        protected readonly ProductionDbContext _dbContext;
        protected readonly IProductionUnitOfWork _unitOfWork;
        protected readonly PredictionEnginePool<Forecast_Predict.ModelInput, Forecast_Predict.ModelOutput> _predictionEnginePool;

        public ForecastService(ProductionDbContext dbContext, IProductionUnitOfWork unitOfWork, PredictionEnginePool<Forecast_Predict.ModelInput, Forecast_Predict.ModelOutput> predictionEnginePool) {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
            _predictionEnginePool = predictionEnginePool;
        }

        public async Task<double> GenerateForecast()
        {
            List<ProductionFloor> floors = _unitOfWork.ProductionFloorRepository.GetAll().Include(f => f.Style).Include(f => f.FlowWorkers).ToList();
            List<double> items = new List<double>();
            double qty = 0.0;

            foreach (var floor in floors)
            {
                Forecast_Predict.ModelInput input = new Forecast_Predict.ModelInput()
                {
                    Smv = (float)floor.Style.SMV,
                    No_of_workers = floor.FlowWorkers.Count,
                    Quantity = 0,
                };

                Forecast_Predict.ModelOutput output = _predictionEnginePool.Predict(input);

                items.Add(output.Score);
            }

            foreach (var item in items) 
            {
                qty = qty + item;
            }

            return qty;
        }
    }
}
