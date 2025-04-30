using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace Nexus.Models
{
    public class plansubcribed
    {
        [Key]
        public int addtocartid { get; set; }
        public string order_id { get; set; }
        public string plan_name { get; set; }
        public string user_name { get; set; }
        public string user_email { get; set; }
        public string user_number { get; set; }
        public string paymentofmode { get; set; }
        public string pincode { get; set; }
        public string user_address { get; set; }
        public string charges { get; set; }
        public int status { get; set; } = 0;
        public string status_updates { get; set; } = "Deactive";
        public int GenerateBillstatus { get; set; } = 0;
        public string GenerateBillstatus_update { set; get; } = "The bill is not generated yet ";
        public string payment { get; set; }
        public string FeasibilityStatus { get; set; }
        public string date { get; set; } = "not approved!";
        public string contact { get; set; } = "03350312358";
        
        public string account_id { get; set; } = "Account ID not found";


        public int user_id { get; set; }
        public DateTime ordered_date { get; set; } = DateTime.Now;


        /*for the foreign key of the plan details*/
        public int products_id { get; set; }

        public Products productdetails { get; set; }
       
           }
}
