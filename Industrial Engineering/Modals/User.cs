using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Industrial_Engineering.Modals
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int AuthId { get; set; }
        public string? UserIdentifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        [NotMapped]
        public string? Password { get; set; }

        public Company? Company { get; set; }

        #region Audit Field
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        #endregion
    }
}
