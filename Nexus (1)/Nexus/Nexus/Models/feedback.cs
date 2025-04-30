using System.ComponentModel.DataAnnotations;

namespace Nexus.Models
{
    public class feedback
    {
        [Key]
        public int id { get; set; }
        public string user_name { get; set; }
        public string user_email { get; set; }
        public string massage { get; set; }
    }
}
