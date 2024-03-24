
using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class Sanction : OthersBaseEntity
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string SanctionName { get; set; } = string.Empty;
        [Required]
        public DateTime SactionDate { get; set; }

        public SanctionType? SanctionType { get; set; }
        [Required]
        public int SanctionTypeId { get; set; }
    }
}
