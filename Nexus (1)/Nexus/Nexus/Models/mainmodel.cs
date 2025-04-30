
using System.Security.Policy;

namespace Nexus.Models
{
    public class mainmodel
    {
        public List<Admin> admindata_record { get; set; }
        public List<Admin> adminsdetail { get; set; }
        public Admin adminsrecord { get; set; }
        public List<user> user_details { get; set; }
        public List<retailshop> Retail_Store { get; set; }
        
        public retailshop retail_stores { get; set; }
        public List<Products> products_deatils { get; set; }
        public Products productData { get; set; }
        public List<positions> positionList { get; set; }
        public positions position_data { get; set; }
        public List<employee> empdetails { get; set; }
        public List<employee> teaminfo { get; set; }
        public employee empData { get; set; }
        public List<plan> plandetails { get; set; }
        public plan planData { get; set; }
        public List<user> userdetail { get; set; }
        public user userdata { get; set; }
        public List<plansubcribed> plansubdetails { get; set; }
        public plansubcribed plansubdata { get; set; }
        public List<contact> contactDetails { get; set; }
        public List<faq> faqDetails { get; set; }
        public faq faqdata { get; set; }
        public List<vendor> vendordetails { get; set; }
        public vendor vendordata { get; set; }
        public List<scheme> schemedetails { get; set; }
        public scheme schemedata { get; set; }
        public List<schemesubcribed> schemesubcribedteails { get; set; }
        public schemesubcribed subcribeddata { get; set; }
        public List<feedback> feedbackDetails { get; set; }
        public feedback feedbackdata { get; set; }
        public List<schemesOutlet> schemesBook { get; set; }
        public List<planOutlet> planoutlet { get; set; }
 
    }
}
