using System.ComponentModel.DataAnnotations;

namespace PrescriptionList.Models
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }

        [Required(ErrorMessage = "Please enter the name of the medicine.")]
        public string MedicationName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Select fill status.")]
        public string FillStatus { get; set; } = "New"; // default to New

        [Required(ErrorMessage = "Please enter the cost.")]
        [Range(0, 10000, ErrorMessage = "The cost must be a positive number.")]
        public double? Cost { get; set; }

        [Required(ErrorMessage = "Please select a request date.")]
        [Display(Name = "Request Date")]
        public DateTime RequestDate { get; set; } = DateTime.Now;
    }
}