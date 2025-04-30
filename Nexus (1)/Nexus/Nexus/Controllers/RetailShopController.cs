using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Nexus.Models;

namespace Nexus.Controllers
{
    public class RetailShopController : Controller
    {
        private MyContext _context;
        public RetailShopController(MyContext myContext)
        {
            _context = myContext;
        }
        public IActionResult Index()
        {
            return View();
        }
          /*for add new Retail stores*/
        public IActionResult add_retailShop()
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
        public IActionResult add_retailShop(retailshop store)
        { 
             var insert_store=   _context.tbl_retail_stores.Add(store);
            if (insert_store!=null)
            {
                _context.SaveChanges();
                TempData["successfully"] = "retail stores details are insert successfully";
            }
         
            return RedirectToAction("add_retailShop");             
        }
        /*for fetch the details of retailstores*/
        public IActionResult details_Retailshop()
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                var storesdetails = _context.tbl_retail_stores.ToList();
                mainmodel mydata = new mainmodel()
                {
                    admindata_record = adminRecords,
                    Retail_Store=storesdetails

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }
        }
        /*search funtaionality*/
        [HttpGet]
        public IActionResult details_Retailshop(string txtsearch)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                List<retailshop> storesdetails = new List<retailshop>();
                if (string.IsNullOrEmpty(txtsearch))
                {
                    storesdetails = _context.tbl_retail_stores.ToList();
                }
                else
                {
                    storesdetails = _context.tbl_retail_stores.FromSqlInterpolated(
                           $"SELECT * FROM tbl_retail_stores WHERE Name={txtsearch} or City={txtsearch} or Area={txtsearch}"
              ).ToList();                        
                }
                if (storesdetails.Count == 0) {

                    TempData["error"] = $"record not found {txtsearch} ";
                }
                mainmodel mydata = new mainmodel()
                {
                    admindata_record = adminRecords,
                    Retail_Store = storesdetails

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }
        }
          /*for delete the data of retail store*/
        public IActionResult retailstore_delete(int id)
        {
            var del_id = _context.tbl_retail_stores.Find(id);
            _context.tbl_retail_stores.Remove(del_id);
            _context.SaveChanges();
            return RedirectToAction("details_Retailshop");
        }
        /*for Update the data of retail store*/
        public IActionResult retailstore_update(int id)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                var find_id = _context.tbl_retail_stores.Find(id);
                mainmodel mydata = new mainmodel()
                {
                    admindata_record = adminRecords,
                   retail_stores=find_id

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }
        }
        [HttpPost]
        public IActionResult retailstore_update(retailshop retailstore)
        {
            _context.tbl_retail_stores.Update(retailstore);
            _context.SaveChanges();
            return RedirectToAction("details_Retailshop");
        }
    }
}
