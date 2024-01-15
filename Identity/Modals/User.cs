namespace Identity.Modals
{
    public class User
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int AuthId { get; set; }
        public string UserIdentifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        #region Audit Field
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        #endregion
    }
}
