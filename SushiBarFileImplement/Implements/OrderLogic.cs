﻿using SushiBarBusinessLogic.BindingModels;
using SushiBarBusinessLogic.Enums;
using SushiBarBusinessLogic.Interfaces;
using SushiBarBusinessLogic.ViewModels;
using SushiBarFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SushiBarFileImplement.Implements
{
    public class OrderLogic : IOrderLogic
    {
        private readonly SushiBarFileDataListSingleton source;

        public OrderLogic()
        {
            source = SushiBarFileDataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(OrderBindingModel model)
        {
            Order element;
            if (model.Id.HasValue)
            {
                element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Заказ не найден");
                }
            }
            else
            {
                int maxId = source.Orders.Count > 0 ? source.Orders.Max(rec => rec.Id) : 0;
                element = new Order { Id = maxId + 1 };
                source.Orders.Add(element);
            }
            element.DishId = model.DishId;
            element.ClientId = model.ClientId.Value;
            element.ImplementerId = model.ImplementerId;
            element.Count = model.Count;
            element.Sum = model.Sum;
            element.Status = model.Status;
            element.DateCreate = model.DateCreate;
            element.DateImplement = model.DateImplement;
        }

        public void Delete(OrderBindingModel model)
        {
            Order element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Orders.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            return source.Orders

           .Where(rec => model == null || rec.Id == model.Id
           || rec.DateCreate >= model.DateFrom.Value
           && rec.DateCreate <= model.DateTo.Value
           || model.ClientId.HasValue && model.ClientId == rec.ClientId
           || model.FreeOrders.HasValue && model.FreeOrders.Value &&
           !rec.ImplementerId.HasValue
           || model.ImplementerId.HasValue && rec.ImplementerId ==
            model.ImplementerId && rec.Status == OrderStatus.Выполняется)
           .Select(rec => new OrderViewModel
           {
               Id = rec.Id,
               DishId = rec.DishId,
               ClientId = rec.ClientId,
               ClientLogin = source.Clients.FirstOrDefault(cl =>
               cl.Id == rec.Id)?.Login,
               ImplementerId = rec.ImplementerId,
               ImplementerFIO = source.Implementers.FirstOrDefault(recC =>
               recC.Id == rec.ImplementerId)?.ImplementerFIO,
               DishName = source.Dishes.FirstOrDefault(mod =>
               mod.Id == rec.DishId)?.DishName,
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
