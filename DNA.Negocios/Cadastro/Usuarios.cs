using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using DNAMais.Framework;

namespace DNA.Negocios.Cadastro
{
    public class Usuarios
    {
        private DateTime DataBR = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

        string ChaveAcessoWSInterno = ConfigurationManager.AppSettings["ChaveAcessoWSInterno"].ToString();

        public List<Entidades.Usuario> Listar(Entidades.Usuario user)
        {
            try
            {
                Util.Cryptography cript = new Util.Cryptography(Util.EncryptionAlgorithm.TripleDes);
                string SenhaCript = "";
                //SenhaCript = Convert.ToBase64String(cript.Encrypt(Encoding.ASCII.GetBytes(user.SenhaUsuario), Util.Cryptography.Key, Util.Cryptography.Vector));

                SenhaCript = Security.Encryption(user.SenhaUsuario);

                List<Entidades.Usuario> lRetUsu = new List<Entidades.Usuario>();
                List<Entidades.PerfilAcesso> lRetPerfil = new List<Entidades.PerfilAcesso>();
                List<Entidades.Produto> lRetProduto = new List<Entidades.Produto>();

                DataTable dtUsuarios = new DataTable();
                DataTable dtPerfis = new DataTable();
                DataTable dtProdutos = new DataTable();
                DataTable dtClientes = new DataTable();

                Entidades.Usuario e = new Entidades.Usuario();

                Dados.Cadastro.Usuarios negUsu = new Dados.Cadastro.Usuarios();
                Dados.Cadastro.PerfilAcesso negPerf = new Dados.Cadastro.PerfilAcesso();
                Dados.Cadastro.Clientes negCliente = new Dados.Cadastro.Clientes();
                Dados.Cadastro.Produtos negProd = new Dados.Cadastro.Produtos();

                e.IdUsuario = user.IdUsuario.Equals("") ? 0 : user.IdUsuario;
                e.LoginUsuario = user.LoginUsuario;
                e.SenhaUsuario = SenhaCript;
                e.FlagAtivo = user.FlagAtivo;

                negUsu.Listar(e, ref dtUsuarios);

                foreach (DataRow drUsu in dtUsuarios.Rows)
                {
                    List<DNA.Entidades.PerfilAcesso> lRetPerf = new List<DNA.Entidades.PerfilAcesso>();

                    Entidades.Usuario retUsu = new Entidades.Usuario();

                    if (!drUsu["DATA_ALTERACAO"].ToString().Equals(""))
                    { retUsu.DataAlteracao = DateTime.Parse(drUsu["DATA_ALTERACAO"].ToString()); }

                    retUsu.DataInclusao = DateTime.Parse(drUsu["DATA_INCLUSAO"].ToString());
                    retUsu.Email1 = drUsu["EMAIL1"].ToString();
                    retUsu.Email2 = drUsu["EMAIL2"].ToString();
                    retUsu.FlagAtivo = drUsu["FLAG_ATIVO"].ToString();
                    retUsu.IdCliente = int.Parse(drUsu["ID_CLIENTE"].ToString());
                    retUsu.IdUsuario = int.Parse(drUsu["ID"].ToString());

                    if (!drUsu["ID_USUARIO_ALTERACAO"].ToString().Equals(""))
                    { retUsu.IdUsuarioAlteracao = int.Parse(drUsu["ID_USUARIO_ALTERACAO"].ToString()); }

                    retUsu.IdUsuarioInclusao = int.Parse(drUsu["ID_USUARIO_INCLUSAO"].ToString());
                    retUsu.IpClienteLogado = "";
                    retUsu.LoginUsuario = drUsu["LOGIN"].ToString();
                    retUsu.NomeUsuario = drUsu["NOME"].ToString();
                    retUsu.Observacao = drUsu["OBESERVACAO"].ToString();
                    retUsu.SenhaUsuario = drUsu["SENHA"].ToString();

                    #region Carrega dados Cliente Empresa

                    //dtClientes = new DataTable();
                    //Entidades.Cliente entCli = new Entidades.Cliente();
                    //entCli.IdCliente = retUsu.IdCliente == null ? 0 : (int)retUsu.IdCliente;

                    //if (entCli.IdCliente > 0)
                    //{

                    //    negCliente.Listar(entCli, ref dtClientes);

                    //    foreach (DataRow drCli in dtClientes.Rows)
                    //    {
                    //        Entidades.Cliente retCli = new Entidades.Cliente();

                    //        retCli.IdCliente = int.Parse(drCli["ID"].ToString());
                    //        retCli.NomeRazaoSocial = drCli["NOME_RAZAO_SOCIAL"].ToString();
                    //        retCli.NomeFantasia = drCli["NOME_FANTASIA"].ToString();
                    //        retCli.NumeroDocCPFCNPJ = drCli["NUM_DOC_CPF_CNPJ"].ToString();
                    //        retCli.TipoPessoa = drCli["TIPO_PESSOA"].ToString();
                    //        retCli.EnderecoLogradouro = drCli["LOGRADOURO"].ToString();
                    //        retCli.EnderecoNumero = drCli["NUMERO"].ToString();
                    //        retCli.EnderecoComplemento = drCli["COMPLEMENTO"].ToString();
                    //        retCli.EnderecoBairro = drCli["BAIRRO"].ToString();
                    //        retCli.EnderecoMunicipio = drCli["MUNICIPIO"].ToString();
                    //        retCli.EnderecoUF = drCli["UF"].ToString();
                    //        retCli.EnderecoCEP = drCli["CEP"].ToString();
                    //        retCli.DataNascimento = drCli["DATA_NASCIMENTO"].ToString();
                    //        retCli.Email1 = drCli["EMAIL1"].ToString();
                    //        retCli.Email2 = drCli["EMAIL2"].ToString();
                    //        retCli.Sexo = drCli["SEXO"].ToString();
                    //        retCli.Observacao = drCli["OBSERVACAO"].ToString();
                    //        retCli.DDDTelComercial = drCli["DDD_TEL_COMERCIAL"].ToString();
                    //        retCli.NumeroTelComercial = drCli["NUM_TEL_COMERCIAL"].ToString();
                    //        retCli.NumeroTelComercialRamal = drCli["NUM_TEL_COMERCIAL_RAMAL"].ToString();
                    //        retCli.DDDTelResidencial = drCli["DDD_TEL_RESIDENCIAL"].ToString();
                    //        retCli.NumeroTelResidencial = drCli["NUM_TEL_RESIDENCIAL"].ToString();
                    //        retCli.DDDCelular = drCli["DDD_CELULAR"].ToString();
                    //        retCli.NumeroCelular = drCli["NUM_CELULAR"].ToString();
                    //        retCli.FlagAtivo = drCli["FLAG_ATIVO"].ToString();
                    //        retCli.FlagExcluido = drCli["FLAG_EXCLUIDO"].ToString();
                    //        retCli.DataInclusaoCliente = DateTime.Parse(drCli["DATA_INCLUSAO"].ToString());
                    //        retCli.IdUsuarioInclusaoCliente = int.Parse(drCli["ID_USUARIO_INCLUSAO"].ToString());

                    //        if (!drCli["DATA_ALTERACAO"].ToString().Equals(""))
                    //        { retCli.DataAlteracaoCliente = DateTime.Parse(drCli["DATA_ALTERACAO"].ToString()); }
                    //        if (!drCli["ID_USUARIO_ALTERACAO"].ToString().Equals(""))
                    //        { retCli.IdUsuarioAlteracaoCliente = int.Parse(drCli["ID_USUARIO_ALTERACAO"].ToString()); }

                    //        if (retUsu.Cliente == null)
                    //        { retUsu.Cliente = new Entidades.Cliente(); }

                    //        retUsu.Cliente = retCli;
                    //    }

                    //}

                    #endregion

                    #region Carrega Perfil

                    //dtPerfis = new DataTable();
                    //Entidades.PerfilAcesso entPA = new Entidades.PerfilAcesso();
                    //entPA.IdUsuario = retUsu.IdUsuario;


                    //negPerf.ListarPerfilByIdUsuario(entPA, ref dtPerfis);

                    //foreach (DataRow drPerf in dtPerfis.Rows)
                    //{
                    //    Entidades.PerfilAcesso retPerf = new Entidades.PerfilAcesso();

                    //    if (!drPerf["DATA_ALTERACAO"].ToString().Equals(""))
                    //    { retPerf.DataAlteracaoPerfilAcesso = DateTime.Parse(drPerf["DATA_ALTERACAO"].ToString()); }


                    //    retPerf.DataInclusaoPerfilAcesso = DateTime.Parse(drPerf["DATA_INCLUSAO"].ToString());
                    //    retPerf.DescricaoPerfilAcesso = drPerf["DESCRICAO_PERFIL"].ToString();
                    //    retPerf.FlagAtivoPerfilAcesso = drPerf["FLAG_ATIVO"].ToString();
                    //    retPerf.IdPerfilAcesso = int.Parse(drPerf["ID"].ToString());
                    //    retPerf.IdPerfilAcessoUsuario = int.Parse(drPerf["ID_USUARIO"].ToString());

                    //    if (!drPerf["ID_USUARIO_ALTERACAO"].ToString().Equals(""))
                    //    {
                    //        retPerf.IdUsuarioAlterasaoPerfilAcesso = int.Parse(drPerf["ID_USUARIO_ALTERACAO"].ToString());
                    //        retPerf.NomeUsuarioAlteracao = drPerf["NOME_USUARIO_ALTERACAO"].ToString();
                    //    }

                    //    retPerf.IdUsuarioInclusaoPerfilAcesso = int.Parse(drPerf["ID_USUARIO_INCLUSAO"].ToString());
                    //    retPerf.NomeUsuarioInclusao = drPerf["NOME_USUARIO_INCLUSAO"].ToString();

                    //    lRetPerf.Add(retPerf);
                    //}

                    //if (retUsu.Perfil == null)
                    //{ retUsu.Perfil = new List<Entidades.PerfilAcesso>(); }

                    //retUsu.Perfil.AddRange(lRetPerf);

                    #endregion

                    #region Carrega Produto

                    //dtProdutos = new DataTable();
                    //negProd.ListarByIdUsuario(new Entidades.Usuario() { IdUsuario = retUsu.IdUsuario }, ref dtProdutos);

                    //foreach (DataRow drProd in dtProdutos.Rows)
                    //{
                    //    Entidades.Produto retProd = new Entidades.Produto();

                    //    retProd.IdProduto = int.Parse(drProd["ID_PROD"].ToString());
                    //    retProd.NomeInterno = drProd["NOME_INTERNO_PROD"].ToString();

                    //    retProd.NomeProduto = drProd["NOME_PRODUTO"].ToString();
                    //    retProd.DescricaoProduto = drProd["DESCRICAO_PROD"].ToString();
                    //    retProd.LinkImagem1 = drProd["LINK_IMAGEM_1"].ToString();
                    //    retProd.LinkImagem2 = drProd["LINK_IMAGEM_2"].ToString();
                    //    retProd.LinkImagem3 = drProd["LINK_IMAGEM_3"].ToString();
                    //    retProd.LinkNavegacaoWeb = drProd["LINK_NAVEGACAO_WEB"].ToString();
                    //    retProd.FlagProdutoWebService = drProd["FLAG_WEBSERVICE"].ToString();
                    //    retProd.FlagAtivoProduto = drProd["FLAG_ATIVO_PROD"].ToString();

                    //    if (!drProd["DATA_INC_PROD"].ToString().Equals(""))
                    //    { retProd.DataInclusaoProduto = DateTime.Parse(drProd["DATA_INC_PROD"].ToString()); }

                    //    if (!drProd["ID_USUARIO_INC_PROD"].ToString().Equals(""))
                    //    { retProd.IdUsuarioInclusaoProduto = int.Parse(drProd["ID_USUARIO_INC_PROD"].ToString()); }

                    //    if (!drProd["DATA_ALT_PROD"].ToString().Equals(""))
                    //    { retProd.DataAlteracaoProduto = DateTime.Parse(drProd["DATA_ALT_PROD"].ToString()); }

                    //    if (!drProd["ID_USUARIO_ALT_PROD"].ToString().Equals(""))
                    //    { retProd.IdUsuarioAlteracaoProduto = int.Parse(drProd["ID_USUARIO_ALT_PROD"].ToString()); }

                    //    if (!drProd["CD_ITEM_PRODUTO"].ToString().Equals(""))
                    //    { retProd.IdPrecoProduto = int.Parse(drProd["CD_ITEM_PRODUTO"].ToString()); }

                    //    if (!drProd["PRECO"].ToString().Equals(""))
                    //    { retProd.PrecoProduto = decimal.Parse(drProd["PRECO"].ToString()); }

                    //    if (!drProd["DT_INI_VIGE_PROD_PRECO"].ToString().Equals(""))
                    //    { retProd.DataInicioVigencia = DateTime.Parse(drProd["DT_INI_VIGE_PROD_PRECO"].ToString()); }

                    //    retProd.FlagAtivoPrecoProduto = drProd["FLAG_ATIVO_PROD_PRECO"].ToString();

                    //    if (!drProd["DATA_INC_PROD_PRECO"].ToString().Equals(""))
                    //    { retProd.DataInclusaoPrecoProduto = DateTime.Parse(drProd["DATA_INC_PROD_PRECO"].ToString()); }

                    //    if (!drProd["ID_USUARIO_INC_PROD_PRECO"].ToString().Equals(""))
                    //    { retProd.IdUsuarioInclusaoPrecoProduto = int.Parse(drProd["ID_USUARIO_INC_PROD_PRECO"].ToString()); }

                    //    if (!drProd["DATA_ALT_PROD_PRECO"].ToString().Equals(""))
                    //    { retProd.DataAlteracaoPrecoProduto = DateTime.Parse(drProd["DATA_ALT_PROD_PRECO"].ToString()); }

                    //    if (!drProd["ID_USUARIO_ALT_PROD_PRECO"].ToString().Equals(""))
                    //    { retProd.IdUsuarioAlteracaoPrecoProduto = int.Parse(drProd["ID_USUARIO_ALT_PROD_PRECO"].ToString()); }

                    //    if (!drProd["DESCONTO_OFERECIDO"].ToString().Equals(""))
                    //    { retProd.DescontoOferecidoPrecoProduto = Decimal.Parse(drProd["DESCONTO_OFERECIDO"].ToString()); }

                    //    if (!drProd["ID_CATEGORIA_PROD"].ToString().Equals(""))
                    //    { retProd.CategoriaProduto.IdCategoria = int.Parse(drProd["ID_CATEGORIA_PROD"].ToString()); }

                    //    retProd.CategoriaProduto.Nome = drProd["NOME_CATEGORIA_PROD"].ToString();
                    //    retProd.CategoriaProduto.Descricao = drProd["DESC_CATEGORIA_PROD"].ToString();
                    //    retProd.CategoriaProduto.FlagAtivo = drProd["FLAG_ATIVO_CATEGORIA_PROD"].ToString();

                    //    if (!drProd["DATA_INC_CATEGORIA_PROD"].ToString().Equals(""))
                    //    { retProd.CategoriaProduto.DataInclusao = DateTime.Parse(drProd["DATA_INC_CATEGORIA_PROD"].ToString()); }

                    //    if (!drProd["ID_USUARIO_INC_CATEGORIA_PROD"].ToString().Equals(""))
                    //    { retProd.CategoriaProduto.IdUsuarioInclusao = int.Parse(drProd["ID_USUARIO_INC_CATEGORIA_PROD"].ToString()); }

                    //    if (!drProd["DATA_ALT_CATEGORIA_PROD"].ToString().Equals(""))
                    //    { retProd.CategoriaProduto.DataAlteracao = DateTime.Parse(drProd["DATA_ALT_CATEGORIA_PROD"].ToString()); }

                    //    if (!drProd["ID_USUARIO_ALT_CATEGORIA_PROD"].ToString().Equals(""))
                    //    { retProd.CategoriaProduto.IdUsuarioAlteracao = int.Parse(drProd["ID_USUARIO_ALT_CATEGORIA_PROD"].ToString()); }

                    //    lRetProduto.Add(retProd);
                    //}

                    //if (retUsu.Produtos == null)
                    //{ retUsu.Produtos = new List<Entidades.Produto>(); }

                    //retUsu.Produtos.AddRange(lRetProduto);

                    #endregion

                    lRetUsu.Add(retUsu);

                }

                return lRetUsu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AlterarSenha(int idUsuarioAlteracao, Entidades.Usuario user)
        {
            try
            {
                Dados.Cadastro.Usuarios negUsu = new Dados.Cadastro.Usuarios();

                negUsu.AlterarSenha(idUsuarioAlteracao, user);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
