using Identity.Modals.Entity;
using System.ComponentModel.DataAnnotations;

namespace Identity.Modals
{
    public class Employee: IEntity
    {
        [Key]
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateOnly DOB { get; set; }
        public string Address { get; set; }
        public string NIC { get; set; }
        public int DesignationId { get; set; }
        public int DepartmentId { get; set; }

        public virtual Company? Company { get; set; }
        public virtual Designation? Designation { get; set; }
        public virtual Department? Department { get; set; }

        #region Audit Fields
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        #endregion
    }
}
