using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DNA.Negocios
{
    public class Fornecedor
    {
        DateTime DataBR = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

        public List<Entidades.FornecedorConsulta> Listar(Entidades.FornecedorConsulta fornec)
        {
            try
            {
                List<Entidades.FornecedorConsulta> listRet = new List<Entidades.FornecedorConsulta>();
                Dados.Fornecedor negFornec = new Dados.Fornecedor();

                DataTable dtRetorno = new DataTable();

                negFornec.Listar(fornec, ref dtRetorno);

                foreach (DataRow drFornec in dtRetorno.Rows)
                {
                    Entidades.FornecedorConsulta retFornec = new Entidades.FornecedorConsulta();

                    retFornec.IdFornecedor = int.Parse(drFornec["ID_FORNECEDOR"].ToString());
                    retFornec.RazaoSocial = drFornec["RAZAO_SOCIAL"].ToString();
                    retFornec.NomeFantasia = drFornec["NOME_FANTASIA"].ToString();
                    retFornec.DocumentoCnpjCpf = drFornec["NUM_DOC_CNPJ_CPF"].ToString();
                    retFornec.NumeroInscricaoEstadualRG = drFornec["NUM_INSC_ESTADUAL_RG"].ToString();
                    retFornec.NomeContato = drFornec["NOME_CONTATO"].ToString();
                    retFornec.EmailContato1 = drFornec["EMAIL1_CONTATO"].ToString();
                    retFornec.EmailContato2 = drFornec["EMAIL2_CONTATO"].ToString();
                    retFornec.TelefoneContato1 = drFornec["TEL1_CONTATO"].ToString();
                    retFornec.TelefoneContato2 = drFornec["TEL2_CONTATO"].ToString();
                    retFornec.FaxContato = drFornec["FAX_CONTATO"].ToString();
                    retFornec.Logradouro = drFornec["LOGRADOURO"].ToString();
                    retFornec.NumeroEndereco = drFornec["NUMERO"].ToString();
                    retFornec.ComplementoEndereco = drFornec["COMPLEMENTO"].ToString();
                    retFornec.Bairro = drFornec["BAIRRO"].ToString();
                    retFornec.Municipio = drFornec["MUNICIPIO"].ToString();
                    retFornec.UF = drFornec["UF"].ToString();
                    retFornec.CEP = drFornec["CEP"].ToString();
                    retFornec.FlagPF = drFornec["FLAG_PF"].ToString();
                    retFornec.FlagPJ = drFornec["FLAG_PJ"].ToString();
                    retFornec.FlagOrgaoPublico = drFornec["FLAG_ORGAO_PUBLICO"].ToString();
                    retFornec.FlagAtivo = drFornec["FLAG_ATIVO"].ToString();

                    if (!drFornec["DATA_INCLUSAO"].ToString().Equals(""))
                    { retFornec.DataInclusao = DateTime.Parse(drFornec["DATA_INCLUSAO"].ToString()); }

                    if (!drFornec["ID_USUARIO_INCLUSAO"].ToString().Equals(""))
                    { retFornec.IdUsuarioInclusao = int.Parse(drFornec["ID_USUARIO_INCLUSAO"].ToString()); }

                    if (!drFornec["DATA_ALTERACAO"].ToString().Equals(""))
                    { retFornec.DataAlteracao = DateTime.Parse(drFornec["DATA_ALTERACAO"].ToString()); }

                    if (!drFornec["ID_USUARIO_ALTERACAO"].ToString().Equals(""))
                    { retFornec.IdUsuarioAlteracao = int.Parse(drFornec["ID_USUARIO_ALTERACAO"].ToString()); }
                    
                    if (retFornec.Produtos == null)
                    { retFornec.Produtos = new List<Entidades.OrigemProdutoConsultado>(); }
                    retFornec.Produtos.AddRange(Complementa_MetodoListar(retFornec));

                    listRet.Add(retFornec);
                }

                return listRet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Entidades.OrigemProdutoConsultado> ListarOrigemProdutoFornecedor(Entidades.FornecedorConsulta fornec)
        {
            try
            {
                Entidades.FornecedorConsulta retFornec = new Entidades.FornecedorConsulta();

                List<Entidades.OrigemProdutoConsultado> listRetorno = new List<Entidades.OrigemProdutoConsultado>();
                Dados.Fornecedor negFornec = new Dados.Fornecedor();

                DataTable dtRetorno = new DataTable();

                negFornec.ListarOrigemProdutoFornecedor(fornec, ref dtRetorno);

                foreach (DataRow drFornec in dtRetorno.Rows)
                {
                    Entidades.OrigemProdutoConsultado retOri = new Entidades.OrigemProdutoConsultado();

                    retOri.IdOrigemProdutoConsultado = int.Parse(drFornec["ID"].ToString());
                    retOri.NomeProduto = drFornec["NOME_PRODUTO"].ToString();
                    retOri.Observacao = drFornec["OBSERVACAO"].ToString();

                    if (!drFornec["DATA_INCLUSAO"].ToString().Equals(""))
                    { retOri.DataInclusao = DateTime.Parse(drFornec["DATA_INCLUSAO"].ToString()); }

                    if (!drFornec["ID_USUARIO_INCLUSAO"].ToString().Equals(""))
                    { retOri.IdUsuarioInclusao = int.Parse(drFornec["ID_USUARIO_INCLUSAO"].ToString()); }

                    if (!drFornec["DATA_ALTERACAO"].ToString().Equals(""))
                    { retOri.DataAltercao = DateTime.Parse(drFornec["DATA_ALTERACAO"].ToString()); }

                    if (!drFornec["ID_USUARIO_ALTERACAO"].ToString().Equals(""))
                    { retOri.IdUsuarioAlteracao = int.Parse(drFornec["ID_USUARIO_ALTERACAO"].ToString()); }

                    if (retOri.FornecedorConsultaVeicular == null)
                    { retOri.FornecedorConsultaVeicular = new Entidades.FornecedorConsulta(); }

                    retFornec = ComplementaMetodo_ListarOrigemProdutoFornecedor(fornec).FirstOrDefault();
                    retOri.FornecedorConsultaVeicular = retFornec;

                    listRetorno.Add(retOri);
                }

                return listRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Entidades.OrigemProdutoConsultado> Complementa_MetodoListar(Entidades.FornecedorConsulta fornec)
        {
            try
            {
                Entidades.FornecedorConsulta retFornec = new Entidades.FornecedorConsulta();

                List<Entidades.OrigemProdutoConsultado> listRetorno = new List<Entidades.OrigemProdutoConsultado>();
                Dados.Fornecedor negFornec = new Dados.Fornecedor();

                DataTable dtRetorno = new DataTable();

                negFornec.ListarOrigemProdutoFornecedor(fornec, ref dtRetorno);

                foreach (DataRow drFornec in dtRetorno.Rows)
                {
                    Entidades.OrigemProdutoConsultado retOri = new Entidades.OrigemProdutoConsultado();

                    retOri.IdOrigemProdutoConsultado = int.Parse(drFornec["ID"].ToString());
                    retOri.NomeProduto = drFornec["NOME_PRODUTO"].ToString();
                    retOri.Observacao = drFornec["OBSERVACAO"].ToString();

                    if (!drFornec["DATA_INCLUSAO"].ToString().Equals(""))
                    { retOri.DataInclusao = DateTime.Parse(drFornec["DATA_INCLUSAO"].ToString()); }

                    if (!drFornec["ID_USUARIO_INCLUSAO"].ToString().Equals(""))
                    { retOri.IdUsuarioInclusao = int.Parse(drFornec["ID_USUARIO_INCLUSAO"].ToString()); }

                    if (!drFornec["DATA_ALTERACAO"].ToString().Equals(""))
                    { retOri.DataAltercao = DateTime.Parse(drFornec["DATA_ALTERACAO"].ToString()); }

                    if (!drFornec["ID_USUARIO_ALTERACAO"].ToString().Equals(""))
                    { retOri.IdUsuarioAlteracao = int.Parse(drFornec["ID_USUARIO_ALTERACAO"].ToString()); }

                    if (retOri.FornecedorConsultaVeicular == null)
                    { retOri.FornecedorConsultaVeicular = new Entidades.FornecedorConsulta(); }

                    listRetorno.Add(retOri);
                }

                return listRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Entidades.FornecedorConsulta> ComplementaMetodo_ListarOrigemProdutoFornecedor(Entidades.FornecedorConsulta fornec)
        {
            try
            {
                List<Entidades.FornecedorConsulta> listRet = new List<Entidades.FornecedorConsulta>();
                Dados.Fornecedor negFornec = new Dados.Fornecedor();

                DataTable dtRetorno = new DataTable();

                negFornec.Listar(fornec, ref dtRetorno);

                foreach (DataRow drFornec in dtRetorno.Rows)
                {
                    Entidades.FornecedorConsulta retFornec = new Entidades.FornecedorConsulta();

                    retFornec.IdFornecedor = int.Parse(drFornec["ID_FORNECEDOR"].ToString());
                    retFornec.RazaoSocial = drFornec["RAZAO_SOCIAL"].ToString();
                    retFornec.NomeFantasia = drFornec["NOME_FANTASIA"].ToString();
                    retFornec.DocumentoCnpjCpf = drFornec["NUM_DOC_CNPJ_CPF"].ToString();
                    retFornec.NumeroInscricaoEstadualRG = drFornec["NUM_INSC_ESTADUAL_RG"].ToString();
                    retFornec.NomeContato = drFornec["NOME_CONTATO"].ToString();
                    retFornec.EmailContato1 = drFornec["EMAIL1_CONTATO"].ToString();
                    retFornec.EmailContato2 = drFornec["EMAIL2_CONTATO"].ToString();
                    retFornec.TelefoneContato1 = drFornec["TEL1_CONTATO"].ToString();
                    retFornec.TelefoneContato2 = drFornec["TEL2_CONTATO"].ToString();
                    retFornec.FaxContato = drFornec["FAX_CONTATO"].ToString();
                    retFornec.Logradouro = drFornec["LOGRADOURO"].ToString();
                    retFornec.NumeroEndereco = drFornec["NUMERO"].ToString();
                    retFornec.ComplementoEndereco = drFornec["COMPLEMENTO"].ToString();
                    retFornec.Bairro = drFornec["BAIRRO"].ToString();
                    retFornec.Municipio = drFornec["MUNICIPIO"].ToString();
                    retFornec.UF = drFornec["UF"].ToString();
                    retFornec.CEP = drFornec["CEP"].ToString();
                    retFornec.FlagPF = drFornec["FLAG_PF"].ToString();
                    retFornec.FlagPJ = drFornec["FLAG_PJ"].ToString();
                    retFornec.FlagOrgaoPublico = drFornec["FLAG_ORGAO_PUBLICO"].ToString();
                    retFornec.FlagAtivo = drFornec["FLAG_ATIVO"].ToString();

                    if (!drFornec["DATA_INCLUSAO"].ToString().Equals(""))
                    { retFornec.DataInclusao = DateTime.Parse(drFornec["DATA_INCLUSAO"].ToString()); }

                    if (!drFornec["ID_USUARIO_INCLUSAO"].ToString().Equals(""))
                    { retFornec.IdUsuarioInclusao = int.Parse(drFornec["ID_USUARIO_INCLUSAO"].ToString()); }

                    if (!drFornec["DATA_ALTERACAO"].ToString().Equals(""))
                    { retFornec.DataAlteracao = DateTime.Parse(drFornec["DATA_ALTERACAO"].ToString()); }

                    if (!drFornec["ID_USUARIO_ALTERACAO"].ToString().Equals(""))
                    { retFornec.IdUsuarioAlteracao = int.Parse(drFornec["ID_USUARIO_ALTERACAO"].ToString()); }

                    listRet.Add(retFornec);
                }

                return listRet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
