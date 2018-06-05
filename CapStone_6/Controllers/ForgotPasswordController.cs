using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapStone_6.Models;

namespace CapStone_6.Controllers
{
    public class ForgotPasswordController : Controller
    {
        // GET: ForgotPassword
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PerformForgotPassword(ForgotPasswordModel model)
        {
            if (model != null && !string.IsNullOrEmpty(model.UserName) && !string.IsNullOrEmpty(model.Password))
            {
                TaskListEntities ORM = new TaskListEntities();

                UserTable user = ORM.UserTables.Where(u => u.UserName == model.UserName).FirstOrDefault();

                if (user != null)
                {
                    user.Password = model.Password;
                    ORM.SaveChanges();
                     return Json("Your password has been updated " + model.UserName);
                    //return RedirectToAction("SignIn", "Home");
                }
                else
                {
                    return Json("You do not exist!!");
                }




            }



            return Json("ok");
        }
    }
}

// if (model != null && model.Password != string.Empty && model.UserName != string.Empty)