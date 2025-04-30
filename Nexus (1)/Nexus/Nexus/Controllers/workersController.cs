using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nexus.Models;

namespace Nexus.Controllers
{
    public class workersController : Controller
    {
        private MyContext _context;
        public workersController(MyContext context)
        {
            _context = context;
        }
        /* index */
        public IActionResult Index()
        {
            var login = HttpContext.Session.GetString("emp_session");
            if (login != null)
            {
                var bookedPlan = _context.tbl_bookedplans.Count();
                var plansub = _context.tbl_plansubcribed.Count();
                var schemebooked = _context.tbl_bookedschemes.Count();
                var schemessub = _context.tbl_schemesubcribed.Count();
                TempData["plansub_count"] = bookedPlan + plansub;
                TempData["schmessub_count"] = schemebooked + schemessub;

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
        /*profile update*/
        public IActionResult empupdate(int id)
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
        public IActionResult empupdate(employee emp)
        {
            _context.tbl_employees.Update(emp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        /*plan details*/
        public IActionResult planDeatils()
        {
            var login = HttpContext.Session.GetString("emp_session");
            if (login != null)
            {
                var empRecord = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();
                var plansub = _context.tbl_plansubcribed.ToList();
                mainmodel mydata = new mainmodel()
                {
                    empdetails = empRecord,
                    plansubdetails = plansub

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
                List<plansubcribed> plan_subcribed = new List<plansubcribed>();
                if (string.IsNullOrEmpty(txtsearch))
                {
                    plan_subcribed = _context.tbl_plansubcribed.ToList();
                }
                else
                {
                    plan_subcribed = _context.tbl_plansubcribed.FromSqlInterpolated(
              $"SELECT * FROM tbl_plansubcribed WHERE order_id = {txtsearch} "
              ).ToList();
                }
                if (plan_subcribed.Count == 0)
                {
                    TempData["error"] = $"Not found a record for {txtsearch}";
                }
                var empRecord = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();
                var plansub = _context.tbl_plansubcribed.ToList();
                mainmodel mydata = new mainmodel()
                {
                    empdetails = empRecord,
                    plansubdetails = plan_subcribed

                };
                return View(mydata);
            }

            else
            {
                return RedirectToAction("emp_loginform", "employe");
            }
        }
        /*plan sprfic subcribed data */
        public IActionResult plansub_data(int id)
        {
            var login = HttpContext.Session.GetString("emp_session");
            if (login != null)
            {
                var empRecord = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();
                var plansubdata = _context.tbl_plansubcribed.Find(id);
                mainmodel mydata = new mainmodel()
                {
                    empdetails = empRecord,
                    plansubdata = plansubdata

                };
                return View(mydata);
            }

            else
            {
                return RedirectToAction("emp_loginform", "employe");
            }
        }
        public IActionResult schemesbooked()
        {
            var login = HttpContext.Session.GetString("emp_session");
            if (login != null)
            {
                var empRecord = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();
                List<Products> pro_datails = _context.tbl_products.ToList();
                List<scheme> schmes_datails = _context.tbl_schemes.ToList();

                mainmodel mydata = new mainmodel()
                {
                    schemedetails = schmes_datails,
                    products_deatils = pro_datails,
                    empdetails = empRecord,


                };
                return View(mydata);
            }

            else
            {
                return RedirectToAction("emp_loginform", "employe");
            }
        }
        [HttpPost]
        public IActionResult schemesbooked(schemesOutlet sch)
        {
            _context.tbl_bookedschemes.Add(sch);
            _context.SaveChanges();
            TempData["successfully"] = "The schemes is successfully subcribed";
            return RedirectToAction("schemesbooked");

        }
        public IActionResult schemesbookedDetails()
        {
            var login = HttpContext.Session.GetString("emp_session");
            if (login != null)
            {
                var empRecord = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();
                var schmesbooked = _context.tbl_bookedschemes.Include(e => e.schemes).ToList();

                mainmodel mydata = new mainmodel()
                {
                     schemesBook=schmesbooked,
                    empdetails = empRecord


                };
                return View(mydata);
            }

            else
            {
                return RedirectToAction("emp_loginform", "employe");
            }
        }
        [HttpGet]
        public IActionResult schemesbookedDetails(string txtsearch)
        {
            var login = HttpContext.Session.GetString("emp_session");
            if (login != null)
            {
                var empRecord = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();

               
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
                    empdetails=empRecord,
                  schemesBook=details

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }


        }
        public IActionResult planbooked()
        {
            var login = HttpContext.Session.GetString("emp_session");
            if (login != null)
            {
                var empRecord = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();
                List<Products> pro_datails = _context.tbl_products.ToList();
                List<plan> plan_datails = _context.tbl_plans.ToList();

                mainmodel mydata = new mainmodel()
                {
                   plandetails=plan_datails,
                    products_deatils = pro_datails,
                    empdetails = empRecord,


                };
                return View(mydata);
            }

            else
            {
                return RedirectToAction("emp_loginform", "employe");
            }
        }
        [HttpPost]
        public IActionResult planbooked(planOutlet plan)
        {
            _context.tbl_bookedplans.Add(plan);
            _context.SaveChanges();
            TempData["successfully"] = "The plan is subcribed successfully";
            return RedirectToAction("planbooked");
        }

        public IActionResult planbookedDetails()
        {
            var login = HttpContext.Session.GetString("emp_session");
            if (login != null)
            {
                var empRecord = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();
                var planbooked = _context.tbl_bookedplans.ToList();

                mainmodel mydata = new mainmodel()
                {
                    planoutlet = planbooked,
                    empdetails = empRecord


                };
                return View(mydata);
            }

            else
            {
                return RedirectToAction("emp_loginform", "employe");
            }
        }
        [HttpGet]
        public IActionResult planbookedDetails(string txtsearch)
        {
            var login = HttpContext.Session.GetString("emp_session");
            if (login != null)
            {
                var empRecord = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();


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
                    empdetails = empRecord,
                    planoutlet = details

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }


        }
        public IActionResult schemessubdetails()
        {
            var login = HttpContext.Session.GetString("emp_session");
            if (login != null)
            {
                var empRecord = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();

                

                var schemescubcribed = _context.tbl_schemesubcribed.ToList();
                mainmodel mydata = new mainmodel()
                {
                    schemesubcribedteails=schemescubcribed,
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
        public IActionResult schemessubdetails(string txtsearch)
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
                    var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                mainmodel mydata = new mainmodel()
                {
                    empdetails = empRecord,
                    schemesubcribedteails = schdetails
                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }
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
        public IActionResult wesbiteSchemedetails()
        {
            var login = HttpContext.Session.GetString("emp_session");
            if (login != null)
            {

                var empRecord = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();
                var schemescubcribed = _context.tbl_schemesubcribed.ToList();
                mainmodel mydata = new mainmodel()
                {
                    empdetails=empRecord,
                    schemesubcribedteails=schemescubcribed

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }
        }
        public IActionResult wesbiteSchemedetails(string txtsearch)
        {
            var login = HttpContext.Session.GetString("emp_session");
            if (login != null)
            {
                var emp_Records = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();
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
                var schmesub = _context.tbl_schemesubcribed.Include(e => e.product).ToList();
                mainmodel mydata = new mainmodel()
                {
                    empdetails = emp_Records,
                    schemesubcribedteails = schdetails

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }
        }
        public IActionResult schemessubweb_data(int id)
        {
            var login = HttpContext.Session.GetString("emp_session");
            if (login != null)
            {

                var empRecord = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();
                var schemesub = _context.tbl_schemesubcribed.Find(id);
                mainmodel mydata = new mainmodel()
                {
                   empdetails=empRecord,
                    subcribeddata = schemesub


                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }
        }

    }

    }
