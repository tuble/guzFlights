using System.ComponentModel.DataAnnotations;

namespace guzFlightsUltra.BindingModels.User
{
    public class EditBindingModel
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Enter Valid SSN!")]
        public string SSN { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }
    }
}
