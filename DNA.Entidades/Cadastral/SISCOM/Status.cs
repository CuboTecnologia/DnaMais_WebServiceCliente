using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Cadastral.SISCOM
{
    public class Status
    {
        public int Code { get; set; }
        public DateTime? DateTime { get; set; }
        public String Detail { get; set; }
        public String Message { get; set; }
        public String Protocol { get; set; }
        public String Source { get; set; }
        public String Type { get; set; }

        public Status()
        {
            this.Code = 0;
            this.DateTime = null;
            this.Detail = String.Empty;
            this.Message = String.Empty;
            this.Protocol = String.Empty;
            this.Source = String.Empty;
            this.Type = String.Empty;
        }
    }
}
