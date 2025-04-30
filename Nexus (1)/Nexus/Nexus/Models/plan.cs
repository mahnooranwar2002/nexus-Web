using System.ComponentModel.DataAnnotations;

namespace Nexus.Models
{
    public class plan
    {
        [Key]

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Charges { get; set; }
        public int status { get; set; } = 1;
        public string status_update { get; set; } = "Active";
        public List<planOutlet> plandetails { get; set; }


    }
}
