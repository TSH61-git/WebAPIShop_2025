using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Users
    {
        public int UserId { get; set; }

        [EmailAddress, Required]
        public string UserEmail { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }

        [StringLength(maximumLength: 8, ErrorMessage = "password must be 8 chars max"), MinLength(4)]
        public string UserPassword { get; set; }

    }

}
