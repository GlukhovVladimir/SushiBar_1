using SushiBarBusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace SushiBarBusinessLogic.ViewModels
{
    public class ClientViewModel : BaseViewModel
    {
        [DataMember]
        [Column(title: "ФИО клиента", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string FIO { get; set; }
        [Column(title: "Логин", width: 150)]
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        [DisplayName("Пароль")]
        public string Password { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "Id",
            "FIO",
            "Login"
        };
    }
}
