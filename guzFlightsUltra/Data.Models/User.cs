using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace guzFlightsUltra.Data.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
 
        [Required]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Enter Valid SSN!")]
        public string SSN { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        public ICollection<IdentityUserRole<string>> Roles { get; set; } = new HashSet<IdentityUserRole<string>>();

    }
}