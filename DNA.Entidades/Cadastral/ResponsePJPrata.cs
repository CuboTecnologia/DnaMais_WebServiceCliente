using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Cadastral
{
    public class ResponsePJPrata
    {
        public Entidades.Cadastral.Controle Controle { get; set; }
        public Entidades.Cadastral.DadosCadastraisPJ DadosCadastrais { get; set; }
        public List<Telefone> Telefones { get; set; }
        public List<Endereco> Enderecos { get; set; }
        public List<CNAE> CNAE { get; set; }
        public List<QSA> QSA { get; set; }
        
        public Entidades.Cadastral.ResponseStatus ResponseStatus { get; set; }

        public ResponsePJPrata()
        {
            this.Controle = new Entidades.Cadastral.Controle();
            this.DadosCadastrais = new Entidades.Cadastral.DadosCadastraisPJ();
            this.Enderecos = new List<Endereco>();
            this.Telefones = new List<Telefone>();
            this.CNAE = new List<CNAE>();
            this.QSA = new List<QSA>();
            this.ResponseStatus = new ResponseStatus();
        }
    }
}
