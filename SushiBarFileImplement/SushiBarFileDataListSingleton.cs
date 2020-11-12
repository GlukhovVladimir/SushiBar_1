using SushiBarBusinessLogic.Enums;
using SushiBarFileImplement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SushiBarFileImplement
{
    public class SushiBarFileDataListSingleton
    {
        private static SushiBarFileDataListSingleton instance;
        private readonly string SushiFileName = "Sushi.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string DishFileName = "Dish.xml";
        private readonly string DishSushiFileName = "DishSushi.xml";
        private readonly string ClientFileName = "Client.xml";
        private readonly string ImplementerFileName = "Implementer.xml";
        public List<Sushi> Sushis { get; set; }
        public List<Order> Orders { get; set; }
        public List<Dish> Dishes { get; set; }
        public List<DishSushi> DishSushis { get; set; }
        public List<Client> Clients { get; set; }
        public List<Implementer> Implementers { get; set; }

        private SushiBarFileDataListSingleton()
        {
            Sushis = LoadSushis();
            Orders = LoadOrders();
            Dishes = LoadDishes();
            DishSushis = LoadDishSushis();
            Clients = LoadClients();
            Implementers = LoadImplementers();
        }
        public static SushiBarFileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new SushiBarFileDataListSingleton();
            }
            return instance;
        }
        ~SushiBarFileDataListSingleton()
        {
            SaveSushis();
            SaveOrders();
            SaveDishes();
            SaveDishSushis();
            SaveClients();
            SaveImplementers();
        }
        private List<Implementer> LoadImplementers()
        {
            var list = new List<Implementer>();
            if (File.Exists(ImplementerFileName))
            {
                XDocument xDocument = XDocument.Load(ImplementerFileName);
                var xElements = xDocument.Root.Elements("Implementer").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new Implementer
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ImplementerFIO = elem.Element("ImplementerFIO").Value,
                        WorkingTime = Convert.ToInt32(elem.Element("WorkingTime").Value),
                        PauseTime = Convert.ToInt32(elem.Element("PauseTime").Value)
                    });
                }
            }
            return list;
        }
        private List<Client> LoadClients()
        {
            var list = new List<Client>();
            if (File.Exists(ClientFileName))
            {
                XDocument xDocument = XDocument.Load(ClientFileName);
                var xElements = xDocument.Root.Elements("Client").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Client
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        FIO = elem.Element("FIO").Value,
                        Login = elem.Element("Login").Value,
                        Password = elem.Element("Password").Value
                    });
                }
            }
            return list;
        }
        private List<Sushi> LoadSushis()
        {
            var list = new List<Sushi>();
            if (File.Exists(SushiFileName))
            {
                XDocument xDocument = XDocument.Load(SushiFileName);
                var xElements = xDocument.Root.Elements("Sushi").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Sushi
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        SushiName = elem.Element("SushiName").Value
                    });
                }
            }
            return list;
        }
        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        DishId = Convert.ToInt32(elem.Element("DishId").Value),
                        ClientId = Convert.ToInt32(elem.Element("ClientId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), elem.Element("Status").Value),
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement = string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? (DateTime?)null :
                        Convert.ToDateTime(elem.Element("DateImplement").Value),
                    });
                }
            }
            return list;
        }
        private List<Dish> LoadDishes()
        {
            var list = new List<Dish>();
            if (File.Exists(DishFileName))
            {
                XDocument xDocument = XDocument.Load(DishFileName);
                var xElements = xDocument.Root.Elements("Dish").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Dish
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        DishName = elem.Element("DishName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value)
                    });
                }
            }
            return list;
        }
        private List<DishSushi> LoadDishSushis()
        {
            var list = new List<DishSushi>();
            if (File.Exists(DishSushiFileName))
            {
                XDocument xDocument = XDocument.Load(DishSushiFileName);
                var xElements = xDocument.Root.Elements("DishSushi").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new DishSushi
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        DishId = Convert.ToInt32(elem.Element("DishId").Value),
                        SushiId = Convert.ToInt32(elem.Element("SushiId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value)
                    });
                }
            }
            return list;
        }

        private void SaveImplementers()
        {
            if (Implementers != null)
            {
                var xElement = new XElement("Implementers");
                foreach (var implementer in Implementers)
                {
                    xElement.Add(new XElement("Implementer",
                    new XAttribute("Id", implementer.Id),
                    new XElement("ImplementerFIO", implementer.ImplementerFIO),
                    new XElement("WorkingTime", implementer.WorkingTime),
                    new XElement("PauseTime", implementer.PauseTime)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ImplementerFileName);
            }
        }
        private void SaveClients()
        {
            if (Clients != null)
            {
                var xElement = new XElement("Clients");
                foreach (var client in Clients)
                {
                    xElement.Add(new XElement("Client",
                    new XAttribute("Id", client.Id),
                    new XElement("FIO", client.FIO),
                    new XElement("Login", client.Login),
                    new XElement("Password", client.Password)));
                }
            }
        }
        private void SaveSushis()
        {
            if (Sushis != null)
            {
                var xElement = new XElement("Sushis");
                foreach (var sushi in Sushis)
                {
                    xElement.Add(new XElement("Sushi",
                    new XAttribute("Id", sushi.Id),
                    new XElement("SushiName", sushi.SushiName)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(SushiFileName);
            }
        }
        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");
                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("ClientId", order.ClientId),
                    new XElement("DishId", order.DishId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }
        private void SaveDishes()
        {
            if (Dishes != null)
            {
                var xElement = new XElement("Dishes");
                foreach (var dish in Dishes)
                {
                    xElement.Add(new XElement("Dish",
                    new XAttribute("Id", dish.Id),
                    new XElement("DishName", dish.DishName),
                    new XElement("Price", dish.Price)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(DishFileName);
            }
        }
        private void SaveDishSushis()
        {
            if (DishSushis != null)
            {
                var xElement = new XElement("DishSushis");
                foreach (var dishSushi in DishSushis)
                {
                    xElement.Add(new XElement("DishSushi",
                    new XAttribute("Id", dishSushi.Id),
                    new XElement("DishId", dishSushi.DishId),
                    new XElement("SushiId", dishSushi.SushiId),
                    new XElement("Count", dishSushi.Count)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(DishSushiFileName);
            }
        }
    }
}
