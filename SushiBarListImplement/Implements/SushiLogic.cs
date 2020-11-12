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
    
    public class SushiLogic : ISushiLogic
    {
        private readonly DataListSingleton source;
        public SushiLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(SushiBindingModel model)
        {
            Sushi tempSushi = model.Id.HasValue ? null : new Sushi
            {
                Id = 1
            };
            foreach (var sushi in source.Sushis)
            {
                if (sushi.SushiName == model.SushiName && sushi.Id !=
               model.Id)
                {
                    throw new Exception("Уже есть ингридиент с таким названием");
                }
                if (!model.Id.HasValue && sushi.Id >= tempSushi.Id)
                {
                    tempSushi.Id = sushi.Id + 1;
                }
                else if (model.Id.HasValue && sushi.Id == model.Id)
                {
                    tempSushi = sushi;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempSushi == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempSushi);
            }
            else
            {
                source.Sushis.Add(CreateModel(model, tempSushi));
            }
        }
        public void Delete(SushiBindingModel model)
        {
            for (int i = 0; i < source.Sushis.Count; ++i)
            {
                if (source.Sushis[i].Id == model.Id.Value)
                {
                    source.Sushis.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        public List<SushiViewModel> Read(SushiBindingModel model)
        {
            List<SushiViewModel> result = new List<SushiViewModel>();
            foreach (var Sushi in source.Sushis)
            {
                if (model != null)
                {
                    if (Sushi.Id == model.Id)
                    {
                        result.Add(CreateViewModel(Sushi));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(Sushi));
            }
            return result;
        }
        private Sushi CreateModel(SushiBindingModel model, Sushi sushi)
        {
            sushi.SushiName = model.SushiName;
            return sushi;
        }
        private SushiViewModel CreateViewModel(Sushi sushi)
        {
            return new SushiViewModel
            {
                Id = sushi.Id,
                SushiName = sushi.SushiName
            };
        }
    }
}
