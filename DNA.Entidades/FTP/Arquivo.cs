using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.FTP
{
    public class Arquivo
    {
        public string Nome { get; set; }
        public string Tamanho { get; set; }
        public DateTime DataCompletaCriacao { get; set; }
        public string DataCriacao { get; set; }
        public string HoraCriacao { get; set; }
        public string Extensao { get; set; }
        public string NomeExtensao { get; set; }

        public Arquivo()
        { }
    }

}
