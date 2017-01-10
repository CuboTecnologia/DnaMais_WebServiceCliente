using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Cadastral
{
    public class ResponseStatus
    {
        public String ErrorCode { get; set; }
        public String Message { get; set; }
        public String StackTrace { get; set; }
        public List<ResponseError> Errors { get; set; }

        public ResponseStatus()
        {
            this.ErrorCode = String.Empty;
            this.Message = String.Empty;
            this.StackTrace = String.Empty;
            this.Errors = new List<ResponseError>();
        }
    }
}
