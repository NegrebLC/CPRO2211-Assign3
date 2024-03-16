using System.ComponentModel.DataAnnotations;

namespace CPRO2211_Assign3.Models
{
    public class ActivityViewModel
    {
        [Required(ErrorMessage = "At least one activity is required")]
        public string ThingToDo1 { get; set; }

        public string? ThingToDo2 { get; set; }

        public string? ThingToDo3 { get; set; }
    }
}
