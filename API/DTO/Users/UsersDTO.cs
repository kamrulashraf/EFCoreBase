using System.ComponentModel.DataAnnotations;

namespace API.DTO.Users
{
    public class UsersDTO : BaseDTO
    {
        public long UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

    }
}
