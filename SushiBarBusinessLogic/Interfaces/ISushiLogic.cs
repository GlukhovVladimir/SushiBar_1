using SushiBarBusinessLogic.BindingModels;
using SushiBarBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SushiBarBusinessLogic.Interfaces
{
    public interface ISushiLogic
	{
		List<SushiViewModel> Read(SushiBindingModel model);


		void CreateOrUpdate(SushiBindingModel model);


		void Delete(SushiBindingModel model);
	}

}
