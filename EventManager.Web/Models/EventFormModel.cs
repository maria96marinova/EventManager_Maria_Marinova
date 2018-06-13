using EventManager.Web.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Web.Models
{
    public class EventFormModel
    {
        [Required]
        [StringLength(100,ErrorMessage ="The length must be at most 100 characters.")]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The length must be at most 100 characters.")]
        public string Location { get; set; }

        [Required]
        [FutureDate(ErrorMessage = "Start date must be in the future.")]
        public DateTime Start { get; set; }

        [Required]
        [EndDateValidation(ErrorMessage = "The End Date must be greater than the Start Date.")]
        public DateTime End { get; set; }

        public string UserId { get; set; }

    }
}
