using System.ComponentModel.DataAnnotations;

namespace Nexus.Models
{
    public class retailshop
    {
        [Key]

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Area { get; set; }
        [Required]
        public int Contact { get; set; }
        
    }
}
