using System;
using System.Collections.Generic;
using System.Text;

namespace SushiBarFileImplement.Models
{
    public class DishSushi
    {
        public int Id { get; set; }
        public int DishId { get; set; }
        public int SushiId { get; set; }
        public int Count { get; set; }
    }
}
