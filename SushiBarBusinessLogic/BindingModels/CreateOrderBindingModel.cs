using System;
using System.Collections.Generic;
using System.Text;

namespace SushiBarBusinessLogic.BindingModels
{
    public class CreateOrderBindingModel
    {
        public int DishId { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }
    }
}
