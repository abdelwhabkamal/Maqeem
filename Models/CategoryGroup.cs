using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maqeem.Models
{
    public class CategoryGroup
    {
        public int CategoryGroupID { get; set; }
        
        public Property Property { get; set; }
        public Category Category { get; set; }
    }
}

