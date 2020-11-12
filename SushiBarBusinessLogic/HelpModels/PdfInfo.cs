using System;
using System.Collections.Generic;
using System.Text;
using SushiBarBusinessLogic.ViewModels;

namespace SushiBarBusinessLogic.HelpModels
{
    class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportDishSushiViewModel> DishSushis { get; set; }
    }
}
