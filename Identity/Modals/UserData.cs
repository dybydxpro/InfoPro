namespace Identity.Modals
{
    public class UserData
    {
        public string Id { get; set; }
        public int AuthId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public UserData(string Id, int AuthId, string FirstName, string LastName, string UserName, string Email)
        {
            this.Id = Id;
            this.AuthId = AuthId;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.UserName = UserName;
            this.Email = Email;
        }
    }
}
