using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GroupProject.Models
{
    public class UsersAccount
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$", ErrorMessage ="Email is Invalid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "User Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage ="Please Confirm your Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public ICollection<OilPress> OilPresses { get; set; }
        //public ICollection<Factory> Factories { get; set; }
    }
}