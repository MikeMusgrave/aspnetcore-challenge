using System;
using System.ComponentModel.DataAnnotations;

namespace FoodApp.Models
{
    public enum Rating { Unrated, Terrible, Bad, Meh, Good, Awesome };

    public class FoodItem
    {
        public Guid Id { get; set; }

        [StringLength(60, MinimumLength = 2)]
        [Required]
        public string Name { get; set; }

        [StringLength(512)]
        public string URL { get; set; }

        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please enter a valid email address")]
        [StringLength(256)]
        public string Email { get; set; }

        [EnumDataType(typeof(Rating), ErrorMessage = "Please choose a Rating value")]
        [Required]
        public Rating Rating { get; set; }    
    }
}
