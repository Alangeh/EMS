
using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class Health : OthersBaseEntity
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string MedicalDiagnosis { get; set; } = string.Empty;
        [Required]
        public string MedicalRecommendation { get; set; } = string.Empty;
    }
}
