using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NET_MVC.Models;
using ASP.NET_MVC.Util;
using System.IO;
using System.Data.Entity;

namespace ASP.NET_MVC.Controllers
{
    public class HomeController : Controller
    {
        BookContext db=new BookContext();
        public string GetData()
        {
            string id = HttpContext.Request.Cookies["id"].Value;
            return id.ToString();
        }
        public string GetSession()
        {
            string id = HttpContext.Request.Cookies["id"].Value;
            var val = Session["name"];
            return val.ToString();
        }
        public ActionResult Index()
        {
            ViewData["Head"] = "Hello quest!";
            ViewBag.Cars = new List<string>
            {
                "BMW","Mersedez"
            };
            var books = db.Books;
            //ViewBag.Books = books;
            Session["name"] = "Harry";// or null
            HttpContext.Response.Cookies["id"].Value = "ca-4353w";

            SelectList authors = new SelectList(db.Books, "Author", "Name");
            ViewBag.Authors= authors;

            return View(books);
        }
        [HttpPost]
        public string GetForm(string[] countries)
        {
            //return author;
            string result = "";
            foreach (string c in countries)
            {
                result += c;
                result += ";";
            }
            return "Вы выбрали: " + result;
        }
        public ActionResult BookIndex()
        {
            var books = db.Books;
            return View(books);
        }
        public ActionResult GetVoid(int id)//RedirectResult
        {
            if (id > 3)
            {
            // return RedirectPermanent("/Home/Contact");
                //return RedirectToRoute(new { controller = "Home", action = "Contact" });
               // return RedirectToAction("Square", "Home", new {a=10, h=12});
                return new HttpStatusCodeResult(404);
            }
            return View("About");
        }
        public FilePathResult GetFile()
        {
            //Путь к файлу
            //string file_path = Server.MapPath("~/Files/Резюме.pdf");
            string file_path = "D://программирование//Резюме.pdf";
            // Тип файла - content-type
            //string file_type = "application/pdf";
            //универсальный тип:
            string file_type = "application/octet-stream";
            // Имя файла - необязательно
            string file_name = "Резюме.pdf";
            return File(file_path, file_type, file_name);
        }
        public FileContentResult GetBytes()
        {
            string path = Server.MapPath("~/Files/Резюме.pdf");
            byte[] mas = System.IO.File.ReadAllBytes(path);
            string file_type = "application/pdf";
            string file_name = "Резюме.pdf";
            return File(mas, file_type, file_name);
        }
        public FileStreamResult GetStream()
        {
            string path = Server.MapPath("~/Files/Резюме.pdf");
            // Объект Stream
            FileStream fs = new FileStream(path, FileMode.Open);
            string file_type = "application/pdf";
            string file_name = "Резюме.pdf";
            return File(fs, file_type, file_name);
        }

        public string GetContext()
        {
            //Response.Write("Hello!");
            string browser = HttpContext.Request.Browser.Browser;
            string user_agent = HttpContext.Request.UserAgent;
            string url = HttpContext.Request.RawUrl;
            string ip = HttpContext.Request.UserHostAddress;
            string referrer = HttpContext.Request.UrlReferrer == null ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri;
            return "<p>Browser: " + browser + "</p><p>User-Agent: " + user_agent + "</p><p>Url запроса: " + url +
                "</p><p>Реферер: " + referrer + "</p><p>IP-адрес: " + ip + "</p>";
        }

        public ActionResult GetImage()
        {
            string path = "../Content/Images/Panel.jpg";
            return new ImageResult(path);
        }
        public ActionResult GetHtml()
        {
            return new HtmlResult("<h2>Hello World!</h2>");
        }

        public ActionResult GetB(int id)
        {
            Book b = db.Books.Find(id);
            if (b == null) 
                return HttpNotFound();
            return View(b);
        }

       [HttpGet]
        public ActionResult GetBook()
        {
            return View();
        }
        [HttpPost]
        public string GetBook(string title, string author)
        {
            return title + " " + author;
        }
        public string Square()
        {
            int a = Int32.Parse(Request.Params["a"]);
            int h = Int32.Parse(Request.Params["h"]);
            double s = a * h / 2;
            return "<h2>Площать  " + a + " высота  " + h + " равна " + s + "</h2>";
        }
        public string GetId(int id)
        {
            return id.ToString();
        }
        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            Purchase purchase = new Purchase { BookId = id, Person="Unknow" };
            return View(purchase);
        }
        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            db.Purchases.Add(purchase);
            db.SaveChanges();
            return "Спасибо, " + purchase.Person + ", за покупку!";
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
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        //public ActionResult Delete(int id)
        //{
        //    //Book b = db.Books.Find(id);
        //    //if (b != null)
        //    //{
        //    //    db.Books.Remove(b);
        //    //    db.SaveChanges();
        //    //}
        //    Book b = new Book { Id = id };
        //    db.Entry(b).State = EntityState.Deleted;
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Book b = db.Books.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Book b = db.Books.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.Books.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditBook(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Book book = db.Books.Find(id);
            if (book != null)
            {
                return View(book);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditBook(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CreateBook()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateBook(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}