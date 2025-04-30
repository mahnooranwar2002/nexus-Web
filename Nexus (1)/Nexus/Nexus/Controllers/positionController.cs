using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nexus.Models;

namespace Nexus.Controllers
{
    public class positionController : Controller
    {
        private MyContext _context;
        public positionController(MyContext context)
        {
            _context = context;
        }
        
    public IActionResult Index()
    {
        return View();
    }
    /*for create the position*/
    public IActionResult add_position()
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
        /*for add desgination in the database*/
        [HttpPost]
        public IActionResult add_position(positions des)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                _context.tbl_positions.Add(des);
                _context.SaveChanges();
                TempData["succesfully"] = "The Designation has Been Successfully added !";
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
         /*for the fetch position details*/
        public IActionResult position_details()
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
               var  desginatopn_record=  _context.tbl_positions.ToList();
                mainmodel mydata = new mainmodel()
                {
                    admindata_record = adminRecords,
                    positionList=desginatopn_record
                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }
        }
        /*for sreach funtionality*/
        [HttpGet]
        public IActionResult position_details(string txtsearch)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            { 
                List<positions> desginatopn_record = new List<positions>();
                if (string.IsNullOrEmpty(txtsearch))
                {
                    desginatopn_record = _context.tbl_positions.ToList();
                }
                else
                {
                    desginatopn_record = _context.tbl_positions.FromSqlInterpolated(
              $"SELECT * FROM tbl_positions WHERE Name = {txtsearch} "
              ).ToList();
                }
                if (desginatopn_record.Count == 0)
                {
                    TempData["error"] = $"record not found {txtsearch} ";
                }

                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                mainmodel mydata = new mainmodel()
                {
                    admindata_record = adminRecords,
                    positionList = desginatopn_record

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }
        }

         /*for the update the position data*/
        public IActionResult update_position(int id)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                var desginaton_record = _context.tbl_positions.Find(id);

                mainmodel mydata = new mainmodel()
                {
                    admindata_record = adminRecords,
                   position_data=desginaton_record
                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }
        }
        [HttpPost]

        public IActionResult update_position(positions des)
        {
            _context.tbl_positions.Update(des);
            _context.SaveChanges();
            return RedirectToAction("position_details");
        }
        /*for delete*/
        public IActionResult delete_position(int id)
        {
            var find_id = _context.tbl_positions.Find(id);
            _context.tbl_positions.Remove(find_id);
            _context.SaveChanges();
            return RedirectToAction("position_details");
        }

    }
}
