using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Maqeem.Models
{
    public class Category
    {
        public uint CategoryID { get; set; }

        [Required(ErrorMessage="Please enter Category Name"),MaxLength(50)]
        public string? CategoryName { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<CategoryGroup>? CategoryGroups { get; set; }
    }
}

