using Alotaxi.Web.Attributes.ValidationAttributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alotaxi.Models
{
    public class Settings
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string Tiktok { get; set; }
        public string Linkedin { get; set; }
        public string AppStore { get; set; }
        public string PlayStore { get; set; }
        public string BusinessTitle { get; set; }
        public string BusinessDescription { get; set; }
        [MaxLength(100)]
        public string Image { get; set; }
        [MaxFileSize(2097152)]
        [AllowedFileTypes("image/jpeg", "image/png")]
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
