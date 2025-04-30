using System.ComponentModel.DataAnnotations;

namespace Nexus.Models
{
    public class schemesubcribed
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
        public int charges { get; set; }
        public int discount { get; set; }
        public DateTime GetDate { get; set; } = DateTime.Now;
        public int status { get; set; } = 0;
        public string status_updates { get; set; } = "Deactive";
        public int GenerateBillstatus { get; set; } = 0;
        public string GenerateBillstatus_update { set; get; } = "The bill is not generated yet ";
        public string payment { get; set; } = "Due";
        public string FeasibilityStatus { get; set; } = "Not Feasible";
        public string date { get; set; } = "not approved!";
        public string contact { get; set; } = "03350312358";
        public string account_id { get; set; } = "Account id is not Found";

/*for the product ID*/
        public int  product_id { get; set; }
        public Products product { get; set; }

    }
}
