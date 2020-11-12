using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SushiBarDatabaseImplement.Models
{
   public class Sushi
    {
        public int Id { get; set; }

        [Required]
        public string SushiName { get; set; }

        [ForeignKey("SushiId")]
        public virtual List<DishSushi> DishSushis { get; set; }
    }
}
