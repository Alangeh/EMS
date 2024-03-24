
using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class Employee : BaseEntity
    {
        [Required]
        public string? CivilId { get; set; }
        [Required]
        public string? Fullname { get; set; }
        [Required]
        public string? FileNumber { get; set; }
        [Required]
        public string? JobTitle { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required, DataType(DataType.PhoneNumber)]
        public string? Telephone { get; set; }
        [Required]
        public string? Picture { get; set; }
        public string? Other { get; set; }

        #region Relationship properties
        public Branch? Branch { get; set; }
        public int BranchId { get; set; }
        public Town? Town { get; set; }
        public int TownId { get; set; }
        #endregion
    }
}
