using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SushiBarDatabaseImplement.Models
{
    public class DishSushi
    {
        public int Id { get; set; }
        public int DishId { get; set; }
        public int SushiId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Sushi Sushi { get; set; }
        public virtual Dish Dish { get; set; }
    }
}
