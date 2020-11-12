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
    public class DishLogic : IDishLogic
    {
        public void CreateOrUpdate(DishBindingModel model)
        {
            using (var context = new SushiBarDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Dish element = context.Dishes.FirstOrDefault(rec =>
                       rec.DishName == model.DishName && rec.Id != model.Id);
                        if (element != null)
                        {
                            throw new Exception("Уже есть блюдо с таким названием");
                        }
                        if (model.Id.HasValue)
                        {
                            element = context.Dishes.FirstOrDefault(rec => rec.Id ==
                           model.Id);
                            if (element == null)
                            {
                                throw new Exception("Элемент не найден");
                            }
                        }
                        else
                        {
                            element = new Dish();
                            context.Dishes.Add(element);
                        }
                        element.DishName = model.DishName;
                        element.Price = model.Price;
                        context.SaveChanges();
                        if (model.Id.HasValue)
                        {
                            var productComponents = context.DishSushis.Where(rec
                           => rec.DishId == model.Id.Value).ToList();
                            // удалили те, которых нет в модели
                            context.DishSushis.RemoveRange(productComponents.Where(rec =>
                            !model.DishSushis.ContainsKey(rec.SushiId)).ToList());
                            context.SaveChanges();
                            // обновили количество у существующих записей
                            foreach (var updateComponent in productComponents)
                            {
                                updateComponent.Count =
                               model.DishSushis[updateComponent.SushiId].Item2;

                                model.DishSushis.Remove(updateComponent.SushiId);
                            }
                            context.SaveChanges();
                        }
                        // добавили новые
                        foreach (var pc in model.DishSushis)
                        {
                            context.DishSushis.Add(new DishSushi
                            {
                                DishId = element.Id,
                                SushiId = pc.Key,
                                Count = pc.Value.Item2
                            });
                            context.SaveChanges();
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Delete(DishBindingModel model)
        {
            using (var context = new SushiBarDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        // удаяем записи по компонентам при удалении изделия
                        context.DishSushis.RemoveRange(context.DishSushis.Where(rec =>
                        rec.DishId == model.Id));
                        Dish element = context.Dishes.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element != null)
                        {
                            context.Dishes.Remove(element);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Элемент не найден");
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public List<DishViewModel> Read(DishBindingModel model)
        {
            using (var context = new SushiBarDatabase())
            {
                return context.Dishes
                .Where(rec => model == null || rec.Id == model.Id)
                .ToList()
               .Select(rec => new DishViewModel
               {
                   Id = rec.Id,
                   DishName = rec.DishName,
                   Price = rec.Price,
                   DishSushis = context.DishSushis
                .Include(recPC => recPC.Sushi)
               .Where(recPC => recPC.DishId == rec.Id)
               .ToDictionary(recPC => recPC.SushiId, recPC =>
                (recPC.Sushi?.SushiName, recPC.Count))
               })
               .ToList();
            }
        }
    }
}
