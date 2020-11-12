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
    public class SushiLogic : ISushiLogic
    {
        public void CreateOrUpdate(SushiBindingModel model)
        {
            using (var context = new SushiBarDatabase())
            {
                Sushi element = context.Sushis.FirstOrDefault(rec =>
               rec.SushiName == model.SushiName && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("Уже есть ингридиент с таким названием");
                }
                if (model.Id.HasValue)
                {
                    element = context.Sushis.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Sushi();
                    context.Sushis.Add(element);
                }
                element.SushiName = model.SushiName;
                context.SaveChanges();
            }
        }
        public void Delete(SushiBindingModel model)
        {
            using (var context = new SushiBarDatabase())
            {
                Sushi element = context.Sushis.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Sushis.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<SushiViewModel> Read(SushiBindingModel model)
        {
            using (var context = new SushiBarDatabase())
            {
                return context.Sushis
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
}
