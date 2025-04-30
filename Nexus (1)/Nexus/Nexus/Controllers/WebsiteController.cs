using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nexus.Models;

namespace Nexus.Controllers
{
    public class WebsiteController : Controller
    {
        private MyContext _context;

        public WebsiteController(MyContext context)
        {
            _context = context;
        }

       /*index*/
        public IActionResult Index()
        {
            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                var userRecord = _context.tbl_Users.Where(e => e.user_Id == int.Parse(login)).ToList();

                mainmodel mydata = new mainmodel()
                {
                    userdetail = userRecord
                };
                return View(mydata);

            }
            else
            {
                return RedirectToAction("user_login", "user");
            }
        }
        /*About*/
        public IActionResult About()
        {
            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            { 
                var userRecord = _context.tbl_Users.Where(e => e.user_Id == int.Parse(login)).ToList();
                mainmodel mydata = new mainmodel()
                {
                    userdetail = userRecord
                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("user_login", "user");
            }
        }
        /*Services*/
        public IActionResult Services()
        { 
            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            { 
                var userRecord = _context.tbl_Users.Where(e => e.user_Id == int.Parse(login)).ToList();

                mainmodel mydata = new mainmodel()
                {
                    userdetail = userRecord
                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("user_login", "user");
            }
        }
        /*Contact*/
        public IActionResult Contact()
        {
            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                var userRecord = _context.tbl_Users.Where(e => e.user_Id == int.Parse(login)).ToList();
             mainmodel mydata = new mainmodel()
                {
                    userdetail = userRecord
                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("user_login", "user");
            }
        }
        [HttpPost]
        public IActionResult Contact(contact cont)
        {

            _context.tbl_contact.Add(cont);
            _context.SaveChanges();
            TempData["msg"] = "Thanks for getting in touch with us.";
            return RedirectToAction("contact");
        }
        /*Plan*/
        public IActionResult plans()
        {
            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                var userRecord = _context.tbl_Users.Where(e => e.user_Id == int.Parse(login)).ToList();
                var connectionPlans =
                 _context.tbl_plans.FromSqlInterpolated($"SELECT * from tbl_Plans where status=1").ToList();
                mainmodel mydata = new mainmodel()
                {
                    plandetails = connectionPlans,
                    userdetail = userRecord
                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("user_login", "user");
            }
        }
        //sreach funtionaity
        [HttpGet]
        public IActionResult plans(string txtsearch)
        {

            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                List<plan> plansdetails = new List<plan>();
                if (string.IsNullOrEmpty(txtsearch))
                {
                    plansdetails =
               _context.tbl_plans.FromSqlInterpolated($"SELECT * from tbl_Plans where status=1").ToList();
                }
                else
                {
                    plansdetails = _context.tbl_plans.FromSqlInterpolated(
              $"SELECT * FROM tbl_plans WHERE status=1 and Type={txtsearch}"
              ).ToList();
                }
                if (plansdetails.Count == 0)
                {
                    TempData["error"] = $"record not found {txtsearch} ";
                }
                var userRecord = _context.tbl_Users.Where(e => e.user_Id == int.Parse(login)).ToList();
                mainmodel mydata = new mainmodel()
                {
                    userdetail = userRecord,
                    plandetails = plansdetails

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("user_login", "user");
            }
        }

          /*FAQ*/
        public IActionResult faq()
        {

            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                var userRecord = _context.tbl_Users.Where(e => e.user_Id == int.Parse(login)).ToList();
                var faqrecord = _context.tbl_faq.ToList();
                mainmodel mydata = new mainmodel()
                {
                    userdetail = userRecord,
                    faqDetails = faqrecord
                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("user_login", "user");
            }
        }
        /*USer profile update*/
        public IActionResult userprofile(int id)
        {

            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                var userRecord = _context.tbl_Users.Where(e => e.user_Id == int.Parse(login)).ToList();
                var userdata = _context.tbl_Users.Find(id);
                mainmodel mydata = new mainmodel()
                {
                    userdetail = userRecord,
                    userdata = userdata

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("user_login", "user");
            }
        }
        [HttpPost]
        public IActionResult userprofile(user user)
        {
            _context.tbl_Users.Update(user);
            _context.SaveChanges();
            return RedirectToAction("index");

        }

       /* for logout  */
        public IActionResult logout()
        {
            HttpContext.Session.Remove("user_session");
            return RedirectToAction("user_login", "user");
        }
        /*waited page*/
        public IActionResult waitedpage()
        {
            return View();
        }
        /*plan subcribed*/
        public IActionResult plansubcribed(int id)
        {
            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                var userRecord = _context.tbl_Users.Where(e => e.user_Id == int.Parse(login)).ToList();
                List<Products> getproducts = _context.tbl_products.ToList();
                ViewData["productDropdown"] = getproducts;

                var find_id = _context.tbl_plans.Find(id);
                mainmodel mydata = new mainmodel()
                {
                 
                    products_deatils = getproducts,
                    userdetail = userRecord
                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("user_login", "user");
            }
        }
        [HttpPost]
        public IActionResult plansubcribed(int id, plansubcribed plansub)
        {

            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                var userRecord = _context.tbl_Users.Where(e => e.user_Id == int.Parse(login)).ToList();

               
                plansub.FeasibilityStatus = "Not Feasible";

                var find_id = _context.tbl_plans.Find(id);
                plansub.user_id = int.Parse(login);
                var planName = find_id.Name;
                plansub.plan_name = planName;
                var charges = find_id.Charges;
                plansub.charges = charges;
                var type = find_id.Type;
                if (type == "Dial-Up")
                {
                    Random random = new Random();
                    int number_Dup = random.Next(100000000, 999999999);
                    var numb = "D-02" + number_Dup.ToString();
                    plansub.order_id = numb;

                }
                else if (type == "Broadband")
                {
                    Random random = new Random();
                    int number_Dup = random.Next(100000000, 999999999);
                    var numb = "B-03" + number_Dup.ToString();
                    plansub.order_id = numb;
                }
                else if (type == "Landline")
                {
                    Random random = new Random();
                    int number_Dup = random.Next(100000000, 999999999);
                    var numb = "L-06" + number_Dup.ToString();
                    plansub.order_id = numb;
                }

                mainmodel mydata = new mainmodel()
                {
                    
                    planData = find_id,
                    userdetail = userRecord,


                };
                plansub.payment = "Due";
                _context.tbl_plansubcribed.Add(plansub);
                _context.SaveChanges();
                TempData["order_id"] = "your order_id is " + plansub.order_id;
                TempData["msg"] = "your plan is subcribed successfully please wait for admin approvel";
                return RedirectToAction("plansubcribed");

            }
            else
            {
                return RedirectToAction("user_login", "user");
            }
        }
          /*for the view the details of the plan subcribed*/
          public IActionResult plansubdetails()
        {
            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                
                var userRecord = _context.tbl_Users.Where(e => e.user_Id == int.Parse(login)).ToList();
                var plansubRecord = _context.tbl_plansubcribed.Where(e => e.user_id == int.Parse(login)).ToList();
                if (plansubRecord.Count==0)
                {
                    TempData["msg"] = "you do not subcribed any plan connection";
                }
                mainmodel mydata = new mainmodel()
                {
                    userdetail=userRecord,
                    plansubdetails= plansubRecord
                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("user_login", "user");
            }
        }


        /*for track your plan*/
        public IActionResult trackyourplan()
        {
            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                var userRecord = _context.tbl_Users.Where(e => e.user_Id == int.Parse(login)).ToList();
                mainmodel mydata = new mainmodel()
                {
                    userdetail = userRecord
                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("user_login", "user");
            }
        }
        [HttpGet]
        public IActionResult trackyourplan(string txtsearch)
        {

            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                List<plansubcribed> plansdetails = new List<plansubcribed>();
                if (string.IsNullOrEmpty(txtsearch))
                {
        
                }
                else
                {
                    plansdetails = _context.tbl_plansubcribed.FromSqlInterpolated(
                    $"SELECT * FROM tbl_plansubcribed WHERE order_id ={txtsearch} or user_name={txtsearch}"
                  ).ToList();
                }
                if (plansdetails.Count == 0)
                {
                    TempData["error"] = $"record not found {txtsearch} ";


                }
                var userRecord = _context.tbl_Users.Where(e => e.user_Id == int.Parse(login)).ToList();



                mainmodel mydata = new mainmodel()
                {
                    userdetail = userRecord,
                    plansubdetails = plansdetails

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("user_login", "user");
            }
        }
         /*Packages */
        public IActionResult packages()
        {

            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                var userRecord = _context.tbl_Users.Where(e => e.user_Id == int.Parse(login)).ToList();
                var schemes = _context.tbl_schemes.ToList();
                mainmodel mydata = new mainmodel()
                {
                    schemedetails = schemes,
                    userdetail = userRecord
                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("user_login", "user");
            }

        }
        public IActionResult packagesbcribed(int id)
        {

            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                var find_id = _context.tbl_schemes.Find(id);
                List<Products> getproducts = _context.tbl_products.ToList();
                ViewData["productDropdown"] = getproducts;
                var userRecord = _context.tbl_Users.Where(e => e.user_Id == int.Parse(login)).ToList();

                mainmodel mydata = new mainmodel()
                {
                    schemedata=find_id,
                    products_deatils = getproducts,
                    userdetail = userRecord
                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("user_login", "user");
            }
        }
        [HttpPost]
        public IActionResult packagesbcribed(int id, schemesubcribed plansub)
        {

            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                var userRecord = _context.tbl_Users.Where(e => e.user_Id == int.Parse(login)).ToList();
                var find_id = _context.tbl_schemes.Find(id);
                var planName = find_id.schemesname;
                plansub.plan_name = planName;
                var charges = find_id.price;
                plansub.charges = charges;
                plansub.discount = find_id.discount;

                /*for generate the random numbers*/
                Random random = new Random();
                int number_Dup = random.Next(100000000, 999999999);
                var numb = number_Dup.ToString();
                plansub.order_id = numb;


                mainmodel mydata = new mainmodel()
                {
                    userdetail = userRecord,


                };
                _context.tbl_schemesubcribed.Add(plansub);

                _context.SaveChanges();
                TempData["order_id"] = "your order_id is " + plansub.order_id;
                TempData["msg"] = "your plan is subcribed successfully please wait for admin approvel";
                return RedirectToAction("packagesbcribed");

            }
            else
            {
                return RedirectToAction("user_login", "user");
            }
        }
        /*feedback*/
        public IActionResult feedback()
        {

            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                var userRecord = _context.tbl_Users.Where(e => e.user_Id == int.Parse(login)).ToList();

                mainmodel mydata = new mainmodel()
                {
                    userdetail = userRecord,

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("user_login", "user");
            }
        }
        [HttpPost]
        public IActionResult feedback(feedback feedback)
        {
            _context.tbl_feedback.Add(feedback);
            _context.SaveChanges();
            TempData["msg"] = "your feedback is submited successfully";
            return RedirectToAction("feedback");
        }
        public IActionResult trackyourschemes()
        {

            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                var userRecord = _context.tbl_Users.Where(e => e.user_Id == int.Parse(login)).ToList();
                mainmodel mydata = new mainmodel()
                {
                    userdetail = userRecord
                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("user_login", "user");
            }
        }
        [HttpGet]

        public IActionResult trackyourschemes(string txtsearch)
        {

            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                List<schemesubcribed> details = new List<schemesubcribed>();
                if (string.IsNullOrEmpty(txtsearch))
                {

                }
                else
                {
                    details = _context.tbl_schemesubcribed.FromSqlInterpolated(
                      $"SELECT * FROM tbl_schemesubcribed WHERE order_id ={txtsearch} or user_name={txtsearch}"
                    ).ToList();
                }
                if (details.Count == 0)
                {
                    TempData["error"] = $"record not found {txtsearch} ";


                }
                var userRecord = _context.tbl_Users.Where(e => e.user_Id == int.Parse(login)).ToList();



                mainmodel mydata = new mainmodel()
                {
                    userdetail = userRecord,
                    schemesubcribedteails = details

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("user_login", "user");
            }
        }
    }


}



