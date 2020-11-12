using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SushiBarBusinessLogic.BindingModels
{
    public class DishBindingModel
    {
		public int? Id { get; set; }

		public string DishName { get; set; }

		public decimal Price { get; set; }

		public Dictionary<int, (string, int)> DishSushis { get; set; }

	}
}
