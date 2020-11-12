﻿using SushiBarListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SushiBarListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Sushi> Sushis { get; set; }
        public List<Order> Orders { get; set; }
        public List<Dish> Dishes { get; set; }
        public List<DishSushi> DishSushis { get; set; }
        private DataListSingleton()
        {
            Sushis = new List<Sushi>();
            Orders = new List<Order>();
            Dishes = new List<Dish>();
            DishSushis = new List<DishSushi>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
