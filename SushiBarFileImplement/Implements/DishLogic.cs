using SushiBarBusinessLogic.BindingModels;
using SushiBarBusinessLogic.Interfaces;
using SushiBarBusinessLogic.ViewModels;
using SushiBarFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SushiBarFileImplement.Implements
{
    public class DishLogic : IDishLogic
    {
        private readonly SushiBarFileDataListSingleton source;
        public DishLogic()
        {
            source = SushiBarFileDataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(DishBindingModel model)
        {
            Dish element = source.Dishes.FirstOrDefault(rec => rec.DishName ==
           model.DishName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть блюдо с таким названием");
            }
            if (model.Id.HasValue)
            {
                element = source.Dishes.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("блюдо не найдено");
                }
            }
            else
            {
                int maxId = source.Dishes.Count > 0 ? source.Dishes.Max(rec =>
               rec.Id) : 0;
                element = new Dish { Id = maxId + 1 };
                source.Dishes.Add(element);
            }
            element.DishName = model.DishName;
            element.Price = model.Price;
            // удалили те, которых нет в модели
            source.DishSushis.RemoveAll(rec => rec.DishId == model.Id &&
           !model.DishSushis.ContainsKey(rec.SushiId));
            // обновили количество у существующих записей
            var updateSushis = source.DishSushis.Where(rec => rec.DishId ==
           model.Id && model.DishSushis.ContainsKey(rec.SushiId));
            foreach (var updateSushi in updateSushis)
            {
                updateSushi.Count =
                model.DishSushis[updateSushi.SushiId].Item2;
                model.DishSushis.Remove(updateSushi.SushiId);
            }
            // добавили новые
            int maxPCId = source.DishSushis.Count > 0 ?
           source.DishSushis.Max(rec => rec.Id) : 0;
            foreach (var sd in model.DishSushis)
            {
                source.DishSushis.Add(new DishSushi
                {
                    Id = ++maxPCId,
                    DishId = element.Id,
                    SushiId = sd.Key,
                    Count = sd.Value.Item2
                });
            }
        }
        public void Delete(DishBindingModel model)
        {
            // удаяем записи по компонентам при удалении изделия
            source.DishSushis.RemoveAll(rec => rec.DishId == model.Id);
            Dish element = source.Dishes.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Dishes.Remove(element);
            }
            else
            {
                throw new Exception("Блюдо не найдено");
            }
        }
        public List<DishViewModel> Read(DishBindingModel model)
        {
            return source.Dishes
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new DishViewModel
            {
                Id = rec.Id,
                DishName = rec.DishName,
                Price = rec.Price,
                DishSushis = source.DishSushis
            .Where(recPC => recPC.DishId == rec.Id)
            .ToDictionary(recPC => recPC.SushiId, recPC =>
            (source.Sushis.FirstOrDefault(recC => recC.Id ==
           recPC.SushiId)?.SushiName, recPC.Count))
            })
            .ToList();
        }
    }
}
