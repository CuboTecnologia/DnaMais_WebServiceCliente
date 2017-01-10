using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Cadastral.SISCOM
{
    public class ResponseError
    {
        public String ErrorCode { get; set; }
        public String Message { get; set; }
        public String StackTrace { get; set; }
        public List<Error> Errors { get; set; }

        public ResponseError()
        {
            this.ErrorCode = String.Empty;
            this.Message = String.Empty;
            this.StackTrace = String.Empty;
            this.Errors = new List<Error>();
        }
    }
}
