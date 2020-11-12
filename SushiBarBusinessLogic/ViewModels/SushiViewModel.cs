using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SushiBarBusinessLogic.ViewModels
{
    public class SushiViewModel
	{
		public int Id { get; set; }

		[DisplayName("Название ингридиента")]
		public string SushiName { get; set; }
	}

}
