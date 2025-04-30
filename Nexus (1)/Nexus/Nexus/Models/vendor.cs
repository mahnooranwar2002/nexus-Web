using System.ComponentModel.DataAnnotations;

namespace Nexus.Models
{
    public class vendor
    {
        [Key]
        public int id { get; set; }
        public string vendor_name { get; set; }
        public string vendor_email { get; set; }
        public string vendor_number { get; set; }

        public List<Products> products { get; set; }
    }
}
