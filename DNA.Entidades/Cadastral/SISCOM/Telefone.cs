using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Cadastral.SISCOM
{
    public class Telefone
    {
        public int DDD { get; set; }
        public int Numero { get; set; }

        public Telefone()
        {
            this.DDD = 0;
            this.Numero = 0;
        }
    }
}
