using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Cadastral.SISCOM
{
    public class InputItem
    {
        public String Key { get; set; }
        public String Value { get; set; }

        public InputItem()
        {
            this.Key = String.Empty;
            this.Value = String.Empty;
        }
    }
}
