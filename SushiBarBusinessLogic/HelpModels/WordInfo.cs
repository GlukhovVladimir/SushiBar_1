using SushiBarBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SushiBarBusinessLogic.HelpModels
{
    class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<DishViewModel> Dishes { get; set; }
    }
}
