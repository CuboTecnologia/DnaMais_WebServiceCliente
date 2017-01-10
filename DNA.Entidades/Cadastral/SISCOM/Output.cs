using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Cadastral.SISCOM
{
    public class Output
    {
        public DadosCadastrais DadosCadastrais { get; set; }
        public List<Email> Emails { get; set; }
        public List<Endereco> Enderecos { get; set; }
        public List<Telefone> Telefones { get; set; }
        
        public Output()
        {
            this.DadosCadastrais = new DadosCadastrais();
            this.Emails = new List<Email>();
            this.Enderecos = new List<Endereco>();
            this.Telefones = new List<Telefone>();
        }
    }
}
