using System.ComponentModel.DataAnnotations;

namespace Nexus.Models
{
    public class positions
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public List<employee> employees { get; set; }


    }
}
