using System.ComponentModel.DataAnnotations;

namespace Maqeem.Models
{
    public class Admin
    {
        public uint AdminID { get; set; }
        [Required(ErrorMessage="Please enter your Name"),MaxLength(50)]
        public string? AdminName { get; set; }
        [Required(ErrorMessage = "Please enter your Email"), RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Your Email is not valid.")]
        public string? AdminEmail { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, ErrorMessage = "Must be Morethan 6 characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(50, ErrorMessage = "Must be Morethan 6 characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string? ConfirmPassword { get; set; }

        public virtual IEnumerable<Seller>? Sellers { get; set; }
        public virtual IEnumerable<Buyer>? Buyers { get; set; }
    }
}

