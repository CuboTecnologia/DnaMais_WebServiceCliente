using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Cadastral.SISCOM
{
    public class Response
    {
        public List<InputItem> Input { get; set; }
        public Output Output { get; set; }
        public Status Status { get; set; }
        public ResponseError ResponseError { get; set; }

        public Response()
        {
            this.Input = new List<InputItem>();
            this.Output = new Output();
            this.Status = new Status();
            this.ResponseError = new ResponseError();
        }
    }
}
