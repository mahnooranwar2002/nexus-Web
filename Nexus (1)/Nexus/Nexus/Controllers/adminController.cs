using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nexus.Models;

namespace Nexus.Controllers
{
    public class adminController : Controller
    {
        private MyContext _context;
        private IWebHostEnvironment _evn;
        /**/
        public adminController(MyContext context, IWebHostEnvironment env)
        {
            _context = context;
            _evn = env;
        }
        /*for login of admin*/
        public IActionResult admin_login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult admin_login(string admin_em, string admin_pass)
        {
            var admin_record = _context.tbl_adminsrecords.FirstOrDefault(e => e.admin_email == admin_em);
            if (admin_record != null && admin_record.admin_password == admin_pass)
            {
                HttpContext.Session.SetString("admin_session", admin_record.admin_id.ToString());
                if (admin_record.status == 0)
                {
                    return RedirectToAction("waitedpage", "website");
                }
                else
                {

                    return RedirectToAction("index");
                }
            }
            else
            {
                ViewBag.error = "incorrect email or password";
                return View();
            }

        }

        /*for index*/
        public IActionResult Index()
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                var count_user = _context.tbl_Users.Count();
                var count_admin = _context.tbl_adminsrecords.Count();
                var emp_count = _context.tbl_employees.Count();
                var product_count = _context.tbl_products.Count();
                var plan_count = _context.tbl_plans.Count();
                var retailstore_count = _context.tbl_retail_stores.Count();
                var package_count = _context.tbl_schemes.Count();
                var vendors_count = _context.tbl_vendors.Count();
                var schemes_count=_context.tbl_schemes.Count();
                var feedback_count = _context.tbl_feedback.Count();
                var faq_count = _context.tbl_faq.Count();
                var schemessub_count = _context.tbl_schemesubcribed.Count();
                var schemesbooked = _context.tbl_bookedschemes.Count();
                var plansub_count = _context.tbl_plansubcribed.Count();
                var planbooked = _context.tbl_bookedplans.Count();
              
                TempData["feedbac_count"] = feedback_count;
                TempData["count_user"] = count_user;
                TempData["vendor_count"] = vendors_count;
                TempData["count_admin"] = count_admin;
                TempData["count_emp"] = emp_count; 
                TempData["product_count"] = product_count;
                TempData["plan_count"] = plan_count;
                TempData["package_count"] =package_count;
                TempData["retailstore_count"] = retailstore_count;
                TempData["faq_count"] = faq_count;
                TempData["schemessub_count"] = schemessub_count + schemesbooked;
                TempData["plansub_count"] = plansub_count+planbooked;


                mainmodel mydata = new mainmodel()
                
