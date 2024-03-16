using System.ComponentModel.DataAnnotations;

namespace CPRO2211_Assign3.Models
{
    public class AccommodationViewModel
    {

        [Phone(ErrorMessage = "Invalid phone number format")]
        public string AccommodationPhone { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address format")]
        public string AccommodationEmail { get; set; }
    }
}
