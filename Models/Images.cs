using System.ComponentModel.DataAnnotations;

namespace Maqeem.Models
{
    public class Images
    {
        public uint ImagesID { get; set; }
        [Required(ErrorMessage="Please Enter Property image link")]
        public string? ImageLink { get; set; }

        public virtual Property? Property { get; set; }
    }
}

