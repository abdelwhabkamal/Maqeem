using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Maqeem.Models
{
    public class Seller
    {
        public uint SellerID { get; set; }

        [Required(ErrorMessage="Please enter your Name"),MaxLength(50)]
        public string? SellerName { get; set; }

        [Required(ErrorMessage="Please enter your Address"),MaxLength(200)]
        public string? SellerAddress { get; set; }
        
        [Required(ErrorMessage="Please enter your Email"),RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Your Email is not valid.")]
        public string? SellerEmail { get; set; }

        public string? PhoneNum { get; set; }

        [Required(ErrorMessage ="Please enter your National ID")]
        public ulong NationalID { get; set; }

        public uint AdminID { get; set; }
        [JsonIgnore]
        public virtual Admin? Admin { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<Deal>? Deals { get; set; }
    }
}

