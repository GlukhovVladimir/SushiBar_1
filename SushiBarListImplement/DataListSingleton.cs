using SushiBarListImplement.Models;
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
        public List<Client> Clients { get; set; }
        public List<Implementer> Implementers { get; set; }
        public List<MessageInfo> MessageInfoes { get; set; }

        private DataListSingleton()
        {
            Sushis = new List<Sushi>();
            Orders = new List<Order>();
            Dishes = new List<Dish>();
            DishSushis = new List<DishSushi>();
            Clients = new List<Client>();
            Implementers = new List<Implementer>();
            MessageInfoes = new List<MessageInfo>();
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
