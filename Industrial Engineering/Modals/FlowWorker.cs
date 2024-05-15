using Industrial_Engineering.Modals.Entity;
using System.ComponentModel.DataAnnotations;

namespace Industrial_Engineering.Modals
{
    public class FlowWorker : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int CompanyId { get; set; }

        public int EmployeeId { get; set; }
        public int ProductionFloorId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual ProductionFloor ProductionFloor { get; set; }

        #region Audit Fields
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        #endregion
    }
}
