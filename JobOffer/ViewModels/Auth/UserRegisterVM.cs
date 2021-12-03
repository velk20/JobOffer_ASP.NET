using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobOffer.ViewModels.Auth
{

    public class UserRegisterVM
    {
        [Required]
        [MaxLength(20)]
        public string Username { get; set; }
        [Required]
        [MinLength(5,ErrorMessage = "The minimum password length is 5.")]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
