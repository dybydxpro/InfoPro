using HumanResource.Models;

namespace HumanResource.Services.Context
{
    public interface IDesignationService
    {
        List<Designation> GetDesignations();
        Designation GetDesignationById(int id);
        Designation CreateDesignation(Designation designation);
        Designation UpdateDesignation(Designation designation);
        Designation DeleteDesignation(int id);
    }
}
