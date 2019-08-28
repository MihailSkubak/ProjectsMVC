using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PageNavigation.Models
{
    public class MobileContext:DbContext
    {
        public DbSet<Phone> Phones { get; set; }
    }
    public class MobileDbInitializer : DropCreateDatabaseAlways<MobileContext>
    {
        protected override void Seed(MobileContext db)
        {
            db.Phones.Add(new Phone { Id = 1, Model = "Samsung Galaxy III", Producer = "Samsung" });
            db.Phones.Add(new Phone { Id = 2, Model = "Samsung Ace II", Producer = "Samsung" });
            db.Phones.Add(new Phone { Id = 3, Model = "HTC Hero", Producer = "HTC" });
            db.Phones.Add(new Phone { Id = 4, Model = "HTC One S", Producer = "HTC" });
            db.Phones.Add(new Phone { Id = 5, Model = "HTC One X", Producer = "HTC" });
            db.Phones.Add(new Phone { Id = 6, Model = "LG Optimus 3D", Producer = "LG" });
            db.Phones.Add(new Phone { Id = 7, Model = "Nokia N9", Producer = "Nokia" });
            db.Phones.Add(new Phone { Id = 8, Model = "Samsung Galaxy Nexus", Producer = "Samsung" });
            db.Phones.Add(new Phone { Id = 9, Model = "Sony Xperia X10", Producer = "SONY" });
            db.Phones.Add(new Phone { Id = 10, Model = "Samsung Galaxy II", Producer = "Samsung" });
            db.SaveChanges();
        }
    }
}