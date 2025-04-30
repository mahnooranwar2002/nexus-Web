using System.ComponentModel.DataAnnotations;

namespace Nexus.Models
{
    public class planOutlet
    {
        [Key]

        public int Order_Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public int Plan_Id { get; set; }
        public int Product_ID { get; set; }
        
        public DateTime GetDate { get; set; } = DateTime.Now;
        public plan plans { get; set; }
        public Products product { get; set; }
    }
}
