using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapStone_6.Models;

namespace CapStone_6.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Error = "";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Registeration()
        {
            return View();
        }

        public ActionResult Welcome()
        {
            return View("welcome");
        }

        public ActionResult RigesterNewUser(UserTable newUser)
        {
            TaskListEntities ORM = new TaskListEntities();

            if (ModelState.IsValid)
            {
                ORM.UserTables.Add(newUser);
                ORM.SaveChanges();
                ViewBag.Message = $"{newUser.UserName} Welcome to our system ";
                return View("Welcome");
            }
            else
            {
                return View("Error");
            }

        }

        public ActionResult SignIn(UserTable UserName, string Password)
        {
            TaskListEntities ORM = new TaskListEntities();

            UserTable currentUser = ORM.UserTables.Find(UserName);

            if (currentUser == null)
            {
                ViewBag.Error = "User name does not exist. Did you mean to register?";
                return View("Index");

            }
            else if(currentUser.Password != Password)
            {
                ViewBag.Error = "Incorrect password.";
            }
            ViewBag.Message = $"Welcome  {UserName}";
            return View("Welcome");
        }


    }
}



// List<UserTable> users = ORM.UserTables.ToList();

//    if (users.Where(x => x.UserName == user.UserName).ToList().Count() == 0 )
//    {
//        ViewBag.Error = "User Name not Valid";
//        return View("Error");
//    }

//    UserTable thisUser = ORM.UserTables.Find(user.UserName);

//    if (thisUser.Password != user.Password)
//    {
//        ViewBag.Error = "Incorrect Password";
//        return View("Error");
//    }

//    ViewBag.Message = $"Welcome {user.UserName}";

//    return View("Welcome");
//