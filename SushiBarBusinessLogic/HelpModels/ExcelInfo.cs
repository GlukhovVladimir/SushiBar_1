using System;
using System.Collections.Generic;
using System.Text;
using SushiBarBusinessLogic.ViewModels;

namespace SushiBarBusinessLogic.HelpModels
{
    class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportOrdersViewModel> Orders { get; set; }
    }
}
