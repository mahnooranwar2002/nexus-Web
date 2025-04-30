using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Nexus.Models;
using System.Drawing.Printing;

namespace Nexus.Controllers
{
    public class technicalController : Controller
    {
        private MyContext _context;
        private IWebHostEnvironment _env;
        public technicalController(MyContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        /*for the index of technical*/
        public IActionResult Index()
        {
            var login = HttpContext.Session.GetString("emp_session");
            if (login != null)
            {
                TempData["product_count"] = _context.tbl_products.Count();
                TempData["plan_Count"] = _context.tbl_plans.Count();
                TempData["schemes_count"] = _context.tbl_schemes.Count();
                TempData["plansub_count"] = _context.tbl_plansubcribed.Count();
                TempData["schemesub_count"] = _context.tbl_schemesubcribed.Count();
                var empRecord = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();
                mainmodel mydata = new mainmodel()
                {
                    empdetails = empRecord

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("emp_loginform", "employe");
            }
        }
       /*for the update the details of employee*/
        public IActionResult empUpdate(int id)
        {
            var login = HttpContext.Session.GetString("emp_session");
            if (login != null)
            {
                var empRecord = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();
                var empdata = _context.tbl_employees.Find(id);
                mainmodel mydata = new mainmodel()
                {
                    empdetails = empRecord,
                    empData = empdata

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("emp_loginform", "employe");
            }
        }
        [HttpPost]
        public IActionResult empUpdate(employee emp)
        {
            _context.tbl_employees.Update(emp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        /*add new plan*/
        public IActionResult add_plans()
        {
            var login = HttpContext.Session.GetString("emp_session");
            if (login != null)
            {
                List<vendor> getvendors = _context.tbl_vendors.ToList();
              
                var empRecord = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();
                mainmodel mydata = new mainmodel()
                {
                    vendordetails = getvendors,
                    empdetails = empRecord

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }
        }
        [HttpPost]
        public IActionResult add_plans(plan plan)
        {
            _context.tbl_plans.Add(plan);
            _context.SaveChanges();
            TempData["msg"] = "plan is added succesfuuly";
            return RedirectToAction("add_plans");

        }
        /*for the plan details */
        public IActionResult planDeatils()
        {
             var login = HttpContext.Session.GetString("emp_session");
            if (login != null)
            {
                var empRecord = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();
                var plnrecord = _context.tbl_plans.ToList();
                mainmodel mydata = new mainmodel()
                {
                    empdetails = empRecord,
                    plandetails=plnrecord
                };
                return View(mydata);
            }

            else
            {
                return RedirectToAction("emp_loginform", "employe");
            }
        }
        [HttpGet]
        public IActionResult planDeatils(string txtsearch)
        {
            var login = HttpContext.Session.GetString("emp_session");
            if (login != null)
            {
                List<plan> plansdetails = new List<plan>();
                if (string.IsNullOrEmpty(txtsearch))
                {
                    plansdetails = _context.tbl_plans.ToList();
                }
                else
                {
                    plansdetails = _context.tbl_plans.FromSqlInterpolated(
              $"SELECT * FROM tbl_plans WHERE Name = {txtsearch} or Type={txtsearch}"
              ).ToList();
                }
                if (plansdetails.Count == 0)
                {
                    TempData["error"] = $"record not found {txtsearch} ";
                }
                var empRecord = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();
                var plnrecord = _context.tbl_plans.ToList();
                mainmodel mydata = new mainmodel() {
                    empdetails = empRecord,
                    plandetails = plansdetails

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }
        }
        /*for the status update of plan*/
        public IActionResult plans_status(int id)
        {
           var find_Id= _context.tbl_plans.Find(id);
            var status = find_Id.status;
            if (status == 1)
            {
                find_Id.status = 0;
                find_Id.status_update = "Deactive";
            }
            else
            {
                find_Id.status = 1;
                find_Id.status_update = "Active";
            }
            _context.SaveChanges();
            return RedirectToAction("planDeatils");
        }

        /*for delete a connection*/
        public IActionResult delete_plan(int id)
        {
            var pid = _context.tbl_plans.Find(id);
            _context.tbl_plans.Remove(pid);
            _context.SaveChanges();
            return RedirectToAction("planDeatils");
        }
        /*for Update  a connection*/
        public IActionResult plans_updates(int id)
        {
            var login = HttpContext.Session.GetString("emp_session");
            if (login != null)
            {
                var empRecord = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();
                var plandaata = _context.tbl_plans.Find(id);
                mainmodel mydata = new mainmodel()
                {
                   empdetails=empRecord,
                    planData = plandaata
                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("emp_loginform", "employe");
            }
        }
        [HttpPost]
        public IActionResult plans_updates(plan plan)
        {
            _context.tbl_plans.Update(plan);
            _context.SaveChanges();

            return RedirectToAction("planDeatils");
        }
        /*add Product*/
        public IActionResult add_product()
        {
            var login = HttpContext.Session.GetString("emp_session");
            if (login != null)
            {
                var empRecord = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();
                List<vendor> getvendors = _context.tbl_vendors.ToList();
                ViewData["storeDropdown"] = getvendors;
                mainmodel mydata = new mainmodel()
                {
                    empdetails = empRecord,
                    vendordetails = getvendors

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }


        }
        [HttpPost]
     
        public IActionResult add_product(Products pro)
        {
            _context.tbl_products.Add(pro);
            _context.SaveChanges();
            TempData["successfully"] = "The product is added successfully";
            return RedirectToAction("add_product");
        }
        public IActionResult product_details()
        {
            var login = HttpContext.Session.GetString("emp_session");
            if (login != null)
            {
                var empRecord = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();

                var productDetails = _context.tbl_products.Include(e => e.vendors).ToList();

                mainmodel mydata = new mainmodel()
                {
                    products_deatils = productDetails,
                    empdetails = empRecord,


                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }
        }
        [HttpGet]
        public IActionResult product_details(string txtsearch)
        {
            var login = HttpContext.Session.GetString("emp_session");
            if (login != null)
            {
                var empRecord = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();
                List<Products> productsDeatils = new List<Products>();
                if (string.IsNullOrEmpty(txtsearch))
                {
                    productsDeatils = _context.tbl_products.Include(p => p.vendors).ToList();
                }
                else
                {
                    productsDeatils = _context.tbl_products.FromSqlInterpolated(
                           $"SELECT * FROM tbl_products  WHERE Name={txtsearch}").Include(p => p.vendors).ToList();
                }

                if (productsDeatils.Count == 0)
                {
                    TempData["error"] = $"record not found {txtsearch} ";
                }
                mainmodel mydata = new mainmodel()
                {
                  empdetails=empRecord,
                    products_deatils = productsDeatils

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }
        }
        public IActionResult product_delete(int id)
        {
            var del = _context.tbl_products.Find(id);
            _context.tbl_products.Remove(del);
            _context.SaveChanges();
            return RedirectToAction("product_details");
        }
        public IActionResult product_Updates(int id)
        {

            var login = HttpContext.Session.GetString("emp_session");
            if (login != null)
            {
                var empRecord = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();

                var productDetails = _context.tbl_products.Find(id);

                List<vendor> getvendors = _context.tbl_vendors.ToList();
                ViewData["storeDropdown"] = getvendors;
                mainmodel mydata = new mainmodel()
                {
                   empdetails=empRecord,
                    vendordetails = getvendors,
                    productData = productDetails,
                };


                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }

        }
        [HttpPost]
        public IActionResult product_Updates(Products pro)
        {
            _context.tbl_products.Update(pro);
            _context.SaveChanges();
            return RedirectToAction("product_details");
        }

        /* for plan sub details */
        public IActionResult planSubcribed_details()
        {
            var login = HttpContext.Session.GetString("emp_session");
            if (login != null)
            {
                var empRecord = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();
                var plansubsub_data = _context.tbl_plansubcribed.ToList();
                mainmodel mydata = new mainmodel()
                {
                    empdetails = empRecord,
                    plansubdetails = plansubsub_data
                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }

        }
        [HttpGet]
        public IActionResult planSubcribed_details(string txtsearch)
        {
            var login = HttpContext.Session.GetString("emp_session");
            if (login != null)
            {
                List<plansubcribed> plansubdetails = new List<plansubcribed>();
                if (string.IsNullOrEmpty(txtsearch))
                {
                    plansubdetails = _context.tbl_plansubcribed.ToList();
                }
                else
                {
                    plansubdetails = _context.tbl_plansubcribed.FromSqlInterpolated
                        ($"select * from tbl_plansubcribed where order_id={txtsearch} or user_name= {txtsearch}").ToList();
                }
                if (plansubdetails.Count == 0)
                {
                    TempData["error"] = $"record not found {txtsearch}";
                }

                var empRecord = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();
                mainmodel mydata = new mainmodel()
                {
                    empdetails = empRecord,
                    plansubdetails = plansubdetails


                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }

        }
        /*for fetch the spefic the plan subcribed data*/
        public IActionResult plansub_data(int id)
        {
            var login = HttpContext.Session.GetString("emp_session");
            if (login != null)
            {
                var empRecord = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();
                var plansubsub_data = _context.tbl_plansubcribed.Find(id);
                mainmodel mydata = new mainmodel()
                {
                    empdetails = empRecord,
                    plansubdata = plansubsub_data
                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }
        }
         /*for the status of feasibility*/
        public IActionResult feasibilitStatus(int id)
        {
           var findid = _context.tbl_plansubcribed.Find(id);
            if(findid.FeasibilityStatus == "Not feasible")
            {
                findid.FeasibilityStatus = "feasible";
            }
            else
            {
                findid.FeasibilityStatus = "Not feasible";
            }
            _context.SaveChanges();
            return RedirectToAction("planSubcribed_details");
        }
        /*for the status of plan subcribed */
        public IActionResult plansub_status(int id)
        {
            var find_id = _context.tbl_plansubcribed.Find(id);
            var status = find_id.status;
            if (status == 0)
            {
                find_id.status = 1;
                find_id.status_updates = "Active";
            }
            else if (status == 1)
            {
                find_id.status = 2;
                find_id.status_updates = "Temporarily Deactive";
            }
            else
            {
                find_id.status = 0;
                find_id.status_updates = "Deactive";
            }

            _context.SaveChanges();
            return RedirectToAction("planSubcribed_details");
        }
        public IActionResult schemesSubdetails()
        {
            var login = HttpContext.Session.GetString("emp_session");
            if (login != null)
            {
                var empRecord = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();
                var schemesubsub_data = _context.tbl_schemesubcribed.ToList();
                mainmodel mydata = new mainmodel()
                {
                    empdetails = empRecord,
                    schemesubcribedteails= schemesubsub_data
                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }
        }
        [HttpGet]
        public IActionResult schemesSubdetails(string txtsearch)
        {
            var login = HttpContext.Session.GetString("emp_session");
            if (login != null)
            {
                var empRecord = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();
                
                List<schemesubcribed> schdetails = new List<schemesubcribed>();
                if (string.IsNullOrEmpty(txtsearch))
                {
                    schdetails = _context.tbl_schemesubcribed.ToList();
                }
                else
                {
                    schdetails = _context.tbl_schemesubcribed.FromSqlInterpolated(
              $"SELECT * FROM tbl_schemesubcribed WHERE user_name = {txtsearch} or order_id={txtsearch}"
              ).ToList();
                }
                if (schdetails.Count == 0)
                {
                    TempData["error"] = $"record not found {txtsearch} ";
                }
           
                mainmodel mydata = new mainmodel()
                {
                    empdetails=empRecord,
                    schemesubcribedteails = schdetails

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }
        }



        public IActionResult feasibilitStatus_schmes(int id)
        {
            var findid = _context.tbl_schemesubcribed.Find(id);
            if (findid.FeasibilityStatus == "Not feasible")
            {
                findid.FeasibilityStatus = "feasible";
            }
            else
            {
                findid.FeasibilityStatus = "Not feasible";
            }
            _context.SaveChanges();
            return RedirectToAction("schemesSubdetails");
        }
        public IActionResult schemesub_data(int id)
        {
            var login = HttpContext.Session.GetString("emp_session");
            if (login != null)
            {
                var empRecord = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();

                var schemesub = _context.tbl_schemesubcribed.Find(id);
                mainmodel mydata = new mainmodel()
                {
                    empdetails = empRecord,
                    subcribeddata = schemesub


                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }

        }
        public IActionResult schemesSub_status(int id)
        {
            var find_id = _context.tbl_schemesubcribed.Find(id);
            var status = find_id.status;
            if (status == 0)
            {
                find_id.status = 1;
                find_id.status_updates = "Active";
            }
            else if (status == 1)
            {
                find_id.status = 2;
                find_id.status_updates = "Temporarily Deactive";
            }
            else
            {
                find_id.status = 0;
                find_id.status_updates = "Deactive";
            }

            _context.SaveChanges();
            return RedirectToAction("schemesSubdetails");
        }
        public IActionResult add_schemes()
        {
            var login = HttpContext.Session.GetString("emp_session");
            if (login != null)
            {
                var empRecord = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();
                mainmodel mydata = new mainmodel()
                {
                   empdetails=empRecord

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login");
            }
        }
        [HttpPost]
        public IActionResult add_schemes(scheme sch, int price, int percentage, int discount)
        {
            price = sch.price;
            percentage = sch.percentage;
            discount = sch.price * percentage / 100;
            sch.discount = discount;
            _context.tbl_schemes.Add(sch);
            _context.SaveChanges();
            TempData["successfully"] = "your packages details is added successfully";
            return RedirectToAction("add_schemes");
            

        }
        public IActionResult schmesDetails()
        {
            var login = HttpContext.Session.GetString("emp_session");
            if (login != null)
            {
                var empRecord = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();
                var schemes_details = _context.tbl_schemes.ToList();
                mainmodel mydata = new mainmodel()
                {
                    schemedetails = schemes_details,
                  empdetails=empRecord
                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login");
            }
        }

            [HttpGet]
            public IActionResult schmesDetails(string txtsearch)
            {
                var login = HttpContext.Session.GetString("emp_session");
                if (login != null)
                {
                var empRecord = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();

                List<scheme> schdetails = new List<scheme>();
                    if (string.IsNullOrEmpty(txtsearch))
                    {
                        schdetails = _context.tbl_schemes.ToList();
                    }
                    else
                    {
                        schdetails = _context.tbl_schemes.FromSqlInterpolated(
                  $"SELECT * FROM tbl_schemes WHERE schemesname = {txtsearch}"
                  ).ToList();
                    }
                    if (schdetails.Count == 0)
                    {
                        TempData["error"] = $"record not found {txtsearch} ";
                    }

                    mainmodel mydata = new mainmodel()
                    {
                        empdetails=empRecord,
                        schemedetails = schdetails
                    };
                    return View(mydata);
                }
                else
                {
                    return RedirectToAction("admin_login", "admin");
                }
            }

        public IActionResult schemes_data(int id)
        {
            var login = HttpContext.Session.GetString("emp_session");
            if (login != null)
            {
                var empRecord = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();
                var schemes_detail = _context.tbl_schemes.Find(id);
                mainmodel mydata = new mainmodel()
                {
                    empdetails=empRecord,
                    schemedata = schemes_detail,
                   
                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login","admin");
            }

        }
        public IActionResult schemes_update(int id)
        {
            var login = HttpContext.Session.GetString("emp_session");
            if (login != null)
            {
                var empRecord = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();
                var schemes_detail = _context.tbl_schemes.Find(id);
                mainmodel mydata = new mainmodel()
                {
                    schemedata = schemes_detail,
                   empdetails=empRecord

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login","admin");
            }
        }
        [HttpPost]
        public IActionResult schemes_update(scheme sch, int price, int percentage, int discount)
        {
            price = sch.price;
            percentage = sch.percentage;
            discount = sch.price * percentage / 100;
            sch.discount = discount;

            _context.tbl_schemes.Update(sch);
            _context.SaveChanges();

            return RedirectToAction("schmesDetails");

        }
        public IActionResult schemes_delete(int id)
        {
            var del = _context.tbl_schemes.Find(id);
            _context.tbl_schemes.Remove(del);
            _context.SaveChanges();
            return RedirectToAction("schmesDetails");
        }
    }

    }


