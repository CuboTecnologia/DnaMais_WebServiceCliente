using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Cadastral.PFPrata
{
    public class Response
    {
        public Entidades.Cadastral.Controle Controle { get; set; }
        public Entidades.Cadastral.DadosCadastrais DadosCadastrais { get; set; }
        public List<Email> Emails { get; set; }
        public List<Endereco> Enderecos { get; set; }
        public Entidades.Cadastral.PEP PEP { get; set; }
        public List<Telefone> Telefones { get; set; }
        public List<Vinculo> Vinculos { get; set; }
        public Entidades.Cadastral.ResponseStatus ResponseStatus { get; set; }

        public Response()
        {
            this.Controle = new Entidades.Cadastral.Controle();
            this.DadosCadastrais = new Entidades.Cadastral.DadosCadastrais();
            this.Emails = new List<Email>();
            this.Enderecos = new List<Endereco>();
            this.PEP = new PEP();
            this.Telefones = new List<Telefone>();
            this.Vinculos = new List<Vinculo>();
            this.ResponseStatus = new ResponseStatus();
        }
    }
}
