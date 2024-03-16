using System.ComponentModel.DataAnnotations;

namespace CPRO2211_Assign3.Models
{
    public class Trip
    {
        [Key]
        public int TripId { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 1, ErrorMessage = "Destination name is required.")]
        public string Destination { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(int.MaxValue)]
        public string? AccommodationPhone { get; set; }

        [DataType(DataType.EmailAddress)]
        [StringLength(int.MaxValue)]
        public string? AccommodationEmail { get; set; }

        [StringLength(int.MaxValue)]
        public string? Accommodation { get; set; }

        [StringLength(int.MaxValue)]
        public string? ThingToDo1 { get; set; }

        [StringLength(int.MaxValue)]
        public string? ThingToDo2 { get; set; }

        [StringLength(int.MaxValue)]
        public string? ThingToDo3 { get; set; }
    }
}
