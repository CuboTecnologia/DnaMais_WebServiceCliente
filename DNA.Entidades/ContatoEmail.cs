using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades
{
    public class ContatoEmail
    {
        public string NomeDestinatario { get; set; }

        public string SiteDestinatario { get; set; }

        public string EmailDestinatario { get; set; }

        public string Assunto { get; set; }

        public string Mensagem { get; set; }

        public ContatoEmail()
        { }
    }
}
