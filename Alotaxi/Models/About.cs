using Alotaxi.Web.Attributes.ValidationAttributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alotaxi.Models
{
    public class About
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string BigTitle { get; set; }
        public string Detail { get; set; }
        
        [MaxLength(100)]
        public string Image { get; set; }
        [MaxFileSize(2097152)]
        [AllowedFileTypes("image/jpeg", "image/png")]
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [MaxLength(100)]
        public string BigImage { get; set; }
        [MaxFileSize(2097152)]
        [AllowedFileTypes("image/jpeg", "image/png")]
        [NotMapped]
        public IFormFile BigImageFile { get; set; }


    }
}
