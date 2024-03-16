using System.ComponentModel.DataAnnotations;

namespace CPRO2211_Assign3.Models
{
    public class CreateViewModel
    {
        [Required]
        [Display(Name = "Destination")]
        public string Destination { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Accommodation")]
        public string? Accommodation { get; set; }
    }
}
