namespace Maqeem.Models
{
    public class CategoryGroup
    {
        public int CategoryGroupID { get; set; }
        
        public virtual Property? Property { get; set; }
        public virtual Category? Category { get; set; }
    }
}

