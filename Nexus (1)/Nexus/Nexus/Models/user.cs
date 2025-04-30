using System.ComponentModel.DataAnnotations;

namespace Nexus.Models
{
    public class user
    {
        [Key]

        public int user_Id { get; set; }

        public string user_Name { get; set; }

        public string user_Email { get; set; }

        public string user_Password { get; set; }

        public int user_Status { get; set; } = 1;
        public string status_updates { get; set; } = "active";
    }
}
