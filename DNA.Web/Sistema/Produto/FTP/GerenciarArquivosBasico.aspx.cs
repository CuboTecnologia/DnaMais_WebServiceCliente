using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace DNA.Web.Sistema.Produto.FTP
{
    public partial class GerenciarArquivosBasico : System.Web.UI.Page
    {
        Entidades.Usuario usuarioLogado = new Entidades.Usuario();
        DateTime DataBR = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

        int idProdutoPreco = 0;
        int contaQtdeArquivosComMesmoNome = 0;
        string nomeOriginalArquivo = "";
        string diretorioLog = "../../../";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Remover
                //Session["UsuarioLogado"] = new Entidades.Usuario() { IdUsuario = 1, Cliente = new Entidades.Cliente() { NomeFantasia = "DNA CONSULTORIA LÁLA" } };
                //Session["idProdutoPrecoAcessoWEB"] = 3;

                if (Session["UsuarioLogado"] == null)
                { Response.Redirect("../../Home.aspx", false); return; }

                usuarioLogado = (Entidades.Usuario)Session["UsuarioLogado"];
                idProdutoPreco = int.Parse(Session["idProdutoPrecoAcessoWEB"].ToString());

                this.Page.Title = "DNA+ - FTP - Gerenciamento de Arquivos";

                if (!Page.IsPostBack)
                {
                    System.Web.HttpBrowserCapabilities validaBrowser = Request.Browser;
                    if (Request.UserAgent.ToUpper().Contains("CHROME") ||
                        Request.UserAgent.ToUpper().Contains("FIREFOX") ||
                        Request.UserAgent.ToUpper().Contains("SAFARI") ||
                        (validaBrowser.Browser == "IE" && validaBrowser.MajorVersion >= 9))
                    {
                        Response.Redirect("GerenciarArquivos.aspx", false);
                        return;
                    }

                    usuarioLogado = (Entidades.Usuario)Session["UsuarioLogado"];
                    idProdutoPreco = int.Parse(Session["idProdutoPrecoAcessoWEB"].ToString());

                    ListarArquivosEnviados();
                    ListarArquivosProcessados();
                }
            }
            catch (Exception ex)
            {

                Util.Log.Save("ex:" + ex.Message, "Page_Load", "GerenciarArquivosBasico", HttpContext.Current.Server.MapPath(diretorioLog));
            }
        }

        protected void btnEnviarArquivo_Click(object sender, EventArgs e)
        {
            Response.ContentType = "text/plain";
            Response.Expires = -1;

            try
            {
                HttpFileCollection fileCollection = Request.Files;

                if (fileCollection != null)
                {
                    //Remover
                    Session["UsuarioLogado"] = new Entidades.Usuario() { IdUsuario = 1, Cliente = new Entidades.Cliente() { NomeFantasia = "DNA CONSULTORIA LÁLA" } };
                    Session["idProdutoPrecoAcessoWEB"] = 3;


                    if (Session["UsuarioLogado"] == null)
                    {
                        throw new Exception("SESSAO EXPIRADA");
                    }
                    else
                    {
                        usuarioLogado = (Entidades.Usuario)Session["UsuarioLogado"];
                        idProdutoPreco = int.Parse(Session["idProdutoPrecoAcessoWEB"].ToString());

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

                                    //Response.Write("");
                                    //Response.StatusCode = 200;
                                }
                                else
                                {
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "<script>alert('ARQUIVO COM MAIS DE 200MB')</script>", false);
                                    
                                }
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "<script>alert('ARQUIVO INVALIDO')</script>", false);
                            }

                        }
                    }
                }

                ListarArquivosEnviados();
            }
            catch (Exception ex)
            {
                Response.StatusCode = 200;
                Util.Log.Save("ex:" + ex.Message, "ProcessRequest", "GerenciarArquivosBasico", HttpContext.Current.Server.MapPath(diretorioLog));
            }
        }

        protected void btnAtualizarListaArqEnviados_Click(object sender, EventArgs e)
        {
            try
            {
                ListarArquivosEnviados();
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "btnAtualizarListaArqEnviados_Click", "GerenciarArquivosBasico", HttpContext.Current.Server.MapPath(diretorioLog));
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
                Util.Log.Save("ex:" + ex.Message, "VerificaExistenciaNovoArquivo", "GerenciarArquivosBasico", HttpContext.Current.Server.MapPath(diretorioLog));
                throw;
            }
        }

        protected void ddlListarArquivosUploadPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListarArquivosEnviados();
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "ddlListarArquivosUploadPeriodo_SelectedIndexChanged", "GerenciarArquivosBasico", HttpContext.Current.Server.MapPath(diretorioLog));
                throw ex;
            }
        }

        protected void gridResultUpload_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ((System.Web.UI.WebControls.Button)e.Row.FindControl("btnExcluirArquivoUpload")).CommandArgument = e.Row.Cells[0].Text.Trim();
                    ((System.Web.UI.WebControls.Button)e.Row.FindControl("btnDownloadArquivoUpload")).CommandArgument = e.Row.Cells[0].Text.Trim();
                }
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "gridResultUpload_RowDataBound", "GerenciarArquivosBasico", HttpContext.Current.Server.MapPath(diretorioLog));
            }
        }

        protected void btnExcluirArquivoUpload_Click(object sender, EventArgs e)
        {
            try
            {
                string nomeArquivo = ((Button)sender).CommandArgument;
                nomeArquivo = Server.HtmlDecode(nomeArquivo);

                string nomeFantasia = usuarioLogado.Cliente.NomeFantasia.Replace(" ", "");
                byte[] bytesNovoNomeFantasia = System.Text.Encoding.GetEncoding("iso-8859-8").GetBytes(nomeFantasia);
                nomeFantasia = System.Text.Encoding.UTF8.GetString(bytesNovoNomeFantasia);

                string mapPath = HttpContext.Current.Server.MapPath("~");
                string CaminhoDiretorioArquivosDNAFTP = mapPath + "_DNAFTP\\UPLOAD\\" + nomeFantasia + "\\" + nomeArquivo;

                if (System.IO.File.Exists(CaminhoDiretorioArquivosDNAFTP))
                {
                    System.IO.File.Delete(CaminhoDiretorioArquivosDNAFTP);
                }

                ListarArquivosEnviados();
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "btnExcluirArquivoUpload_Click", "GerenciarArquivosBasico", HttpContext.Current.Server.MapPath(diretorioLog));
            }
        }

        protected void btnDownloadArquivoUpload_Click(object sender, EventArgs e)
        {
            try
            {
                string nomeArquivo = ((Button)sender).CommandArgument;
                nomeArquivo = Server.HtmlDecode(nomeArquivo);

                string nomeFantasia = usuarioLogado.Cliente.NomeFantasia.Replace(" ", "");
                byte[] bytesNovoNomeFantasia = System.Text.Encoding.GetEncoding("iso-8859-8").GetBytes(nomeFantasia);
                nomeFantasia = System.Text.Encoding.UTF8.GetString(bytesNovoNomeFantasia);

                string mapPath = HttpContext.Current.Server.MapPath("~");
                string CaminhoDiretorioArquivosDNAFTP = mapPath + "_DNAFTP\\UPLOAD\\" + nomeFantasia;

                DirectoryInfo wDI = new DirectoryInfo(CaminhoDiretorioArquivosDNAFTP);
                FileInfo[] rgFiles = wDI.GetFiles("*.*");
                foreach (FileInfo fi in rgFiles)
                {
                    if (fi.Name.ToUpper().Trim().Equals(nomeArquivo.ToUpper()))
                    {
                        Response.Clear();
                        Response.ClearHeaders();
                        Response.ClearContent();
                        Response.ContentType = "application/" + fi.Extension;
                        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + nomeArquivo + "\"");
                        Response.TransmitFile(CaminhoDiretorioArquivosDNAFTP + "\\" + nomeArquivo);
                        Response.End();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "btnDownloadArquivoUpload_Click", "GerenciarArquivosBasico", HttpContext.Current.Server.MapPath(diretorioLog));
            }
        }

        protected void btnAtualizarListaArqProcessados_Click(object sender, EventArgs e)
        {
            try
            {
                ListarArquivosProcessados();
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "btnAtualizarListaArqProcessados_Click", "GerenciarArquivosBasico", HttpContext.Current.Server.MapPath(diretorioLog));
            }

        }

        protected void ddlListarArquivosProcessadosPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListarArquivosProcessados();
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "ddlListarArquivosProcessadosPeriodo_SelectedIndexChanged", "GerenciarArquivosBasico", HttpContext.Current.Server.MapPath(diretorioLog));
                throw ex;
            }
        }

        protected void gridResultProcessados_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ((System.Web.UI.WebControls.Button)e.Row.FindControl("btnExcluirArquivoProcessado")).CommandArgument = e.Row.Cells[0].Text.Trim();
                    ((System.Web.UI.WebControls.Button)e.Row.FindControl("btnDownloadArquivoProcessado")).CommandArgument = e.Row.Cells[0].Text.Trim();
                }
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "gridResultProcessados_RowDataBound", "GerenciarArquivosBasico", HttpContext.Current.Server.MapPath(diretorioLog));
            }
        }

        protected void gridResultProcessados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnExcluirArquivoProcessado_Click(object sender, EventArgs e)
        {
            try
            {
                string nomeArquivo = ((Button)sender).CommandArgument;
                nomeArquivo = Server.HtmlDecode(nomeArquivo);

                string nomeFantasia = usuarioLogado.Cliente.NomeFantasia.Replace(" ", "");
                byte[] bytesNovoNomeFantasia = System.Text.Encoding.GetEncoding("iso-8859-8").GetBytes(nomeFantasia);
                nomeFantasia = System.Text.Encoding.UTF8.GetString(bytesNovoNomeFantasia);

                string mapPath = HttpContext.Current.Server.MapPath("~");
                string CaminhoDiretorioArquivosDNAFTP = mapPath + "_DNAFTP\\ARQUIVOS_PROCESSADOS\\" + nomeFantasia + "\\" + nomeArquivo;

                if (System.IO.File.Exists(CaminhoDiretorioArquivosDNAFTP))
                {
                    System.IO.File.Delete(CaminhoDiretorioArquivosDNAFTP);
                }

                ListarArquivosProcessados();
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "btnExcluirArquivoProcessado_Click", "GerenciarArquivosBasico", HttpContext.Current.Server.MapPath(diretorioLog));
            }
        }

        protected void btnDownloadArquivoProcessado_Click(object sender, EventArgs e)
        {
            try
            {
                string nomeArquivo = ((Button)sender).CommandArgument;
                nomeArquivo = Server.HtmlDecode(nomeArquivo);

                string nomeFantasia = usuarioLogado.Cliente.NomeFantasia.Replace(" ", "");
                byte[] bytesNovoNomeFantasia = System.Text.Encoding.GetEncoding("iso-8859-8").GetBytes(nomeFantasia);
                nomeFantasia = System.Text.Encoding.UTF8.GetString(bytesNovoNomeFantasia);

                string mapPath = HttpContext.Current.Server.MapPath("~");
                string CaminhoDiretorioArquivosDNAFTP = mapPath + "_DNAFTP\\ARQUIVOS_PROCESSADOS\\" + nomeFantasia;

                DirectoryInfo wDI = new DirectoryInfo(CaminhoDiretorioArquivosDNAFTP);
                FileInfo[] rgFiles = wDI.GetFiles("*.*");
                foreach (FileInfo fi in rgFiles)
                {
                    if (fi.Name.ToUpper().Trim().Equals(nomeArquivo.ToUpper()))
                    {
                        Response.Clear();
                        Response.ClearHeaders();
                        Response.ClearContent();
                        Response.ContentType = "application/" + fi.Extension;
                        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + nomeArquivo + "\"");
                        Response.WriteFile(CaminhoDiretorioArquivosDNAFTP + "\\" + nomeArquivo);
                        Response.End();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "btnDownloadArquivoProcessado_Click", "GerenciarArquivosBasico", HttpContext.Current.Server.MapPath(diretorioLog));
            }
        }

        public void ListarArquivosEnviados()
        {
            try
            {
                DateTime dtUltmosArquivosEnviados;

                if (ddlListarArquivosUploadPeriodo.SelectedItem.Value == "5")
                { dtUltmosArquivosEnviados = DateTime.Parse(DataBR.AddDays(-5).ToString("dd/MM/yyyy 00:00:00")); }
                else if (ddlListarArquivosUploadPeriodo.SelectedItem.Value == "10")
                { dtUltmosArquivosEnviados = DateTime.Parse(DataBR.AddDays(-10).ToString("dd/MM/yyyy 00:00:00")); }
                else if (ddlListarArquivosUploadPeriodo.SelectedItem.Value == "20")
                { dtUltmosArquivosEnviados = DateTime.Parse(DataBR.AddDays(-20).ToString("dd/MM/yyyy 00:00:00")); }
                else if (ddlListarArquivosUploadPeriodo.SelectedItem.Value == "30")
                { dtUltmosArquivosEnviados = DateTime.Parse(DataBR.AddDays(-30).ToString("dd/MM/yyyy 00:00:00")); }
                else
                { dtUltmosArquivosEnviados = DateTime.Parse(DataBR.AddDays(-60).ToString("dd/MM/yyyy 00:00:00")); }

                string nomeFantasia = usuarioLogado.Cliente.NomeFantasia.Replace(" ", "");
                byte[] bytesNovoNomeFantasia = System.Text.Encoding.GetEncoding("iso-8859-8").GetBytes(nomeFantasia);
                nomeFantasia = System.Text.Encoding.UTF8.GetString(bytesNovoNomeFantasia);

                string mapPath = HttpContext.Current.Server.MapPath("~");
                string CaminhoDiretorioArquivosDNAFTP = mapPath + "_DNAFTP\\UPLOAD\\" + nomeFantasia;

                List<Entidades.FTP.Arquivo> l = new List<Entidades.FTP.Arquivo>();

                DirectoryInfo wDI = new DirectoryInfo(CaminhoDiretorioArquivosDNAFTP);

                if (!wDI.Exists)
                { wDI.Create(); }

                FileInfo[] rgFiles = wDI.GetFiles("*.*");

                foreach (FileInfo fi in rgFiles)
                {
                    if (fi.CreationTime >= dtUltmosArquivosEnviados)
                    {
                        Entidades.FTP.Arquivo arq = new Entidades.FTP.Arquivo();

                        arq.NomeExtensao = fi.Name;
                        arq.Extensao = fi.Extension;
                        arq.Nome = fi.Name.Replace((arq.Extensao), "");

                        arq.DataCompletaCriacao = fi.CreationTime;
                        arq.DataCriacao = string.Format("{0:dd/MM/yyyy}", fi.CreationTime);
                        arq.HoraCriacao = string.Format("{0:HH:mm}", fi.CreationTime);

                        //arq.Tamanho = (((int)(fi.Length)) / 1024).ToString("#,###") + " KB";
                        arq.Tamanho = fi.Length.ToString();
                        if (Math.Round(Decimal.Parse(arq.Tamanho) / 1000) > 999)
                        { arq.Tamanho = String.Format("{0:0,00}", Math.Round(Decimal.Parse(arq.Tamanho) / 1000)) + " KB"; }
                        else if (Math.Round(Decimal.Parse(arq.Tamanho) / 1000) == 0)
                        { arq.Tamanho = "1 KB"; }
                        else
                        { arq.Tamanho = (decimal.Parse(String.Format("{0:0,00}", Math.Round(Decimal.Parse(arq.Tamanho) / 1000)).ToString())) + " KB"; }

                        l.Add(arq);
                    }
                }

                divResultGridUpload.Visible = false;
                if (l.Count > 0)
                {
                    List<Entidades.FTP.Arquivo> listaOrdenada = new List<Entidades.FTP.Arquivo>();

                    listaOrdenada = l.OrderByDescending(p => p.DataCompletaCriacao).ToList();

                    gridResultUpload.DataSource = listaOrdenada;
                    gridResultUpload.DataBind();
                    gridResultUpload.Visible = true;
                    divResultGridUpload.Visible = true;

                    //Business.Util.OcultaColunaEspecificaGrid(ref gridResult, 5);
                    //Business.Util.OcultaColunaEspecificaGrid(ref gridResult, 4);
                }
                else
                {
                    gridResultUpload.DataSource = null;
                    gridResultUpload.DataBind();
                    gridResultUpload.Visible = false;
                    //tblMensagemDiretorioVazio.Visible = true;
                    //lblMensagem.Visible = true;
                    //lblMensagem.Text = "Não há arquivos no seu diretório.";
                }

            }
            catch (Exception ex)
            {
                Util.Log.Save("Erro:" + ex.Message, "ListarArquivosEnviados", "GerenciarArquivosBasico", HttpContext.Current.Server.MapPath(diretorioLog));
                throw ex;
            }
        }

        public void ListarArquivosProcessados()
        {
            try
            {
                DateTime dtUltmosArquivosEnviados;

                if (ddlListarArquivosUploadPeriodo.SelectedItem.Value == "5")
                { dtUltmosArquivosEnviados = DateTime.Parse(DataBR.AddDays(-5).ToString("dd/MM/yyyy 00:00:00")); }
                else if (ddlListarArquivosUploadPeriodo.SelectedItem.Value == "10")
                { dtUltmosArquivosEnviados = DateTime.Parse(DataBR.AddDays(-10).ToString("dd/MM/yyyy 00:00:00")); }
                else if (ddlListarArquivosUploadPeriodo.SelectedItem.Value == "20")
                { dtUltmosArquivosEnviados = DateTime.Parse(DataBR.AddDays(-20).ToString("dd/MM/yyyy 00:00:00")); }
                else if (ddlListarArquivosUploadPeriodo.SelectedItem.Value == "30")
                { dtUltmosArquivosEnviados = DateTime.Parse(DataBR.AddDays(-30).ToString("dd/MM/yyyy 00:00:00")); }
                else
                { dtUltmosArquivosEnviados = DateTime.Parse(DataBR.AddDays(-60).ToString("dd/MM/yyyy 00:00:00")); }

                string nomeFantasia = usuarioLogado.Cliente.NomeFantasia.Replace(" ", "");
                byte[] bytesNovoNomeFantasia = System.Text.Encoding.GetEncoding("iso-8859-8").GetBytes(nomeFantasia);
                nomeFantasia = System.Text.Encoding.UTF8.GetString(bytesNovoNomeFantasia);

                string mapPath = HttpContext.Current.Server.MapPath("~");
                string CaminhoDiretorioArquivosDNAFTP = mapPath + "_DNAFTP\\ARQUIVOS_PROCESSADOS\\" + nomeFantasia;

                List<Entidades.FTP.Arquivo> l = new List<Entidades.FTP.Arquivo>();

                DirectoryInfo wDI = new DirectoryInfo(CaminhoDiretorioArquivosDNAFTP);

                if (!wDI.Exists)
                { wDI.Create(); }

                FileInfo[] rgFiles = wDI.GetFiles("*.*");

                foreach (FileInfo fi in rgFiles)
                {
                    if (fi.CreationTime >= dtUltmosArquivosEnviados)
                    {
                        Entidades.FTP.Arquivo arq = new Entidades.FTP.Arquivo();

                        arq.NomeExtensao = fi.Name;
                        arq.Extensao = fi.Extension;
                        arq.Nome = fi.Name.Replace((arq.Extensao), "");

                        arq.DataCompletaCriacao = fi.CreationTime;
                        arq.DataCriacao = string.Format("{0:dd/MM/yyyy}", fi.CreationTime);
                        arq.HoraCriacao = string.Format("{0:HH:mm}", fi.CreationTime);

                        //arq.Tamanho = (((int)(fi.Length)) / 1024).ToString("#,###") + " KB";
                        arq.Tamanho = fi.Length.ToString();
                        if (Math.Round(Decimal.Parse(arq.Tamanho) / 1000) > 999)
                        { arq.Tamanho = String.Format("{0:0,00}", Math.Round(Decimal.Parse(arq.Tamanho) / 1000)) + " KB"; }
                        else if (Math.Round(Decimal.Parse(arq.Tamanho) / 1000) == 0)
                        { arq.Tamanho = "1 KB"; }
                        else
                        { arq.Tamanho = (decimal.Parse(String.Format("{0:0,00}", Math.Round(Decimal.Parse(arq.Tamanho) / 1000)).ToString())) + " KB"; }

                        l.Add(arq);
                    }
                }

                divResultGridProcessados.Visible = false;
                if (l.Count > 0)
                {
                    List<Entidades.FTP.Arquivo> listaOrdenada = new List<Entidades.FTP.Arquivo>();

                    listaOrdenada = l.OrderByDescending(p => p.DataCompletaCriacao).ToList();

                    gridResultProcessados.DataSource = listaOrdenada;
                    gridResultProcessados.DataBind();
                    gridResultProcessados.Visible = true;
                    divResultGridProcessados.Visible = true;

                    //Business.Util.OcultaColunaEspecificaGrid(ref gridResultProcessados, 5);
                    //Business.Util.OcultaColunaEspecificaGrid(ref gridResultProcessados, 4);
                }
                else
                {
                    gridResultProcessados.DataSource = null;
                    gridResultProcessados.DataBind();
                    gridResultProcessados.Visible = false;
                    //tblMensagemDiretorioVazio.Visible = true;
                    //lblMensagem.Visible = true;
                    //lblMensagem.Text = "Não há arquivos no seu diretório.";
                }

            }
            catch (Exception ex)
            {
                Util.Log.Save("Erro:" + ex.Message, "ListarArquivosProcessados", "GerenciarArquivosBasico", HttpContext.Current.Server.MapPath(diretorioLog));
                throw ex;
            }
        }
    }
}