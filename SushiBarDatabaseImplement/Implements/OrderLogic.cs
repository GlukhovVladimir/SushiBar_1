using Microsoft.EntityFrameworkCore;
using SushiBarBusinessLogic.BindingModels;
using SushiBarBusinessLogic.Interfaces;
using SushiBarBusinessLogic.ViewModels;
using SushiBarDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SushiBarDatabaseImplement.Implements
{
    public class OrderLogic : IOrderLogic
    {
        public void CreateOrUpdate(OrderBindingModel model)
        {
            using (var context = new SushiBarDatabase())
            {
                Order element;
                if (model.Id.HasValue)
                {
                    element = context.Orders.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Order();
                    context.Orders.Add(element);
                }
                element.DishId = model.DishId == 0 ? element.DishId : model.DishId;
                element.ClientId = model.ClientId.Value;
                element.Count = model.Count;
                element.Sum = model.Sum;
                element.Status = model.Status;
                element.DateCreate = model.DateCreate;
                element.DateImplement = model.DateImplement;
                context.SaveChanges();
            }
        }
        public void Delete(OrderBindingModel model)
        {
            using (var context = new SushiBarDatabase())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id ==
model.Id);
                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            using (var context = new SushiBarDatabase())
            {
                return context.Orders
                .Include(rec => rec.Dish)
                .Where(rec => model == null || rec.Id == model.Id
                || (model.DateFrom.HasValue && model.DateTo.HasValue
                && rec.DateCreate >= model.DateFrom.Value
                && rec.DateCreate <= model.DateTo.Value)
                || model.ClientId.HasValue && model.ClientId == rec.ClientId)
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    DishId = rec.DishId,
                    DishName = rec.Dish.DishName,
                    ClientId = rec.ClientId,
                    ClientLogin = rec.Client.Login,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement
                })
            .ToList();
            }
        }
    }
}
