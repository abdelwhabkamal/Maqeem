using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Maskan.Models
{
    public class Deal
    {
        public uint DealID { get; set; }
        [Required(ErrorMessage ="Please enter Deal date"),DisplayFormat(DataFormatString = "{0:DD.MM.YYYY}")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage ="Please Enter Property's price")]
        public uint Price { get; set; }

        public uint SellerID{ get; set; }
        [JsonIgnore]
        public virtual Seller? Seller { get; set; }
        public uint BuyerID { get; set; }
        [JsonIgnore]
        public virtual Buyer? Buyer { get; set; }
        public uint DealTypeID{ get; set; }
        [JsonIgnore]
        public virtual DealType? DealType { get; set; }
    }
}

