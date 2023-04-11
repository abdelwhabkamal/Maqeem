using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Maskan.Models
{
    public class Images
    {
        public uint ImagesID { get; set; }
        [Required(ErrorMessage="Please Enter Property image link")]
        public string? ImageLink { get; set; }

        public uint PropertyID{ get; set; }
        [JsonIgnore]
        public virtual Property? Property { get; set; }
    }
}

