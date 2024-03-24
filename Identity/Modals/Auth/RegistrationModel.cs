using System.ComponentModel.DataAnnotations;

namespace Identity.Modals.Auth
{
    public class RegistrationModel
    {
        [Required]
        public User User { get; set; }
        [Required]
        public Company Company { get; set; }
    }
}
