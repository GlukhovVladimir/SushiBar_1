using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SushiBarBusinessLogic.BindingModels
{
    public class SushiBindingModel
    {
        public int? Id { get; set; }

        public string SushiName { get; set; }
    }
}
