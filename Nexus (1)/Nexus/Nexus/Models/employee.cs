using System.ComponentModel.DataAnnotations;

namespace Nexus.Models
{
    public class employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string user_name { get; set; }
        [Required]
        public string User_password { get; set; }
        [Required]
        public int age { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int status { get; set; } = 1;
        public string status_update { get; set; } = "Active";
        public int Position_id { get; set; }
        public positions positions { get; set; }

    }
}
