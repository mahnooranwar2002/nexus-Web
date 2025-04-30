using System.ComponentModel.DataAnnotations;

namespace Nexus.Models
{
    public class schemesOutlet
    {
        [Key]

        public int Order_Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Scheme_Id { get; set; }
        public int Product_ID { get; set; }
       
        public DateTime GetDate { get; set; } = DateTime.Now;
        public scheme schemes { get; set; }
        public Products product { get; set; }
    }
}
