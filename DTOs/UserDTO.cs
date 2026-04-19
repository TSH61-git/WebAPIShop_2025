using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public record UserLoginDTO
    (
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        string Email,

        [Required(ErrorMessage = "Password is required")]
        string Password
    );

    public record UserRegisterDTO
    (
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        string Email,

        [Required(ErrorMessage = "First name is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 20 characters")]
        string FirstName,

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 20 characters")]
        string LastName,

        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        string Password,

        [Phone(ErrorMessage = "Invalid phone number format")]
        string? Phone,

        string? City,

        string? Street
    );

    public record UserUpdateDTO
    (

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        string Email,

        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        string Password,

        [Required(ErrorMessage = "First name is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 20 characters")]
        string FirstName,

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 20 characters")]
        string LastName,

        [Phone(ErrorMessage = "Invalid phone number format")]
        string? Phone,

        string? City,

        string? Street
    );

    public record UserReadDTO
    (
         int UserId,

         [Required]
         string Email,

         [Required]
         string Role,

         [Required]
         string FirstName,

         [Required]
         string LastName,

         string? Phone,

         string? City,

         string? Street
    );
}