using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maqeem.Models
{
    public class Category
    {
        [Key]
        public uint CategoryID { get; set; }

        [Required(ErrorMessage="Please enter your name"),MaxLength(50)]
        public string CategoryName { get; set; }

        [ForeignKey("CategoryGroupID")]
        public IEnumerable<CategoryGroup> CategoryGroups { get; set; }
    }
}

