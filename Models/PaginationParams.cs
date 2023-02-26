using System;
namespace Maskan.Models
{
	public class PaginationParams
	{
		private const int MaxNumOfRows = 9;
		private int itemsPerPage;
		public int page { get; set; } = 1;
		public int ItemsPerPage 
		{
			get=>itemsPerPage;
			set=>itemsPerPage=value>MaxNumOfRows?MaxNumOfRows:value; 
		}
	}
}