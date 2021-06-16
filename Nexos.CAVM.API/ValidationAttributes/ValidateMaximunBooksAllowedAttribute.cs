using Nexos.CAVM.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nexos.CAVM.API.ValidationAttributes
{
    public class ValidateMaximunBooksAllowedAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var book = (BookForCreationDto)validationContext.ObjectInstance;
            
            if (book.MaxBooksAllowed > 0 && book.MaxBooksAllowed < book.NumberBooksRegistered)
            {
                return new ValidationResult(ErrorMessage,
                    new[] { nameof(BookForCreationDto) });
            }

            return ValidationResult.Success;
        }
    }
}
