using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nexus.Models;

namespace Nexus.Controllers
{
    public class accountsController : Controller
    {
        private MyContext _context;
        public accountsController(MyContext context)
        {
            _context = context;

        }

        /*for the index of acountant panel*/
        public IActionResult Index()
        {

            var login = HttpContext.Session.GetString("emp_session");
            if (login != null)
            {
                TempData["plansub_count"] = _context.tbl_plansubcribed.Count();
                TempData["schemessub_count"] = _context.tbl_schemesubcribed.Count();
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
        /*update Profile*/
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
/*for the view the data of plan subcribed*/
        public IActionResult SubscribedPLan()
        {
            var login = HttpContext.Session.GetString("emp_session");
            if (login != null)
            {
                var emp_Records = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();
                var plansub = _context.tbl_plansubcribed.Include(e=>e.productdetails).ToList();
                mainmodel mydata = new mainmodel()
                {
                    empdetails = emp_Records,
                    plansubdetails = plansub


                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }
        }
        [HttpGet]
        public IActionResult SubscribedPLan(string txtsearch)
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
        /*for the view the specific data of plan subcribed*/
        public IActionResult plansub_data(int id)
        {
            var login = HttpContext.Session.GetString("emp_session");
            if (login != null)
            {
                var empRecords = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();
                var plansdetails = _context.tbl_plansubcribed.Find(id);
                mainmodel mydata = new mainmodel()
                {
                    empdetails = empRecords,
                    plansubdata = plansdetails

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");

            }
        }

        /*for the delete the plan subcribed data*/
        public IActionResult plansub_delete(int id)
        {
            var del = _context.tbl_plansubcribed.Find(id);
            _context.tbl_plansubcribed.Remove(del);
            _context.SaveChanges();
            return RedirectToAction("SubscribedPLan");
        }
        /*for the bill generated the plan subcribed data*/
        public IActionResult bill_generated(int id)
        {
            var findid = _context.tbl_plansubcribed.Find(id);
            var status = findid.GenerateBillstatus;
            var login = HttpContext.Session.GetString("emp_session");
            
            var empRecords = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();
            var plansdetails = _context.tbl_plansubcribed.Find(id);

            if (login != null)
            {
                if (status== 1)
                {
                    if (status == 1)
                    {   
                        findid.GenerateBillstatus_update = "The bill is generated";
                    }
                    return RedirectToAction("SubscribedPLan");
                   
                }
                
              else if(status == 0)
                {
                    findid.payment = "Due";
                    findid.GenerateBillstatus_update = "the bill has been generated";
                }
           
                {
                    mainmodel mydata = new mainmodel()
                    {
                        empdetails = empRecords,
                        plansubdata = plansdetails

                    };
                    return View(mydata);
                  
                }
                
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }
        }
        [HttpPost]
        public IActionResult bill_generated(plansubcribed plansub)
        {
           plansub.payment= "paid";
            Random random = new Random();
            var num1 = random.Next(100000000, 999999999).ToString();
            var num2 = random.Next(1000000, 9999999).ToString();
            var num = num1 + num2;
            plansub.account_id = num;

            _context.tbl_plansubcribed.Update(plansub);
            _context.SaveChanges();
            return RedirectToAction("SubscribedPLan");
        }

       /*To update the status of plan subcribed*/
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
            return RedirectToAction("SubscribedPLan");
        }
           /*for the schemes Bill*/
        public IActionResult schemes_bill()
        {

            var login = HttpContext.Session.GetString("emp_session");
            if (login != null)
            {
                var emp_Records = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();
                var schmesub = _context.tbl_schemesubcribed.Include(e => e.product).ToList();
                mainmodel mydata = new mainmodel()
                {
                    empdetails = emp_Records,
                   schemesubcribedteails=schmesub


                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }
        }
        [HttpGet]
        public IActionResult schemes_bill(string txtsearch)
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
        public IActionResult schemes_delete(int id)
        {
            var del = _context.tbl_schemesubcribed.Find(id);
            _context.tbl_schemesubcribed.Remove(del);
            _context.SaveChanges();
            return RedirectToAction("schemes_bill");

        }

        public IActionResult schemessub_data(int id)
        {
            var login = HttpContext.Session.GetString("emp_session");
            if (login != null)
            {
                var empRecords = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();
                var schmesSubdetails = _context.tbl_schemesubcribed.Find(id);
                mainmodel mydata = new mainmodel()
                {
                    empdetails = empRecords,
                  subcribeddata = schmesSubdetails

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");

            }
        }
        public IActionResult schemessub_status(int id)
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
            return RedirectToAction("schemes_bill");

        }
        public IActionResult bill_generatedschemes(int id)
        {
            var findid = _context.tbl_schemesubcribed.Find(id);
            var status = findid.GenerateBillstatus;
            var login = HttpContext.Session.GetString("emp_session");

            var empRecords = _context.tbl_employees.Where(e => e.Id == int.Parse(login)).ToList();
            var details = _context.tbl_schemesubcribed.Find(id);

            if (login != null)
            {
                if (status == 1)
                {
                    if (status == 1)
                    {
                        findid.GenerateBillstatus_update = "The bill is generated";
                    }
                    return RedirectToAction("schemes_bill");

                }

                else if (status == 0)
                {
                    findid.payment = "Due";
                    findid.GenerateBillstatus_update = "the bill has been generated";
                }

                {
                    mainmodel mydata = new mainmodel()
                    {
                        empdetails = empRecords,
                       subcribeddata=details

                    };
                    return View(mydata);

                }

            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }
        }
        [HttpPost]
        public IActionResult bill_generatedschemes(schemesubcribed sch)
        {
            sch.payment = "paid";
            Random random = new Random();
            var num1 = random.Next(100000000, 999999999).ToString();
            var num2 = random.Next(1000000, 9999999).ToString();
            var num = num1 + num2;
            sch.account_id = num;

            _context.tbl_schemesubcribed.Update(sch);
            _context.SaveChanges();
            return RedirectToAction("schemes_bill");
        }
    }


}
