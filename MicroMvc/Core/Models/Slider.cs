using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Slider:BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; } = null!;
        [Required]
        [StringLength(150)]
        public string Description { get; set; } = null!;
        public string? RedirectUrl { get; set; }
        public string ImageUrl {  get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

    }
}
