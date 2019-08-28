using LoginMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginMVC.Controllers
{
    public class HomeController : Controller
    {
        BookContext db = new BookContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit()
        {
            LogModel logModel = new LogModel { Login = "Hello123", Password = "Buy1" };
                return View(logModel);
        }
        public ActionResult Login()
        {
            return View();
        }
        public JsonResult CheckName(string name)
        {
            var result = !(name == "Название");
            return Json(result,JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book book)
        {
            //if (book.Author == "Л. Толстой" && book.Year > 1910)
            //{
            //    ModelState.AddModelError("", "Год не должен быть больше 1910");
            //}
            //if (book.Year==1980)
            //{
            //    ModelState.AddModelError("Year", "Некорректный год");
            //}
            //if (book.Name.Length > 5)
            //{
            //    ModelState.AddModelError("Name", "Недопустимая длина строки");
            //}
            if (ModelState.IsValid)
            {
            db.Books.Add(book);
            db.SaveChanges();
            return RedirectToAction("Index");
            }
            
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
    }
}