using System.ComponentModel.DataAnnotations;

namespace WebApiShop
{
    public class Users
    {
        public int UserId { get ; set; }

        [EmailAddress, Required]
        public string UserEmail { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }

        [StringLength(maximumLength: 8, ErrorMessage = "password must be 8 chars max"), MinLength(4)]
        public string UserPassword { get; set; }

    }

    public class LoginUsers
    {
        public string LoginUserEmail { get; set; }
        public string LoginUserPassword { get; set; }

    }
}
