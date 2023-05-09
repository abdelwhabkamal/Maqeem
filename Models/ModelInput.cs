using System;
using System.ComponentModel.DataAnnotations;

namespace Maskan.Models
{
	public class ModelInput
	{

        [Required]
        public uint Area { get; set; }
        [Required]
        public uint RoomsNum { get; set; }
        [Required]
        public uint BathsNum { get; set; }
        [Required]
        public uint Type { get; set; }

        public uint Furnished { get; set; }
        [Required]
        public uint Region { get; set; }

    }
}

