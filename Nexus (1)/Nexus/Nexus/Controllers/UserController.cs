using Microsoft.AspNetCore.Mvc;

using Nexus.Models;

namespace Nexus.Controllers
{
    public class UserController : Controller
    {
        private MyContext _context;
        public UserController(MyContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

      /*for the user register*/
        public IActionResult user_register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult user_register(user user)
        {
            var emailExisting = _context.tbl_Users.FirstOrDefault(u=>u.user_Email==user.user_Email);
            if (emailExisting != null)
            {
                if (emailExisting.user_Email == user.user_Email)
                {
                    ViewBag.emailexited = "email is also registered !";
                    
                }
                return View();
            }
            
            else
            {
                _context.tbl_Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("user_login");
            }

        }
        /*for the user Login*/
        public IActionResult user_Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult user_Login(string user_Em,string user_Pass)
        {
            var data = _context.tbl_Users.FirstOrDefault(
         user => user.user_Email == user_Em);
            if (data != null && data.user_Password == user_Pass)
            {
                HttpContext.Session.SetString("user_session", data.user_Id.ToString());
                if (data.user_Status == 1)
                {
                 
                    return RedirectToAction("index","website");
                }
                else
                {
                    return RedirectToAction("waitedpage","website");
                }
            }
            else
            {
                ViewBag.message = "Incorrect email or password !";
                return View();
            }
            
        }
    }
}
