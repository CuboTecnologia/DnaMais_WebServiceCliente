using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.IO;
using System.Web.UI;

namespace DNA.Web.Sistema.Produto.FTP
{
    /// <summary>
    /// Summary description for GerenciamentoArquivos
    /// </summary>
    public class GerenciamentoArquivos : IHttpHandler, IRequiresSessionState
    {
        Entidades.Usuario usuarioLogado = new Entidades.Usuario();
        DateTime DataBR = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

        //string codigoItemProduto = string.Empty;
        int contaQtdeArquivosComMesmoNome = 0;
        string nomeOriginalArquivo = "";
        string diretorioLog = "../../../";

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Expires = -1;

            try
            {
                HttpFileCollection fileCollection = context.Request.Files;

                if (fileCollection != null)
                {
                    //Remover
                    //context.Session["UsuarioLogado"] = new Entidades.Usuario() { IdUsuario = 1, Cliente = new Entidades.Cliente() { NomeFantasia = "DNA CONSULTORIA LÁLA" } }; 
                    //context.Session["codigoItemProdutoAcessoWEB"] = 3;

                    if (context.Session["UsuarioLogado"] == null)
                    {
                        throw new Exception("SESSAO EXPIRADA");
                    }
                    else
                    {
                        usuarioLogado = (Entidades.Usuario)context.Session["UsuarioLogado"];
                        //codigoItemProduto = int.Parse(context.Session["codigoItemProdutoAcessoWEB"].ToString());

                        string nomeFantasia = usuarioLogado.Cliente.NomeFantasia.Replace(" ", "");
                        byte[] bytesNovoNomeFantasia = System.Text.Encoding.GetEncoding("iso-8859-8").GetBytes(nomeFantasia);
                        nomeFantasia = System.Text.Encoding.UTF8.GetString(bytesNovoNomeFantasia);

                        //string savepath = "";
                        //string tempPath = System.Configuration.ConfigurationManager.AppSettings["DiretorioUploadFTP"];
                        string mapPath = HttpContext.Current.Server.MapPath("~");
                        string CaminhoDiretorioArquivosDNAFTP = mapPath + "_DNAFTP\\UPLOAD\\" + nomeFantasia;

                        //savepath = context.Server.MapPath(tempPath);

                        for (int i = 0; i < fileCollection.Count; i++)
                        {
                            string NomeArquivo = fileCollection[i].FileName;

                            if (NomeArquivo.Length > 100)
                            { NomeArquivo = NomeArquivo.Substring(0, 100) + Path.GetExtension(fileCollection[i].FileName); }

                            System.Text.Encoding EncodDestino = System.Text.Encoding.Default;
                            System.Text.Encoding EncodOrigem = System.Text.Encoding.UTF8;
                            byte[] origemBytes = EncodOrigem.GetBytes(NomeArquivo);
                            byte[] destinoBytes = System.Text.Encoding.Convert(EncodOrigem, EncodDestino, origemBytes);
                            string nomeArquivoSemAcento = EncodOrigem.GetString(destinoBytes);

                            string extensaoArquivo = Path.GetExtension(nomeArquivoSemAcento);
                            if (extensaoArquivo.Trim().ToLower().Equals(".txt") || extensaoArquivo.Trim().ToLower().Equals(".xls") ||
                                extensaoArquivo.Trim().ToLower().Equals(".xlsx") || extensaoArquivo.Trim().ToLower().Equals(".ace") ||
                                extensaoArquivo.Trim().ToLower().Equals(".arc") || extensaoArquivo.Trim().ToLower().Equals(".arj") ||
                                extensaoArquivo.Trim().ToLower().Equals(".zip") || extensaoArquivo.Trim().ToLower().Equals(".rar") ||
                                extensaoArquivo.Trim().ToLower().Equals(".tar") || extensaoArquivo.Trim().ToLower().Equals(".7zip") ||
                                extensaoArquivo.Trim().ToLower().Equals(".gzip") || extensaoArquivo.Trim().ToLower().Equals(".bzip2") ||
                                extensaoArquivo.Trim().ToLower().Equals(".7Z") || extensaoArquivo.Trim().ToLower().Equals(".csv"))
                            {
                                if (fileCollection[i].ContentLength <= 200000000)
                                {
                                    if (!System.IO.Directory.Exists(CaminhoDiretorioArquivosDNAFTP))
                                    { System.IO.Directory.CreateDirectory(CaminhoDiretorioArquivosDNAFTP); }

                                    string novoNomeArquivoSemAcento = "";
                                    novoNomeArquivoSemAcento = VerificaExistenciaNovoArquivo(nomeArquivoSemAcento, CaminhoDiretorioArquivosDNAFTP);
                                    
                                    fileCollection[i].SaveAs(CaminhoDiretorioArquivosDNAFTP + "\\" + novoNomeArquivoSemAcento);

                                    context.Response.Write("");
                                    context.Response.StatusCode = 200;
                                }
                                else
                                {
                                    context.Response.Write("ARQUIVO COM MAIS DE 200MB");
                                    context.Response.StatusCode = 200;
                                }
                            }
                            else
                            {
                                context.Response.Write("ARQUIVO INVALIDO");
                                context.Response.StatusCode = 200;
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToString().Equals("SESSAO EXPIRADA"))
                { 
                    context.Response.Write("159ERROR753: SESSÃO EXPIRADA. FAÇA O LOGIN NOVAMENTE."); 
                }
                else
                {
                    context.Response.Write("159ERROR753: ERRO INTERNO. FALE COM O ADMIN. DO SISTEMA.");
                }

                context.Response.StatusCode = 200;
                Util.Log.Save("ex:" + ex.Message, "ProcessRequest", "GerenciamentoArquivos", HttpContext.Current.Server.MapPath(diretorioLog));
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private string VerificaExistenciaNovoArquivo(string NomeArquivoSemAcento, string CaminhoDiretorioArquivosDNAFTP)
        {
            try
            {
                string NovoNomeArquivoSemAcento = "";

                //Verifica se o arquivo ja existe
                DirectoryInfo wDI = new DirectoryInfo(CaminhoDiretorioArquivosDNAFTP);

                if (!wDI.Exists)
                { wDI.Create(); }

                FileInfo[] rgFiles = wDI.GetFiles("*.*");

                int contArquivosIguais = 0;
                foreach (FileInfo fi in rgFiles)
                {
                    if (fi.Name.ToUpper().Equals(NomeArquivoSemAcento.ToUpper()))
                    { contArquivosIguais++; }
                }

                if (contArquivosIguais > 0)
                {
                    string ExtensaoNovoArquivo = NomeArquivoSemAcento.Substring(NomeArquivoSemAcento.ToString().LastIndexOf(".") + 1, NomeArquivoSemAcento.Length - NomeArquivoSemAcento.ToString().LastIndexOf(".") - 1);
                    NomeArquivoSemAcento = NomeArquivoSemAcento.Replace(("." + ExtensaoNovoArquivo), "");

                    if (contaQtdeArquivosComMesmoNome > 0)
                    {
                        string m = "";
                        m = NomeArquivoSemAcento.Substring(0, NomeArquivoSemAcento.ToString().LastIndexOf(")") - 2);

                        if (!nomeOriginalArquivo.Equals(m + "." + ExtensaoNovoArquivo))
                        { VerificaExistenciaNovoArquivo(m + "." + ExtensaoNovoArquivo, CaminhoDiretorioArquivosDNAFTP); }

                        NovoNomeArquivoSemAcento = m + "(" + (contaQtdeArquivosComMesmoNome + 1) + ")" + "." + ExtensaoNovoArquivo;
                    }
                    else
                    {
                        NovoNomeArquivoSemAcento = NomeArquivoSemAcento + "(" + contArquivosIguais + ")" + "." + ExtensaoNovoArquivo;
                        NomeArquivoSemAcento = NomeArquivoSemAcento + "." + ExtensaoNovoArquivo;
                    }
                }
                else
                {
                    return NomeArquivoSemAcento;
                }

                contaQtdeArquivosComMesmoNome++;

                if (!NovoNomeArquivoSemAcento.Equals(NomeArquivoSemAcento))
                { NomeArquivoSemAcento = VerificaExistenciaNovoArquivo(NovoNomeArquivoSemAcento, CaminhoDiretorioArquivosDNAFTP); }

                return NomeArquivoSemAcento;
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "VerificaExistenciaNovoArquivo", "GerenciamentoArquivos", HttpContext.Current.Server.MapPath(diretorioLog));
                throw;
            }
        }

    }
}