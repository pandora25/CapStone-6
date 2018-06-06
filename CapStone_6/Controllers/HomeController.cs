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

        //public ActionResult Welcome()
        //{
        //    return View();
        //}

        public ActionResult SignIn(UserTable UserInn)
        {
            TaskListEntities ORM = new TaskListEntities();

            UserTable currentUser = ORM.UserTables.Find(UserInn.UserName);

            if (currentUser == null)
            {
                ViewBag.Error = "User name does not exist. Did you mean to register?";
                return View("Index");
            }
            else if (currentUser.Password != UserInn.Password)
            {
                ViewBag.Error = "Incorrect password.";
                return View("Index");
            }
            ViewBag.Message = $"Welcome {UserInn.UserName}";
            return RedirectToAction("RetrivingTaks");
        }

        public ActionResult RigesterNewUser(UserTable newUser)
        {
            TaskListEntities ORM = new TaskListEntities();

            if (ModelState.IsValid)
            {
                ORM.UserTables.Add(newUser);
                ORM.SaveChanges();
                ViewBag.Message = $"{newUser.UserName} Welcome to our system ";
                return RedirectToAction("RetrivingTaks");
            }
            else
            {
                return View("Error");
            }
        }

        public ActionResult RetrivingTaks(TaskTable Taskies)
        {
            TaskListEntities ORM = new TaskListEntities();
            ViewBag.Tasks = ORM.TaskTables.ToList();
            return View();
        }

        public ActionResult AddTask(TaskTable AddTask)
        {
            TaskListEntities ORM = new TaskListEntities();

            if (ModelState.IsValid)
            {
                ORM.TaskTables.Add(AddTask);
                ORM.SaveChanges();
                //ViewBag.RetrivingTasks = ORM.TaskTables.ToList();
                //ViewBag.TasksRequsit = $"{AddTask.TaskNumber}";
                return RedirectToAction("RetrivingTaks");
            }
          
            return View("Error");
        }

        public ActionResult Swither()
        {
            return RedirectToAction("RetrivingTaks");
        }

        public ActionResult DeleteTask(string TaskNu)
        {
            TaskListEntities ORM = new TaskListEntities();

            TaskTable founded = ORM.TaskTables.Find(TaskNu);

            ORM.TaskTables.Remove(founded);
            ORM.SaveChanges();
            return RedirectToAction("RetrivingTaks");
        }

        public ActionResult UpdateTask(string UpdateTaskies)
        {
            TaskListEntities ORM = new TaskListEntities();


            TaskTable item = ORM.TaskTables.Find(UpdateTaskies);

            return View(item);
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