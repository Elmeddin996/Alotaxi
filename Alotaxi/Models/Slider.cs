﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Alotaxi.Web.Attributes.ValidationAttributes;

namespace Alotaxi.Models
{
    public class Slider
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }
        public string Description { get; set; }
        [MaxLength(100)]
        public string Image { get; set; }
        public string ButtonText { get; set; }
        [MaxLength(250)]
        public string BtnUrl { get; set; }

        [MaxFileSize(2097152)]
        [AllowedFileTypes("image/jpeg", "image/png")]
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
