using System.ComponentModel.DataAnnotations;

namespace Nexus.Models
{
    public class scheme
    {
        [Key]
        public int id { get; set; }
        public string schemesname { get; set; }
        public string schemescount { get; set; }
        public string schemesDes { get; set; }
        public int price { get; set; }
        public int percentage { get; set; }
        public int discount { get; set;}

        public List<schemesOutlet> schmesdata { get; set; }
    }
}
