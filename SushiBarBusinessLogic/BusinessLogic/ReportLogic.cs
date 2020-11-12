using SushiBarBusinessLogic.BindingModels;
using SushiBarBusinessLogic.HelpModels;
using SushiBarBusinessLogic.Interfaces;
using SushiBarBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SushiBarBusinessLogic.BusinessLogic
{
    public class ReportLogic
    {
        private readonly ISushiLogic sushiLogic;
        private readonly IDishLogic dishLogic;
        private readonly IOrderLogic orderLogic;

        public ReportLogic(IDishLogic dishLogic, ISushiLogic sushiLogic,
       IOrderLogic orderLLogic)
        {
            this.dishLogic = dishLogic;
            this.sushiLogic = sushiLogic;
            this.orderLogic = orderLLogic;
        }

        public List<ReportDishSushiViewModel> GetDishSushi()
        {
            var dishes = dishLogic.Read(null);
            var list = new List<ReportDishSushiViewModel>();
            foreach (var dish in dishes)
            {
                var dishRec = new ReportDishSushiViewModel
                {
                    DishName = dish.DishName,
                    SushiName = " ",
                };
                list.Add(dishRec);
                foreach (var sh in dish.DishSushis)
                {
                    var record = new ReportDishSushiViewModel
                    {
                        DishName = " ",
                        SushiName = sh.Value.Item1,

                    };
                    list.Add(record);
                }
            }
            return list;
        }

        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            List<OrderViewModel> orders = orderLogic.Read(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            });
            return orders.GroupBy(o => o.DateCreate.ToShortDateString())
            .Select(g => new ReportOrdersViewModel
            {
                DateCreate = g.Key,
                OrdersSum = g.Select(o =>
                new Tuple<string, decimal>(o.DishName, o.Sum)).ToList(),
                Sum = g.Sum(o => o.Sum)
            }).ToList(); 
        }

        public void SaveDishesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список блюд",
                Dishes = dishLogic.Read(null)
            });
        }
        public void SaveOrdersToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                Orders = GetOrders(model)
            });
        }

        [Obsolete]
        public void SaveDishSushisToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список блюд с ингридиентами",
                DishSushis = GetDishSushi()
            });
        }
    }
}
