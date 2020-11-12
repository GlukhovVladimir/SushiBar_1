using System;
using System.Collections.Generic;
using System.Text;
using SushiBarBusinessLogic.BindingModels;
using SushiBarBusinessLogic.ViewModels;

namespace SushiBarBusinessLogic.Interfaces
{
    public interface IMessageInfoLogic
    {
        List<MessageInfoViewModel> Read(MessageInfoBindingModel model);
        void Create(MessageInfoBindingModel model);
    }
}
