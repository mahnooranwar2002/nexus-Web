using System.ComponentModel.DataAnnotations;

namespace Nexus.Models
{
    public class contact
    {
        [Key]
        public int id { get; set; }
        public string user_name { get; set; }
        public string  user_email { get; set; }
        public string user_msg { get; set; }
    }
}
