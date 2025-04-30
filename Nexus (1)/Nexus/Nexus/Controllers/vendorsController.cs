using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nexus.Models;

namespace Nexus.Controllers
{
    public class vendorsController : Controller
    { private MyContext  _context;
            public vendorsController(MyContext con)
        {
            _context = con;
        }
        public IActionResult Index()
        {
            return View();
        }
        /*for the vendor added*/
        public IActionResult add_vendors()
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                mainmodel mydata = new mainmodel()
                { admindata_record = adminRecords };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login");
            }

        }
        [HttpPost]
        public IActionResult add_vendors(vendor vend)
        {
            _context.tbl_vendors.Add(vend);
            _context.SaveChanges();
            TempData["successfully"] = "The vendor is added successfully";
            return RedirectToAction("add_vendors");
        }
        /*for the vendor details*/
        public IActionResult vendors_details()
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                var vendordetails = _context.tbl_vendors.ToList();
                mainmodel mydata = new mainmodel()
                { admindata_record = adminRecords,
                vendordetails=vendordetails
                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login");
            }
        }
        /*for sreach funtionality */
        [HttpGet]
        public IActionResult vendors_details(string txtsearch)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                List<vendor> vendordetails = new List<vendor>();
                if (string.IsNullOrEmpty(txtsearch))
                {
                   vendordetails= _context.tbl_vendors.ToList();
                }
                else
                {
                    vendordetails = _context.tbl_vendors.FromSqlInterpolated(
              $"SELECT * FROM tbl_vendors WHERE vendor_name = {txtsearch} or vendor_email={txtsearch}"
              ).ToList();
                }
                if (vendordetails.Count == 0)
                {
                    TempData["error"] = $"record not found {txtsearch} ";

                }
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                var admindsdetail = _context.tbl_adminsrecords.ToList();
                mainmodel mydata = new mainmodel()
                {
                    admindata_record = adminRecords,
                  vendordetails=vendordetails
                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login");
            }
        }
        /*for the vendor delete*/
        public IActionResult vendor_delete(int id)
        {
            var del = _context.tbl_vendors.Find(id);
            _context.tbl_vendors.Remove(del);
            _context.SaveChanges();
            return RedirectToAction("vendors_details");
        }
        /*for the vendor update*/
        public IActionResult vendor_Update(int id)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                var vendordetails = _context.tbl_vendors.Find(id);
                mainmodel mydata = new mainmodel()
                {
                    admindata_record = adminRecords,
                    vendordata=vendordetails
                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login");
            }

        }
        [HttpPost]
        public IActionResult vendor_update(vendor ven)
        {
            _context.tbl_vendors.Update(ven);
            _context.SaveChanges();
            return RedirectToAction("vendors_details");

        }
    }
}
