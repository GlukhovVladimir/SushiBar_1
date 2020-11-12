using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace SushiBarBusinessLogic.ViewModels
{
    public class ReportDishSushiViewModel
    {
        public string DishName { get; set; }
        public string SushiName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Sushis { get; set; }
    }
}
