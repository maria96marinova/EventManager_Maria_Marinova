using EventManager.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Web.ValidationAttributes
{
    public class EndDateValidationAttribute:ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            EventFormModel model = (EventFormModel)validationContext.ObjectInstance;

            if (model.Start > model.End)
            {
                return new ValidationResult
                    ("The End Date must be greater than the Start Date.");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
