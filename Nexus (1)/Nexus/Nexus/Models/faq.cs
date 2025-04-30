using System.ComponentModel.DataAnnotations;

namespace Nexus.Models
{
    public class faq
    {
        [Key]
     public int id { get; set; }
        public string faq_sub { get; set; }
        public string faq_ques { get; set; }
       public  string faq_ans { get; set; } 
    }
}