                { admindata_record = adminRecords };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login");
            }

        }
       /*to view the datails of admin*/
        public IActionResult admindetails()
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                var admindsdetails = _context.tbl_adminsrecords.ToList();
                mainmodel mydata = new mainmodel()
                {
                    admindata_record = adminRecords,
                    adminsdetail = admindsdetails
                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login");
            }
        }
        /*for sreach the admin*/
        [HttpGet]
        public IActionResult admindetails(string txtsearch)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                List<Admin> admindsdetails = new List<Admin>();
                if (string.IsNullOrEmpty(txtsearch))
                {
                    admindsdetails = _context.tbl_adminsrecords.ToList();
                }
                else
                {
                    admindsdetails = _context.tbl_adminsrecords.FromSqlInterpolated(
                     $"SELECT * FROM tbl_adminsrecords WHERE admin_name = {txtsearch} "
                      ).ToList();
                }
                if (admindsdetails.Count == 0)
                {
                    TempData["error"] = $"record not found {txtsearch} ";
                }
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                var admindsdetail = _context.tbl_adminsrecords.ToList();
                mainmodel mydata = new mainmodel()
                {
                    admindata_record = adminRecords,
                    adminsdetail = admindsdetails
                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login");
            }
        }

        /*for logout*/
        public IActionResult logout()
        {
            HttpContext.Session.Remove("admin_session");
            return RedirectToAction("admin_login");
        }

        /*for delete the admin*/
        public IActionResult admin_delete(int id)
        {
            var find_id = _context.tbl_adminsrecords.Find(id);
            _context.Remove(find_id);
            _context.SaveChanges();
            return RedirectToAction("admindetails");
        }


        /*for status*/
        public IActionResult admin_status(int id)
        {

            var find_id = _context.tbl_adminsrecords.Find(id);
            if (find_id.status == 1)
            {
                find_id.status = 0;

                find_id.status_updates = "Deactive";
            }
            else
            {
                find_id.status = 1;
                find_id.status_updates = "Active";
            }
            _context.SaveChanges();
            return RedirectToAction("admindetails");
        }
        /*for admin update*/
        public IActionResult admin_Update(int id)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                var find_id = _context.tbl_adminsrecords.Find(id);
                mainmodel mydata = new mainmodel()
                {
                    admindata_record = adminRecords,
                    adminsrecord = find_id


                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login");
            }

        }
        /*for actually update*/
        [HttpPost]
        public IActionResult admin_Update(Admin admin_record)

        {
            _context.tbl_adminsrecords.Update(admin_record);
            _context.SaveChanges();
            return RedirectToAction("admindetails");
        }

        /*add the information of new admin*/
        public IActionResult add_admin()
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                mainmodel mydata = new mainmodel()
                {
                    admindata_record = adminRecords,
                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login");
            }
        }
        [HttpPost]
        public IActionResult add_admin(Admin added_admin,string admin_email)
        {

            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var exsitingadmin = _context.tbl_adminsrecords.FirstOrDefault(u => u.admin_email == added_admin.admin_email);
                if (exsitingadmin != null)
                {
                    TempData["msg"] = "The Admin Email  is Already Registered!";
                    return RedirectToAction("add_admin");
                }
                else
                {
                    TempData["massage"] = "The Admin is successfully added";
                    _context.tbl_adminsrecords.Add(added_admin);
                    _context.SaveChanges();
                    return RedirectToAction("add_admin");
                }
            }
            else
            {
                return RedirectToAction("admin_login");
            }

        }

        /*user details*/
        public IActionResult user_details()
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                var user_detail = _context.tbl_Users.ToList();
                mainmodel mydata = new mainmodel()
                {
                    admindata_record = adminRecords,
                    user_details = user_detail
                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login");
            }
        }
        [HttpGet]

        public IActionResult user_details(string txtsearch)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                List<user> user_details = new List<user>();
                if (string.IsNullOrEmpty(txtsearch))
                {
                    user_details = _context.tbl_Users.ToList();
                }
                else
                {
                    user_details = _context.tbl_Users.FromSqlInterpolated(
              $"SELECT * FROM tbl_Users WHERE user_Name = {txtsearch} or user_Email={txtsearch}"
              ).ToList();
                }
                if (user_details.Count == 0)
                {
                    TempData["error"] = $"record not found {txtsearch} ";
                }
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                var user_detail = _context.tbl_Users.ToList();
                mainmodel mydata = new mainmodel()
                {
                    admindata_record = adminRecords,
                    user_details = user_details
                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login");
            }
        }
        /* for update the user_status*/
        public IActionResult user_status(int id)
        {
            var find_id = _context.tbl_Users.Find(id);

            if (find_id.user_Status == 1)
            {
                find_id.user_Status = 0;
                find_id.status_updates = "Deactive";
            }
            else
            {
                find_id.user_Status = 1;
                find_id.status_updates = "Active";
            }
            _context.SaveChanges();
            return RedirectToAction("user_details");
        }
        /* for update the user_delete*/
        public IActionResult user_delete(int id)
        {
            var delete_id = _context.tbl_Users.Find(id);
            _context.tbl_Users.Remove(delete_id);
            _context.SaveChanges();
            return RedirectToAction("user_details");
        }
         /*for contact*/

        public IActionResult contactFetch()
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                var contactdetail = _context.tbl_contact.ToList();
                mainmodel mydata = new mainmodel()
                {
                    admindata_record = adminRecords,
                    contactDetails = contactdetail

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login");
            }
        }
        /*for delete the contact Delete*/
        public IActionResult delete_contact(int id)
        {
            var del = _context.tbl_contact.Find(id);
            _context.tbl_contact.Remove(del);
            _context.SaveChanges();
            return RedirectToAction("contactFetch");
        }
        [HttpGet]
        public IActionResult contactFetch(string txtsearch)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                List<contact> contact_details = new List<contact>();
                if (string.IsNullOrEmpty(txtsearch))
                {
                    contact_details = _context.tbl_contact.ToList();
                }
                else
                {
                    contact_details = _context.tbl_contact.FromSqlInterpolated(
              $"SELECT * FROM tbl_contact WHERE user_name = {txtsearch} or user_email={txtsearch}"
              ).ToList();
                }
                if (contact_details.Count == 0)
                {
                    TempData["error"] = $"record not found {txtsearch} ";
                }
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                var user_detail = _context.tbl_Users.ToList();
                mainmodel mydata = new mainmodel()
                {
                    admindata_record = adminRecords,
                    contactDetails = contact_details
                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login");
            }
        }
        
        /*for faq insert*/
        public IActionResult faqinsert()
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
            
                mainmodel mydata = new mainmodel()
                {
                    admindata_record = adminRecords,
                    

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login");
            }

        }
        /*for the fetch the faq on admin dashboard*/
        public IActionResult fetchfaq()
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                var faqdetail = _context.tbl_faq.ToList();
                mainmodel mydata = new mainmodel()
                {
                    admindata_record = adminRecords,
                    faqDetails = faqdetail

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login");
            }
        }
        [HttpGet]
        public IActionResult fetchfaq(string txtsearch)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                List<faq> faq_details = new List<faq>();
                if (string.IsNullOrEmpty(txtsearch))
                {
                    faq_details = _context.tbl_faq.ToList();
                }
                else
                {
                    faq_details = _context.tbl_faq.FromSqlInterpolated(
                     $"SELECT * FROM tbl_faq WHERE faq_sub = {txtsearch} "
                      ).ToList();
                }
                if (faq_details.Count == 0)
                {
                    TempData["error"] = $"record not found {txtsearch} ";
                }
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                var user_detail = _context.tbl_Users.ToList();
                mainmodel mydata = new mainmodel()
                {
                    admindata_record = adminRecords,
                   faqDetails=faq_details
                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login");
            }
        }
        [HttpPost]
        public IActionResult faqinsert(faq qa)
        {
            _context.tbl_faq.Add(qa);
            _context.SaveChanges();
            TempData["msg"] = "the faq has been successfully added !";
            return RedirectToAction("faqinsert");

        }

         /*for delete the faq*/
        public IActionResult delete_faq(int id)
        {
            var del = _context.tbl_faq.Find(id);
            _context.tbl_faq.Remove(del);
            _context.SaveChanges();
            return RedirectToAction("fetchfaq");
        }
       /*for the faq Update*/
        public IActionResult update_faq(int id)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                var faqdetail = _context.tbl_faq.Find(id);
                mainmodel mydata = new mainmodel()
                {
                    admindata_record = adminRecords,
                    faqdata=faqdetail

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login");
            }
        }
        [HttpPost]
        public IActionResult update_faq(faq qa)
        {
            _context.tbl_faq.Update(qa);
            _context.SaveChanges();
            return RedirectToAction("fetchfaq");
        }
        /*for fetch the feedback on the admin dashboard*/
        public IActionResult fetch_feedback()
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                var feedbackdetail = _context.tbl_feedback.ToList();
                mainmodel mydata = new mainmodel()
                {
                    admindata_record = adminRecords,
                    feedbackDetails= feedbackdetail

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login");
            }
        }
        [HttpGet]
        public IActionResult fetch_feedback(string txtsearch)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                List<feedback> feedback= new List<feedback>();
                if (string.IsNullOrEmpty(txtsearch))
                {
                   feedback = _context.tbl_feedback.ToList();
                }
                else
                {
                    feedback = _context.tbl_feedback.FromSqlInterpolated(
                     $"SELECT * FROM tbl_feedback  WHERE user_name = {txtsearch} or user_email={txtsearch} "
                      ).ToList();
                }
                if (feedback.Count == 0)
                {
                    TempData["error"] = $"record not found {txtsearch} ";
                }
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                var user_detail = _context.tbl_Users.ToList();
                mainmodel mydata = new mainmodel()
                {
                    admindata_record = adminRecords,
                  feedbackDetails=feedback
                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login");
            }
        }


        /*for delete the data of feedback */
        public IActionResult delete_feedback(int id)
        {
           var del= _context.tbl_feedback.Find(id);
            _context.tbl_feedback.Remove(del);
            _context.SaveChanges();
            return RedirectToAction("fetch_feedback");
        }
       public IActionResult plansuboutlet()
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                var planbooked = _context.tbl_bookedplans.ToList();
                mainmodel mydata = new mainmodel()
                {
                    admindata_record = adminRecords,
                    planoutlet = planbooked

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login");
            }

        }
        [HttpGet]
        public IActionResult plansuboutlet(string txtsearch)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();


                List<planOutlet> details = new List<planOutlet>();
                if (string.IsNullOrEmpty(txtsearch))
                {
                    details = _context.tbl_bookedplans.ToList();
                }
                else
                {
                    details = _context.tbl_bookedplans.FromSqlInterpolated(
                            $"SELECT * FROM tbl_bookedplans  WHERE Name={txtsearch}"
               ).ToList();
                }
                if (details.Count == 0)
                {

                    TempData["error"] = $"record not found {txtsearch} ";
                }
                mainmodel mydata = new mainmodel()
                {
                   admindata_record=adminRecords,
                    planoutlet = details

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }


        }
        public IActionResult planoutlet_delete(int id)
        {
            var del = _context.tbl_bookedplans.Find(id);
            _context.tbl_bookedplans.Remove(del);
            return RedirectToAction("plansuboutlet");
        }
        public IActionResult schmesoutlet()
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                var schmesbooked = _context.tbl_bookedschemes.Include(e => e.schemes).ToList();
                mainmodel mydata = new mainmodel()
                {
                    admindata_record = adminRecords,
                    schemesBook=schmesbooked

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login");
            }

        }
        [HttpGet]
        public IActionResult schmesoutlet(string txtsearch)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {

                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();

                List<schemesOutlet> details = new List<schemesOutlet>();
                if (string.IsNullOrEmpty(txtsearch))
                {
                    details = _context.tbl_bookedschemes.ToList();
                }
                else
                {
                    details = _context.tbl_bookedschemes.FromSqlInterpolated(
                            $"SELECT * FROM tbl_bookedschemes  WHERE Name={txtsearch}"
               ).ToList();
                }
                if (details.Count == 0)
                {

                    TempData["error"] = $"record not found {txtsearch} ";
                }
                mainmodel mydata = new mainmodel()
                {
                   admindata_record=adminRecords,
                    schemesBook = details

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }


        }

        public IActionResult schemeoutlet_delete(int id)
        {
            var del= _context.tbl_bookedschemes.Find(id);
            _context.tbl_bookedschemes.Remove(del);
            _context.SaveChanges();
            return RedirectToAction("schmesoutlet");
        }

    }
}
