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
    public class SushiLogic : ISushiLogic
    {
        private readonly SushiBarFileDataListSingleton source;
        public SushiLogic()
        {
            source = SushiBarFileDataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(SushiBindingModel model)
        {
            Sushi element = source.Sushis.FirstOrDefault(rec => rec.SushiName
           == model.SushiName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть ингридиент с таким названием");
            }
            if (model.Id.HasValue)
            {
                element = source.Sushis.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Ингридиент не найден");
                }
            }
            else
            {
                int maxId = source.Sushis.Count > 0 ? source.Sushis.Max(rec =>
               rec.Id) : 0;
                element = new Sushi { Id = maxId + 1 };
                source.Sushis.Add(element);
            }
            element.SushiName = model.SushiName;
        }
        public void Delete(SushiBindingModel model)
        {
            Sushi element = source.Sushis.FirstOrDefault(rec => rec.Id ==
           model.Id);
            if (element != null)
            {
                source.Sushis.Remove(element);
            }
            else
            {
                throw new Exception("Ингридиент не найден");
            }
        }
        public List<SushiViewModel> Read(SushiBindingModel model)
        {
            return source.Sushis
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new SushiViewModel
            {
                Id = rec.Id,
                SushiName = rec.SushiName
            })
            .ToList();
        }
    }
}
