using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Maqeem.Models
{
    public class Buyer
    {
        public uint BuyerID { get; set; }

        [Required(ErrorMessage="Please enter your Name"),MaxLength(50)]
        public string? BuyerName { get; set; }

        [Required(ErrorMessage="Please enter your Address"),MaxLength(200)]
        public string? BuyerAddress { get; set; }

        [Required(ErrorMessage="Please enter your Email"),RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Your Email is not valid.")]
        public string? BuyerEmail { get; set; }

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

