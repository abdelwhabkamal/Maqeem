using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Maskan.Models
{
    public class Property
    {
        public uint PropertyID { get; set; }

        [Required(ErrorMessage="Please enter Location of the property"),MaxLength(100)]
        public string? Location { get; set; }

        public string? GoogleMapsLink { get; set; }
        
        [Required]
        public uint Area { get; set; }
        [Required]
        public uint Price { get; set; }
        [Required]
        public uint BedsNum { get; set; }
        [Required]
        public uint RoomsNum { get; set; }
        [Required]
        public uint BathsNum { get; set; }
        [Required]
        public uint Type { get; set; }
        [Required]
        public uint Level { get; set; }
        [Required]
        public uint Furnished { get; set; }
        [Required]
        public uint Region { get; set; }

        public uint DealTypeID { get; set; }
        [JsonIgnore]
        public virtual DealType? DealType { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<CategoryGroup>? CategoryGroups { get; set; }
        [JsonIgnore]
        public virtual Country? Country { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<Images>? Images { get; set; }
    }
}

