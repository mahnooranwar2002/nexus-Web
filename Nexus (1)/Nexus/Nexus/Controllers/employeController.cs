using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nexus.Models;

namespace Nexus.Controllers
{
    public class employeController : Controller
    {
        private MyContext _context;
        public employeController(MyContext context)
        {
            _context = context;   
        }
       /*for the index */
        public IActionResult Index()
        {
            return View();
        }
/*for add new_emaployee*/
       public IActionResult add_Employee()
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();

                List<positions> des_datails = _context.tbl_positions.ToList();
             

                mainmodel mydata = new mainmodel()
                {
                    admindata_record = adminRecords,
                    positionList=des_datails


                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }
        }

        /*for add the emplyomee */
        [HttpPost]
        public IActionResult add_Employee(string user_name, employee emp)
        {
            var exsitinguserName = _context.tbl_employees.FirstOrDefault(u => u.user_name ==emp.user_name );
            if (exsitinguserName != null)
            {
                TempData["msg"] = "The User_name of employee  is Already Registered!";
                return RedirectToAction("add_employee");
            }
            else
            {
                TempData["successfully"] = "The Employee is successfully added";
                _context.tbl_employees.Add(emp);
                _context.SaveChanges();
                return RedirectToAction("add_employee");
            }
            ;
        }
         /*for details of employee*/
        public IActionResult emplyomee_details()
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                var emp_details = _context.tbl_employees.Include(p => p.positions).ToList();  

                mainmodel mydata = new mainmodel()
                {
                    admindata_record = adminRecords,
                    empdetails=emp_details
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
        public IActionResult emplyomee_details(string txtsearch)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();

               
                List<employee> emp_Deatils = new List<employee>();
                if (string.IsNullOrEmpty(txtsearch))
                {
                    emp_Deatils = _context.tbl_employees.Include(p => p.positions).ToList();
                }
                else
                {
                    emp_Deatils = _context.tbl_employees.FromSqlInterpolated(
                           $"SELECT * FROM tbl_employees  WHERE Name={txtsearch} or Email={txtsearch}").Include(p => p.positions).ToList();
                }

                if (emp_Deatils.Count == 0)
                {

                    TempData["error"] = $"record not found {txtsearch} ";
                }
                mainmodel mydata = new mainmodel()
                {
                    admindata_record = adminRecords,
                    empdetails = emp_Deatils


                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }

        }
        /*for update the status of employee*/
        public IActionResult emp_status(int id)
        {
            var find_id = _context.tbl_employees.Find(id);
            if (find_id.status == 1)
            {
                find_id.status = 0;
                find_id.status_update = "Dective";
                
            }
            else
            {
                find_id.status = 1;
                find_id.status_update = "Active";
            }
            _context.SaveChanges();
            return RedirectToAction("emplyomee_details");
        }
        /*for delete of the data of employee*/
        public IActionResult emp_delete(int id)
        {
            var find_id = _context.tbl_employees.Find(id);
            _context.tbl_employees.Remove(find_id);
            _context.SaveChanges();
            return RedirectToAction("emplyomee_details");
        }
        /*for fetch  the data of specific employee*/
        public IActionResult emp_data(int id)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                var data = _context.tbl_employees.Find(id);
                mainmodel mydata = new mainmodel()
                {
                    admindata_record = adminRecords,
                    empData = data
                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }
        }
        
        /*employmee update*/
        public IActionResult emp_updates(int id)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecords = _context.tbl_adminsrecords.Where(e => e.admin_id == int.Parse(login)).ToList();
                var data = _context.tbl_employees.Find(id);
                List<positions> des_datails = _context.tbl_positions.ToList();
                ViewData["storeDropdown"] = des_datails;
                mainmodel mydata = new mainmodel()
                {
                    admindata_record = adminRecords,
                    positionList = des_datails,
                     empData = data

                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login", "admin");
            }
        }
        [HttpPost]
        public IActionResult emp_updates(employee emp)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                List<positions> des_datails = _context.tbl_positions.ToList();
                ViewData["storeDropdown"] = des_datails;
                bool fkExsit = _context.tbl_positions.Any(p => p.Id == emp.Position_id);
                if (fkExsit)
                {
                    _context.tbl_employees.Update(emp);
                    _context.SaveChanges();
                    return RedirectToAction("emplyomee_details");
                }
                mainmodel mydata = new mainmodel()
                {
                  positionList = des_datails,
                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("admin_login","admin");
            }
        }
         
        /*for emplyomee login*/
        public IActionResult emp_loginform()
        {
            return View();
        }

        /*fpr actually Login*/
        [HttpPost]
        public IActionResult emp_loginform( string emp_uN,string emp_pass)
        {
            var emp_data =_context.tbl_employees.FirstOrDefault(emp=>emp.user_name==emp_uN) ;
            if (emp_data != null && emp_data.User_password == emp_pass)
            {
                HttpContext.Session.SetString("emp_session", emp_data.Id.ToString());
                if (emp_data.status == 1)
                {
                    if (emp_data.Position_id == 1 )
                    {
                        return RedirectToAction("index", "accounts");
                    }
                    else if (emp_data.Position_id == 2)
                    {
                        return RedirectToAction("index", "technical");
                    }
                    else if (emp_data.Position_id == 3)
                    {
                        return RedirectToAction("index", "Workers");
                    }
                    else
                    {
                        TempData["errormgs"] = "Company approval for your department is still pending!";
                        return View();
                    }

                }
                else
                {
                    return RedirectToAction("waitedpage", "website");
                }
            }
            else
            {
                TempData["error"] = "Your user name or password is incorreted";
                return View();
            }
            
           
        }
       /*for logout*/
       public IActionResult logout()
        {
            HttpContext.Session.Remove("emp_session");
            return RedirectToAction("emp_loginform");
        }
    }
}
