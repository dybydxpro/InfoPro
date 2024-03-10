using System.ComponentModel.DataAnnotations;

namespace HumanResource.Models
{
    public class Company
    {
        [Key] 
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyContact { get; set; }
        public string Website { get; set; }
        public string? AdminIdentifire { get; set; }

        #region Audit Field

        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        #endregion
    }

}