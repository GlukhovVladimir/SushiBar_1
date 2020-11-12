﻿using SushiBarBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SushiBarDatabaseImplement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int? ImplementerId { get; set; }
        public int DishId { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public decimal Sum { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public virtual Dish Dish { get; set; }
        public virtual Client Client { get; set; }
        public virtual Implementer Implementer { get; set; }
    }
}
