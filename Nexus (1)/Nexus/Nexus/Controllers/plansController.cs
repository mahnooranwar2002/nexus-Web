using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nexus.Models;

namespace Nexus.Controllers
{
    public class plansController : Controller
    {
        private MyContext _context;
        public plansController(MyContext myContext)
        {
            _context = myContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        /*for add Plans*/
        public IActionResult add_plans()
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
                return RedirectToAction("admin_login", "admin");
            }
        }
        [HttpPost]
        public IActionResult add_plans(plan plan)
        {
            _context.tbl_plans.Add(plan);
            _context.SaveChanges();
            TempData["msg"] = "plan is succesfully added";
            return RedirectToAction("add_plans");

        }
        /*for detaails of plans*/
        public IActionResult details_plans()
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                var plansdetails = _context.tbl_plans.ToList();
                mainmodel mydata = new mainmodel()
                {
                    admindata_record = adminRecords,
                    plandetails = plansdetails

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }
        }
        //sreach funtionaity
        [HttpGet]
        public IActionResult details_plans(string txtsearch)
        {
            var login = HttpContext.Session.GetString("admin_session");
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

                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();

                mainmodel mydata = new mainmodel()
                {
                    admindata_record = adminRecords,
                    plandetails = plansdetails

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }
        }
        /*for  status update*/
        public IActionResult plans_status(int id)
        {
            var findid = _context.tbl_plans.Find(id);
            var status = findid.status;
            if (status == 1)
            {
                findid.status = 0;
                findid.status_update = "Deactive";
            }
            else
            {
                findid.status = 1;
                findid.status_update = "Active";
            }
            _context.SaveChanges();
            return RedirectToAction("details_plans");
        }

        /*for delete*/
        public IActionResult plans_del(int id)
        {
            var del = _context.tbl_plans.Find(id);
            _context.tbl_plans.Remove(del);
            _context.SaveChanges();
            return RedirectToAction("details_plans");
        }
        /*for update plan*/
        public IActionResult plan_update(int id)
        {

            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                var plansdetails = _context.tbl_plans.Find(id);
                mainmodel mydata = new mainmodel()
                {
                    admindata_record = adminRecords,
                    planData = plansdetails

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }
        }
        [HttpPost]
        public IActionResult plan_update(plan plan)
        {
            _context.tbl_plans.Update(plan);
            _context.SaveChanges();
            return RedirectToAction("details_plans");

        }

        /*for the fatch the plan subcribed by user*/
        public IActionResult planSubcribed()
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                var plansub = _context.tbl_plansubcribed.ToList();
                mainmodel mydata = new mainmodel()
                {
                    admindata_record = adminRecords,
                    plansubdetails = plansub

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }
        }
        /*for the delete the plan subcribed by user*/
        public IActionResult plansub_delete(int id)
        {
            var del = _context.tbl_plansubcribed.Find(id);
            _context.tbl_plansubcribed.Remove(del);
            _context.SaveChanges();
            return RedirectToAction("planSubcribed");
        }
        /*for the fatch the specific plan subcribed by user*/
        public IActionResult plansub_data(int id)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                var plansdetails = _context.tbl_plansubcribed.Find(id);
                mainmodel mydata = new mainmodel()
                {
                    admindata_record = adminRecords,
                    plansubdata = plansdetails

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");

            }
        }
        [HttpGet]
        public IActionResult planSubcribed(string txtsearch)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                List<plansubcribed> plansdetails = new List<plansubcribed>();
                if (string.IsNullOrEmpty(txtsearch))
                {
                    plansdetails = _context.tbl_plansubcribed.ToList();
                }
                else
                {
                    plansdetails = _context.tbl_plansubcribed.FromSqlInterpolated(
              $"SELECT * FROM tbl_plansubcribed WHERE user_name = {txtsearch} or user_number={txtsearch}"
              ).ToList();
                }
                if (plansdetails.Count == 0)
                {
                    TempData["error"] = $"record not found {txtsearch} ";


                }
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                mainmodel mydata = new mainmodel()
                {
                    admindata_record = adminRecords,
                    plansubdetails = plansdetails

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
