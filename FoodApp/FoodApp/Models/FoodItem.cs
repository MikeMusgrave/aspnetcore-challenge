using System;
using System.ComponentModel.DataAnnotations;
using FoodApp.Validation;

namespace FoodApp.Models
{
    public class FoodItem
    {
        public Guid Id { get; set; }

        [StringLength(30)]
        [Required]
        public string Name { get; set; }

        [StringLength(512)]
        [RegularExpression(@"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)")]
        public string URL { get; set; }

        [StringLength(256)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")]
        public string Email { get; set; }

        [ValidateEnumValue]
        public Rating Rating { get; set; }    
    }
}
