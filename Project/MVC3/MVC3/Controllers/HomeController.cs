using MVC3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC3.Controllers
{
    public class HomeController : Controller
    {

        private StudentsContext db = new StudentsContext();
       // [Route("My/Account")]
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }
     
        public ActionResult Details(int id = 0)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        public ActionResult Edit(int id = 0)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.Courses = db.Courses.ToList();
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student student, int[] selectedCourses)
        {
            Student newStudent = db.Students.Find(student.Id);
            newStudent.Name = student.Name;
            newStudent.Surname = student.Surname;

            newStudent.Courses.Clear();
            if (selectedCourses != null)
            {
                //получаем выбранные курсы
                foreach (var c in db.Courses.Where(co => selectedCourses.Contains(co.Id)))
                {
                    newStudent.Courses.Add(c);
                }
            }

            db.Entry(newStudent).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            ViewBag.Courses = db.Courses.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student, int[] selectedCourses)
        {
            if (selectedCourses != null)
            {
                //получаем выбранные курсы
                foreach (var c in db.Courses.Where(co => selectedCourses.Contains(co.Id)))
                {
                    student.Courses.Add(c);
                }
            }

            db.Students.Add(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult GetList()
        {
            string[] states = new string[] {"USA","Canada","Ukraine","Poland"};
            //ViewBag.Message = "Это частичное представление.";
            return PartialView(states);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Array()
        {
            return View();
        }
        [HttpPost]
        public string Array(List<string> names)
        {
            string fin = "";
            for (int i = 0; i < names.Count; i++)
            {
                fin += names[i] + ";  ";
            }
            return fin;
        }
        public ActionResult EditBook()
        {
            List<Book> books = new List<Book>();
            books.Add(new Book { Name = "Война и мир", Author = "Л. Толстой", Price = 200 });
            books.Add(new Book { Name = "Отцы и дети", Author = "И. Тургенев", Price = 150 });
            books.Add(new Book { Name = "Чайка", Author = "А. Чехов", Price = 100 });
            return View(books);
        }
    [HttpPost]
        public string EditBook(List<Book> books)
        {
            return books.Count.ToString();
        }

    [HttpGet]
    public ActionResult GetAuthor()
    {
        return View();
    }
    [HttpPost]
    public ActionResult GetAuthor(Author author)
    {
        return View();
    }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}