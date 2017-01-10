using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Cadastral
{
    public class ResponseError
    {
        public String ErrorCode { get; set; }
        public String FieldName { get; set; }
        public String Message { get; set; }

        public ResponseError()
        {
            this.ErrorCode = String.Empty;
            this.FieldName = String.Empty;
            this.Message = String.Empty;
        }
    }
}
