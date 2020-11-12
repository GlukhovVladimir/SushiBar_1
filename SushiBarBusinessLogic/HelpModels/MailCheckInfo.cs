using SushiBarBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SushiBarBusinessLogic.HelpModels
{
    public class MailCheckInfo
    {
        public string PopHost { get; set; }
        public int PopPort { get; set; }
        public IMessageInfoLogic Logic { get; set; }
    }
}
