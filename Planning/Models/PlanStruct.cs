using System.ComponentModel.DataAnnotations;
using Planning.Models.Entity;

namespace Planning.Models
{
    public class PlanStruct : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public int DayCount { get; set; }

        #region Audit Fields
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        #endregion
    }
}
