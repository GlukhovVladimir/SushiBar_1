using SushiBarBusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace SushiBarBusinessLogic.ViewModels
{
    public class DishViewModel : BaseViewModel
    {
        [Column(title: "Название блюда", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public string DishName { get; set; }
        [Column(title: "Цена", width: 50)]
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> DishSushis { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "Id",
            "DishName",
            "Price"
        };
    }

}
