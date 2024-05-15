using System.ComponentModel.DataAnnotations;
using Industrial_Engineering.Modals.Entity;

namespace Industrial_Engineering.Modals
{
    public class ProductionFloor : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int CompanyId { get; set; }

        public string Name { get; set; }
        public double WorkingHours { get; set; }
        public int StyleId { get; set; }

        public virtual Style Style { get; set; }
        public virtual List<FlowWorker> FlowWorkers { get; set; }

        #region Audit Fields
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        #endregion
    }
}
