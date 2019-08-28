using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PageNavigation.Models;
using System.Data.Entity;

namespace PageNavigation.Controllers
{
    public class HomeController : Controller
    {
        MobileContext db = new MobileContext();
        public ActionResult Index(int page=1)
        {
            int pageSize = 3; // количество объектов на страницу
            IEnumerable<Phone> phonesPerPages = db.Phones.OrderBy(x => x.Id).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = db.Phones.Count() };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Phones = phonesPerPages };
            return View(ivm);
        }


        public ActionResult Filtr(string position)
        {
            IQueryable<Phone> phones = db.Phones;
        if (!String.IsNullOrEmpty(position) && !position.Equals("Все"))
        {
            phones = phones.Where(p => p.Model == position);
        }
        List<Phone> teams = db.Phones.ToList();
        teams.Insert(0, new Phone { Model = "Все", Id = 0 });
        PhonesListViewModel plvm = new PhonesListViewModel
        {
            Phones=phones.ToList(),
            Teams = new SelectList(teams, "Id", "Model"),
            Models = new SelectList(new List<string>()
            {
                "Все",
                "Модель",
                "Производитель"
            })
        };
        return View(plvm);
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