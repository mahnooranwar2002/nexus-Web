using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Nexus.Models
{
    public class Admin
    {
        [Key]
        public int admin_id { get; set; }
        public string admin_name { get; set; }
         public string admin_email { get; set; }
        public string admin_password{  get;set;}
        
        public int status { get; set; } = 1;
        public string status_updates { get; set; } = "Active";
       
    }
}
