using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ASP.NET_MVC.Models
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

    }
    public class BookDbInitializer : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext db)
        {
            db.Books.Add(new Book {Name="Война и мир",Author="Л. Толстой",Price =200 });
            db.Books.Add(new Book { Name = "Отцы и дети", Author = "И. Тургенев", Price = 150 });
            db.Books.Add(new Book { Name = "Чайка", Author = "А. Чехов", Price = 100 });
            base.Seed(db);
        }
    }
}