using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using LoginMVC.Models;

namespace LoginMVC.Annotations
{
    public class NotAllowedAttribute:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Book book = value as Book;
            if (book.Author == "Л. Толстой" && book.Year > 1910)
            {
                return false;
            }
            return true ;
        }
    }
}