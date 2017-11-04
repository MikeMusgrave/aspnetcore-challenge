using System;
using System.ComponentModel.DataAnnotations;

namespace FoodApp.Models
{
    public enum RatingEnum { Unrated, Terrible, Bad, Meh, Good, Awesome };

    public class FoodItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public string Email { get; set; }
        public RatingEnum Rating { get; set; }    
    }
}
