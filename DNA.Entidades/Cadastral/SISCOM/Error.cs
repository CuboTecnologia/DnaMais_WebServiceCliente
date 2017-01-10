using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Cadastral.SISCOM
{
    public class Error
    {
        public String ErrorCode { get; set; }
        public String FieldName { get; set; }
        public String Message { get; set; }

        public Error()
        {
            this.ErrorCode = String.Empty;
            this.FieldName = String.Empty;
            this.Message = String.Empty;
        }
    }
}
