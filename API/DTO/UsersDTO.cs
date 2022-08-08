namespace API.DTO
{
    public class UsersDTO : BaseDTO
    {
        public long UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
