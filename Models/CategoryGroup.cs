using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maqeem.Models
{
    public class CategoryGroup
    {
        [Key,ForeignKey("PropertyID")]
        public Property Property { get; set; }
        [Key,ForeignKey("CategoryID")]
        public Category Category { get; set; }
    }
}

