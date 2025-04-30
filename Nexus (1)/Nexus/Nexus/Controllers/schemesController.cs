using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Nexus.Models;

namespace Nexus.Controllers
{
    public class schemesController : Controller
    {
        private MyContext _context;
        public schemesController(MyContext con)
        {
            _context = con;

        }
        public IActionResult Index()
        {
            return View();
        }
         /*to add the schemes*/
        public IActionResult add_schemes()
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
        public IActionResult add_schemes(scheme sch, int price, int percentage, int discount)
        {
            price = sch.price;
            percentage = sch.percentage;
            discount =  sch.price * percentage / 100;
            sch.discount = discount;
            _context.tbl_schemes.Add(sch);
            _context.SaveChanges();
            TempData["successfully"] = "your packages details is added successfully";
            return RedirectToAction("add_schemes");

        }
        /* for the details of schemes */
        public IActionResult schemes_details()
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                var schemes_details = _context.tbl_schemes.ToList();
                mainmodel mydata = new mainmodel()
                {
                    schemedetails=schemes_details,
                    admindata_record = adminRecords,
                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login");
            }

        }
        [HttpGet]
        public IActionResult schemes_details(string txtsearch)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();


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
                  admindata_record=adminRecords,
                    schemedetails=schdetails };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }
        }

        /*to fetch the spefic the data of schemes*/
        public IActionResult schemes_data(int id)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                var schemes_detail = _context.tbl_schemes.Find(id);
                mainmodel mydata = new mainmodel()
                {
                    schemedata =schemes_detail,
                    admindata_record = adminRecords,

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login");
            }

        }
        /*for delete the data of schemes*/
        public IActionResult schemes_delete(int id)
        {
            var del = _context.tbl_schemes.Find(id);
            _context.tbl_schemes.Remove(del);
            _context.SaveChanges();
            return RedirectToAction("schemes_details");
        }
        /*for Update the data of schemes*/
        public IActionResult schemes_update(int id)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                var schemes_detail = _context.tbl_schemes.Find(id);
                mainmodel mydata = new mainmodel()
                {
                    schemedata = schemes_detail,
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
        public IActionResult schemes_update(scheme sch, int price, int percentage, int discount)
        {
            price = sch.price;
            percentage = sch.percentage;
            discount = sch.price * percentage / 100;
            sch.discount = discount;

            _context.tbl_schemes.Update(sch);
            _context.SaveChanges();
           
            return RedirectToAction("schemes_details");

        }
        
        /*the fetch details of schemes subcribed by user*/
        public IActionResult schemeSubcribed()
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();

                var schemescubcribed = _context.tbl_schemesubcribed.ToList();
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
        [HttpGet]
        public IActionResult schemeSubcribed(string txtsearch)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                List<schemesubcribed> schdetails = new List<schemesubcribed>();
                if (string.IsNullOrEmpty(txtsearch))
                {
                    schdetails= _context.tbl_schemesubcribed.ToList();
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
                    admindata_record = adminRecords,
                    schemesubcribedteails = schdetails

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }
        }
        /*for delete the data of schemes subcribed by user*/
        public IActionResult schemedelete_data(int id)
        {
            var del = _context.tbl_schemesubcribed.Find(id);
            _context.tbl_schemesubcribed.Remove(del);
            _context.SaveChanges();
            return RedirectToAction("schemeSubcribed");

        }
        /*for fetch the specific data of schemes subcribed by user*/
        public IActionResult schemesub_data(int id)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                var schemesub = _context.tbl_schemesubcribed.Find(id);
                mainmodel mydata = new mainmodel()
                {
                    admindata_record = adminRecords,
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
