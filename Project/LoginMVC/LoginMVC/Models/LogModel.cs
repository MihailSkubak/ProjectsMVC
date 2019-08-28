using LoginMVC.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LoginMVC.Models
{
    public class LogModel
    {
        ////[Display(Name="Login")]
       // [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",ErrorMessage="Неккоректный адрес!")]
        public string Login { get; set; }
       // [DataType(DataType.Password)]
        public string Password { get; set; }
        //[Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string PasswordConfirm { get; set; }
    }
    //[NotAllowed(ErrorMessage="Недопустимая книга!")]



    //[Bind(Exclude="Year")] // Привязка модели
    public class Book
    {
        //[HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        //[Required(ErrorMessage="Input something!")]
        //[Remote("CheckName","Home",ErrorMessage="Некорректное название!")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        //[Required]
        //[StringLength(10,MinimumLength=2,ErrorMessage="Big or small letters!")]
        //[ValidAuthor(new string[] { "Л. Толстой", "А. Пушкин", "Ф. Достоевский", "И. Тургенев" }, ErrorMessage = "Недопустимый автор")]
        [Display(Name = "Автор")]
        public string Author { get; set; }

        //[Required]
        //[Range(1800,2000,ErrorMessage="Not true year")]
        [Display(Name = "Год")]
        public int Year { get; set; }
    }
}