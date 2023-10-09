using System.ComponentModel.DataAnnotations;

namespace BrandApi.Models
{
    public class BrandImages
    {
        [Key]
        public int ID { get; set; }
        public  string BrandName { get; set; }
        public Boolean Published { get; set; }
        public  string SvgImage { get; set; }
    }
}
