
using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class OverTime : OthersBaseEntity
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required] 
        public DateTime EndDate { get; set; }
        public int NumberOfDays => (EndDate - StartDate).Days;

        public OverTimeType? OverTimeType { get; set; }
        [Required]
        public int OverTimeTypeId { get; set; }
    }
}
