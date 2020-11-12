using SushiBarBusinessLogic.BindingModels;
using SushiBarBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SushiBarBusinessLogic.Interfaces
{
   public interface IDishLogic
	{
		List<DishViewModel> Read(DishBindingModel model);

		void CreateOrUpdate(DishBindingModel model);

		void Delete(DishBindingModel model);
	}

}
