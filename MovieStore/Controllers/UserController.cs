using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieStore.Models;

namespace MovieStore.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel user)
        {
            if (ModelState.IsValid == true)
            {
                Model1 db = new Model1();
                UserManager userManager = new UserManager();
                //Ma khoa mat khau 
                String pass = UserManager.PasswordEncryption(user.Password).ToString();
                khachhang kh = db.khachhangs.Where(u => u.username == user.Username && u.password == pass).SingleOrDefault();
                if (kh != null)
                {
                    //encrypt pass
                    //check username and pass
                    Session["KhachHang"] = kh;
                    Session["User"] = kh.username;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //error
                    ModelState.AddModelError("loginError", "Username or Password is incorrect");
                }
            }
            
            return View();
        }
        public ActionResult Login()
        {
            return View();

        }
        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Index", "Home");

        }
        [HttpPost]
        public ActionResult Register(UserModel user)
        {
            if (ModelState.IsValid) {
                UserManager userManager = new UserManager();
                if (userManager.CheckUsername(user.Username) == false )
                {
                    //Tao doi tuong khach  hang (kh)
                    //Ma hoa password, sau do copy pass da ma hoa sang doi tuong kh
                    //Copy du lieu tu doi tuong user sang kh: username, email, password
                    //
                    //insert
                    ModelState.AddModelError("UsernameError", "Username already exist");
                    
                }
                else if (userManager.CheckEmail(user.Email) == false)
                {
                    ModelState.AddModelError("EmailError", "Email already exist");
                }
                else {
                    //ModelState.AddModelError("loginError", "Username or email does not exist!");
                    //return View("FailRegister");
                    khachhang kh = new khachhang()
                    {
                        tenkh = user.hoten,
                        username = user.Username,
                        password = UserManager.PasswordEncryption(user.Password),
                        sdt = user.sdt,
                        diachi = user.diachi,
                        email = user.Email,

                    };
                    Model1 db = new Model1();
                    db.khachhangs.Add(kh);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    return RedirectToAction("Login", "User");
                }
            }
            return View();
            
        }
        

        
    }
}