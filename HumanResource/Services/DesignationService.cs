using HumanResource.Data;
using HumanResource.Models;
using HumanResource.Services.Context;

namespace HumanResource.Services
{
    public class DesignationService: IDesignationService
    {
        protected readonly HumanResourceDbContext _dbContext;
        protected readonly IHumanResourceUnitOfWork _unitOfWork;

        public DesignationService(HumanResourceDbContext dbContext, IHumanResourceUnitOfWork unitOfWork)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
        }
        
        public List<Designation> GetDesignations()
        {
            List<Designation> designation = _unitOfWork.DesignationRepository.GetAll().ToList();
            return designation;
        }

        public Designation GetDesignationById(int id)
        {
            Designation designation = _unitOfWork.DesignationRepository.GetAll().Where(d => d.Id == id).FirstOrDefault();
            return designation;
        }

        public Designation CreateDesignation(Designation designation)
        {
            _unitOfWork.DesignationRepository.Insert(designation);
            _unitOfWork.SaveChanges();
            _unitOfWork.DesignationRepository.Reload(designation);
            return designation;
        }

        public Designation UpdateDesignation(Designation designation)
        {
            _unitOfWork.DesignationRepository.Update(designation);
            _unitOfWork.SaveChanges();
            _unitOfWork.DesignationRepository.Reload(designation);
            return designation;
        }

        public Designation DeleteDesignation(int id)
        {
            Designation designation = GetDesignationById(id);
            if (designation == null)
                throw new Exception("Designation not found!");
            
            _unitOfWork.DesignationRepository.Delete(designation);
            _unitOfWork.SaveChanges();
            return designation;
        }
    }
}
