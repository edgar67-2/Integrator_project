using ProyectoWeb3C.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ProyectoWeb3C.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Página de descripción para tu aplicación.";
            ViewBag.Count = 10;

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult LogIn()
        {
            return View();
        }
        public ActionResult UserList()
        {
            db_model db = new db_model();
            return View(db.Users.ToList());
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(User user)
        {
            List<User> users = new List<User>();
            
            db_model db = new db_model();

            users = db.Users.ToList();

            if (users.Any(x => x.Email == user.Email && x.Password == user.Password)) 
            {
                //ViewBag.Response = "Inicio de sesión exitoso.";
                Session["Email"] = user.Email;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Response = "Correo o contraseña incorrectos.";
                return View();
            }
        }
        [HttpPost]
        public ActionResult SignUp(User user)
        {
            db_model db = new db_model();

            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("LogIn", "Home");
            }
            
            return View();
        }
        public ActionResult LogOut()
        {
            Session["Email"] = null;
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Delete(int Id)
        {
            db_model db = new db_model();
            User user = db.Users.Find(Id);
            db.Users.Remove(user);
            db.SaveChanges();

            return RedirectToAction("UserList", "Home");
        }
    }
}