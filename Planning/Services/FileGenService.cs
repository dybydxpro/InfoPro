using Planning.Data;
using Planning.Services.Context;

namespace Planning.Services;

public class FileGenService : IFileGenService
{
    protected readonly PlanningDbContext _dbContext;
    protected readonly IPlanningUnitOfWork _unitOfWork;

    public FileGenService(PlanningDbContext dbContext, IPlanningUnitOfWork unitOfWork)
    {
        _dbContext = dbContext;
        _unitOfWork = unitOfWork;
    }
}