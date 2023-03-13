using System;
using System.ComponentModel.DataAnnotations;

namespace Maskan.Models
{
	public class ModelInput
	{
        [Required(ErrorMessage = "Please enter Location of the property"), MaxLength(100)]
        public string? Location { get; set; }
        [Required]
        public uint Area { get; set; }
        [Required]
        public uint RoomsNum { get; set; }
        [Required]
        public uint BathsNum { get; set; }
        [Required]
        public uint Type { get; set; }
        [Required]
        public uint Level { get; set; }
        [Required]
        public uint Furnished { get; set; }
        [Required]
        public uint Region { get; set; }
        [Required]
        public uint DealTypeID { get; set; }
    }
}

