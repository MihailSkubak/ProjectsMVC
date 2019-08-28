using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LoginMVC.Annotations
{
    public class ValidAuthorAttribute:ValidationAttribute
    {
        private string[] myAuthors;
        public ValidAuthorAttribute(string[] authors)
        {
            myAuthors = authors;
        }
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string strval = value.ToString();
                for (int i = 0; i < myAuthors.Length; i++)
                {
                    if (strval == myAuthors[i])
                        return true;
                }
            }
            return false;
        }
    }
}