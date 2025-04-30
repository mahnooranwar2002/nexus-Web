
using System.ComponentModel.DataAnnotations;

namespace Nexus.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int Price { get; set; }
        public int Quantity { get; set; }
        public vendor vendors { get; set; }
        public int Vendor_Id { get; set; }

        public List<plansubcribed> planSubdetails { get; set; }
        public List<schemesubcribed> schemesDetails { get; set; }

        public List<schemesOutlet> SchemesOutlets { get; set; }
         public List<planOutlet> productDetail { get; set; }

    }
}
