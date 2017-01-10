using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;

namespace DNA.Negocios.Cadastro
{
    public class Clientes
    {
        private DateTime DataBR = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

        public List<Entidades.Cliente> Listar(Entidades.Cliente cli)
        {
            List<Entidades.Cliente> lRet = new List<Entidades.Cliente>();
            Dados.Cadastro.Clientes negCli = new Dados.Cadastro.Clientes();

            DataTable dtClientes = new DataTable();

            try
            {
                negCli.Listar(cli, ref dtClientes);

                foreach (DataRow drCli in dtClientes.Rows)
                {
                    Entidades.Cliente retCli = new Entidades.Cliente();

                    retCli.IdCliente = int.Parse(drCli["ID"].ToString());
                    retCli.NomeRazaoSocial = drCli["NOME_RAZAO_SOCIAL"].ToString();
                    retCli.NomeFantasia = drCli["NOME_FANTASIA"].ToString();
                    retCli.NumeroDocCPFCNPJ = drCli["NUM_DOC_CPF_CNPJ"].ToString();
                    retCli.TipoPessoa = drCli["TIPO_PESSOA"].ToString();
                    retCli.EnderecoLogradouro = drCli["LOGRADOURO"].ToString();
                    retCli.EnderecoNumero = drCli["NUMERO"].ToString();
                    retCli.EnderecoComplemento = drCli["COMPLEMENTO"].ToString();
                    retCli.EnderecoBairro = drCli["BAIRRO"].ToString();
                    retCli.EnderecoMunicipio = drCli["MUNICIPIO"].ToString();
                    retCli.EnderecoUF = drCli["UF"].ToString();
                    retCli.EnderecoCEP = drCli["CEP"].ToString();
                    retCli.DataNascimento = drCli["DATA_NASCIMENTO"].ToString();
                    retCli.Email1 = drCli["EMAIL1"].ToString();
                    retCli.Email2 = drCli["EMAIL2"].ToString();
                    retCli.Sexo = drCli["SEXO"].ToString();
                    retCli.Observacao = drCli["OBSERVACAO"].ToString();
                    retCli.DDDTelComercial = drCli["DDD_TEL_COMERCIAL"].ToString();
                    retCli.NumeroTelComercial = drCli["NUM_TEL_COMERCIAL"].ToString();
                    retCli.NumeroTelComercialRamal = drCli["NUM_TEL_COMERCIAL_RAMAL"].ToString();
                    retCli.DDDTelResidencial = drCli["DDD_TEL_RESIDENCIAL"].ToString();
                    retCli.NumeroTelResidencial = drCli["NUM_TEL_RESIDENCIAL"].ToString();
                    retCli.DDDCelular = drCli["DDD_CELULAR"].ToString();
                    retCli.NumeroCelular = drCli["NUM_CELULAR"].ToString();
                    retCli.FlagAtivo = drCli["FLAG_ATIVO"].ToString();
                    retCli.FlagExcluido = drCli["FLAG_EXCLUIDO"].ToString();
                    retCli.DataInclusaoCliente = DateTime.Parse(drCli["DATA_INCLUSAO"].ToString());
                    retCli.IdUsuarioInclusaoCliente = int.Parse(drCli["ID_USUARIO_INCLUSAO"].ToString());

                    if (!drCli["DATA_ALTERACAO"].ToString().Equals(""))
                    { retCli.DataAlteracaoCliente = DateTime.Parse(drCli["DATA_ALTERACAO"].ToString()); }
                    if (!drCli["ID_USUARIO_ALTERACAO"].ToString().Equals(""))
                    { retCli.IdUsuarioAlteracaoCliente = int.Parse(drCli["ID_USUARIO_ALTERACAO"].ToString()); }

                }

                return lRet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
