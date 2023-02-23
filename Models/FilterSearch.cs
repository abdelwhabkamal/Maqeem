using System;
namespace Maskan.Models
{
	public class FilterSearch
	{
		public DealType DealType { get; set; }
		public string City { get; set; }
		public string Category { get; set; }
		public int BedsNum { get; set; }
		public int BathsNum { get; set; }
		public int Price{ get; set; }
		public int Area{ get; set; }
	}
}

