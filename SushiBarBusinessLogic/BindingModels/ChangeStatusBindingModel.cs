using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SushiBarBusinessLogic.BindingModels
{
    public class ChangeStatusBindingModel
    {
        public int OrderId { get; set; }
        public int? ImplementerId { get; set; }
    }
}
