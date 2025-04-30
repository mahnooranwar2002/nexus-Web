using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nexus.Models;

namespace Nexus.Controllers
{
    public class ProductsController : Controller
    {
        private MyContext _context;
        public ProductsController(MyContext con)
        {
            _context = con;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult add_products()
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();

                List<vendor> getvendors = _context.tbl_vendors.ToList();
                ViewData["storeDropdown"] = getvendors;
                mainmodel mydata = new mainmodel()
                {
                    admindata_record = adminRecords,
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
        public IActionResult add_products(Products pro)
        {
            _context.tbl_products.Add(pro);
            _context.SaveChanges();
            TempData["successfully"] = "The product is added successfully";
            return RedirectToAction("add_products");
        }
        public IActionResult product_details()
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();

                var productDetails = _context.tbl_products.Include(e => e.vendors).ToList();
              
                mainmodel mydata = new mainmodel()
                {
                    products_deatils=productDetails,
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
        public IActionResult product_details(string txtsearch)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
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
                    admindata_record = adminRecords,
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
        public IActionResult product_Update(int id)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();

                var productDetails = _context.tbl_products.Find(id);

                List<vendor> getvendors = _context.tbl_vendors.ToList();
                ViewData["storeDropdown"] = getvendors;
                mainmodel mydata = new mainmodel()
                {
                    admindata_record = adminRecords,
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
        public IActionResult product_Update(Products pro)
        {
            _context.tbl_products.Update(pro);
            _context.SaveChanges();
            return RedirectToAction("product_details");
        }



    }
}
