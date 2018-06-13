using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Web.ValidationAttributes
{
    public class FutureDateAttribute:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return (DateTime)value > DateTime.UtcNow;
         
        }

    }
}
