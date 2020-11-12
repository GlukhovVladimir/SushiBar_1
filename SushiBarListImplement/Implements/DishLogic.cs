using SushiBarBusinessLogic.BindingModels;
using SushiBarBusinessLogic.Interfaces;
using SushiBarBusinessLogic.ViewModels;
using SushiBarListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SushiBarListImplement.Implements
{
    public class DishLogic : IDishLogic
    {
        private readonly DataListSingleton source;
        public DishLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(DishBindingModel model)
        {
            Dish tempDish = model.Id.HasValue ? null : new Dish { Id = 1 };
            foreach (var dish in source.Dishes)
            {
                if (dish.DishName == model.DishName && dish.Id != model.Id)
                {
                    throw new Exception("Уже есть суши с таким названием");
                }
                if (!model.Id.HasValue && dish.Id >= tempDish.Id)
                {
                    tempDish.Id = dish.Id + 1;
                }
                else if (model.Id.HasValue && dish.Id == model.Id)
                {
                    tempDish = dish;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempDish == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempDish);
            }
            else
            {
                source.Dishes.Add(CreateModel(model, tempDish));
            }
        }
        public void Delete(DishBindingModel model)
        {
            for (int i = 0; i < source.DishSushis.Count; ++i)
            {
                if (source.DishSushis[i].DishId == model.Id)
                {
                    source.DishSushis.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Dishes.Count; ++i)
            {
                if (source.Dishes[i].Id == model.Id)
                {
                    source.Dishes.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Судно не найдено");
        }
        private Dish CreateModel(DishBindingModel model, Dish dish)
        {
            dish.DishName = model.DishName;
            dish.Price = model.Price;
            int maxPCId = 0;
            for (int i = 0; i < source.DishSushis.Count; ++i)
            {
                if (source.DishSushis[i].Id > maxPCId)
                {
                    maxPCId = source.DishSushis[i].Id;
                }
                if (source.DishSushis[i].DishId == dish.Id)
                {
                    if
                    (model.DishSushis.ContainsKey(source.DishSushis[i].SushiId))
                    {
                        source.DishSushis[i].Count =
                        model.DishSushis[source.DishSushis[i].SushiId].Item2;
                        model.DishSushis.Remove(source.DishSushis[i].SushiId);
                    }
                    else
                    {
                        source.DishSushis.RemoveAt(i--);
                    }
                }
            }

            foreach (var pc in model.DishSushis)
            {
                source.DishSushis.Add(new DishSushi
                {
                    Id = ++maxPCId,
                    DishId = dish.Id,
                    SushiId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
            return dish;
        }
        public List<DishViewModel> Read(DishBindingModel model)
        {
            List<DishViewModel> result = new List<DishViewModel>();
            foreach (var component in source.Dishes)
            {
                if (model != null)
                {
                    if (component.Id == model.Id)
                    {
                        result.Add(CreateViewModel(component));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(component));
            }
            return result;
        }
        private DishViewModel CreateViewModel(Dish dish)
        {
            Dictionary<int, (string, int)> dishComponents = new Dictionary<int,
                (string, int)>();
            foreach (var pc in source.DishSushis)
            {
                if (pc.DishId == dish.Id)
                {
                    string componentName = string.Empty;
                    foreach (var component in source.Sushis)
                    {
                        if (pc.SushiId == component.Id)
                        {
                            componentName = component.SushiName;
                            break;
                        }
                    }
                    dishComponents.Add(pc.SushiId, (componentName, pc.Count));
                }
            }
            return new DishViewModel
            {
                Id = dish.Id,
                DishName = dish.DishName,
                Price = dish.Price,
                DishSushis = dishComponents
            };
        }
    }
}
