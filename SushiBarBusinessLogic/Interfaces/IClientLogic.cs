using SushiBarBusinessLogic.BindingModels;
using System;
using System.Collections.Generic;
using System.Text;
using SushiBarBusinessLogic.ViewModels;

namespace SushiBarBusinessLogic.Interfaces
{
    public interface IClientLogic
    {
        List<ClientViewModel> Read(ClientBindingModel model);
        void CreateOrUpdate(ClientBindingModel model);
        void Delete(ClientBindingModel model);
    }
}
