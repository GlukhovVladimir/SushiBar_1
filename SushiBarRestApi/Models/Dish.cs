using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SushiBarRestApi.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string DishName { get; set; }
        public decimal Price { get; set; }
    }
}
