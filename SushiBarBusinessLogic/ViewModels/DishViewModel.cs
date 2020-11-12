using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SushiBarBusinessLogic.ViewModels
{
    public class DishViewModel
	{
		public int Id { get; set; }


		[DisplayName("Название блюда")]
		public string DishName { get; set; }


		[DisplayName("Цена")]
		public decimal Price { get; set; }


		public Dictionary<int, (string, int)> DishSushis { get; set; }
	}

}
