using System.ComponentModel.DataAnnotations;

namespace Maskan.Models
{
    public class DealType
    {
        public uint DealTypeID { get; set; }
        [Required(ErrorMessage="Please enter Type of the deal(Rental or Purchase)"),MaxLength(100)]
        public string? Type { get; set; }

        public virtual IEnumerable<Deal>? Deals { get; set; }
        public virtual IEnumerable<Property>? Properties { get; set; }
    }
}

