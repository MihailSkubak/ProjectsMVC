using LoginMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginMVC.Validators
{
    public class MyValidationProvider:ModelValidatorProvider
    {
        public override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context)
        {
            if (metadata.ContainerType == typeof(Book))
            {
                return new ModelValidator[] { new BookPropertyValidator(metadata, context) };
            }

            if (metadata.ModelType == typeof(Book))
            {
                return new ModelValidator[] { new BookValidator(metadata, context) };
            }

            return Enumerable.Empty<ModelValidator>();
        }
    }
    public class BookPropertyValidator : ModelValidator
    {
        public BookPropertyValidator(ModelMetadata metadata, ControllerContext context)
            : base(metadata, context)
        { }

        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            Book b = container as Book;
            if (b != null)
            {
                switch (Metadata.PropertyName)
                {
                    case "Name":
                        if (string.IsNullOrEmpty(b.Name))
                        {
                            return new ModelValidationResult[]{
                            new ModelValidationResult { MemberName="Name", Message="Введите название книги"}
                        };
                        }
                        break;
                    case "Author":
                        if (string.IsNullOrEmpty(b.Author))
                        {
                            return new ModelValidationResult[]{
                            new ModelValidationResult { MemberName="Author", Message="Введите автора книги"}
                        };
                        }
                        break;
                    case "Year":
                        if (b.Year > 2000 || b.Year < 1700)
                        {
                            return new ModelValidationResult[]{
                            new ModelValidationResult { MemberName="Year", Message="Недопустимый год"}
                        };
                        }
                        break;
                }
            }
            return Enumerable.Empty<ModelValidationResult>();
        }
    }

    public class BookValidator : ModelValidator
    {
        public BookValidator(ModelMetadata metadata, ControllerContext context)
            : base(metadata, context)
        { }

        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            Book b = (Book)Metadata.Model;

            List<ModelValidationResult> errors = new List<ModelValidationResult>();

            if (b.Name == "Преступление и наказание" && b.Author == "Ф. Достоевский" && b.Year == 1866)
            {
                errors.Add(new ModelValidationResult { MemberName = "", Message = "Недопустимая книга" });
            }
            return errors;
        }
    }
}