using System;
using System.Collections.Generic;
using System.Text;
using SushiBarBusinessLogic.Enums;
using System.ComponentModel;

namespace SushiBarBusinessLogic.ViewModels
{
   public class ReportOrdersViewModel
    {
        public string DateCreate { get; set; }
        public List<Tuple<string, decimal>> OrdersSum { get; set; }
        public decimal Sum { get; set; }
    }
}
