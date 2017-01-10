using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;

namespace DNA.Web.Sistema.Produto.FTP
{
    public partial class GerenciarArquivos : System.Web.UI.Page
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

                this.Page.Title = "DNA+ - FTP - Gerenciamento de Arquivos";

                if (!Page.IsPostBack)
                {
                    if (!Request.UserAgent.ToUpper().Contains("CHROME") &&
                        !Request.UserAgent.ToUpper().Contains("FIREFOX") &&
                        !Request.UserAgent.ToUpper().Contains("SAFARI"))
                    {

                        System.Web.HttpBrowserCapabilities validaBrowser = Request.Browser;

                        if (validaBrowser.Browser == "IE" && validaBrowser.MajorVersion < 9)
                        {
                            Response.Redirect("GerenciarArquivosBasico.aspx", false);
                            return;
                        }
                    }

                    ListarArquivosEnviados();
                    ListarArquivosProcessados();
                }
            }
            catch (Exception ex)
            {

                Util.Log.Save("ex:" + ex.Message, "Page_Load", "GerenciarArquivos", HttpContext.Current.Server.MapPath(diretorioLog));
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
                Util.Log.Save("ex:" + ex.Message, "btnAtualizarListaArqEnviados_Click", "GerenciarArquivos", HttpContext.Current.Server.MapPath(diretorioLog));
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
                Util.Log.Save("ex:" + ex.Message, "ddlListarArquivosUploadPeriodo_SelectedIndexChanged", "GerenciarArquivos", HttpContext.Current.Server.MapPath(diretorioLog));
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

                    //((System.Web.UI.WebControls.Button)e.Row.FindControl("btnDownloadArquivoUpload")).OnClientClick = "ShowProgressAnimation();";
                    //((System.Web.UI.WebControls.Button)e.Row.FindControl("btnExcluirArquivoUpload")).OnClientClick = "ShowProgressAnimation();";

                }
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "gridResultUpload_RowDataBound", "GerenciarArquivos", HttpContext.Current.Server.MapPath(diretorioLog));
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
                Util.Log.Save("ex:" + ex.Message, "btnExcluirArquivoUpload_Click", "GerenciarArquivos", HttpContext.Current.Server.MapPath(diretorioLog));
            }
        }

        protected void PostBackBind_DataBinding(object sender, EventArgs e)
        {
            try
            {
                Button lb = (Button)sender;
                ScriptManager sm = (ScriptManager)Page.Master.FindControl("ScriptManager1");
                sm.RegisterPostBackControl(lb);
            }
            catch (Exception ex)
            {
                throw ex;
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
                string URLArquivosDNAFTP = "_DNAFTP/UPLOAD/" + nomeFantasia;

                DirectoryInfo wDI = new DirectoryInfo(CaminhoDiretorioArquivosDNAFTP);
                FileInfo[] rgFiles = wDI.GetFiles("*.*");
                foreach (FileInfo fi in rgFiles)
                {
                    if (fi.Name.ToUpper().Trim().Equals(nomeArquivo.ToUpper()))
                    {
                        string extensaoArquivo = Path.GetExtension(fi.Name).Trim().ToUpper();
                        if (extensaoArquivo.Equals(".TXT"))
                        {
                            Response.Clear();
                            Response.ClearHeaders();
                            Response.ClearContent();

                            Response.AddHeader("Content-Length", fi.Length.ToString());
                            Response.ContentType = "text/plain";
                            Response.AppendHeader("Content-Disposition", "attachment;filename=\"" + nomeArquivo + "\"");
                            Response.TransmitFile(CaminhoDiretorioArquivosDNAFTP + "\\" + nomeArquivo);
                            Response.End();

                            //Response.Clear();
                            //Response.ClearHeaders();
                            //Response.ClearContent();
                            //Response.ContentType = "application/" + fi.Extension;
                            //Response.AddHeader("Content-Disposition", "attachment;filename=\"" + nomeArquivo + "\"");
                            //Response.TransmitFile(CaminhoDiretorioArquivosDNAFTP + "\\" + nomeArquivo);
                            //Response.End();
                        }
                        else
                        {
                            Response.Redirect("../../../" + URLArquivosDNAFTP + "/" + nomeArquivo, true);
                        }

                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "redirectScript", "window.location.href='http://onlinehomolog.dnamais.com.br/downteste.txt';", true);

                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "btnDownloadArquivoUpload_Click", "GerenciarArquivos", HttpContext.Current.Server.MapPath(diretorioLog));
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
                Util.Log.Save("ex:" + ex.Message, "btnAtualizarListaArqProcessados_Click", "GerenciarArquivos", HttpContext.Current.Server.MapPath(diretorioLog));
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
                Util.Log.Save("ex:" + ex.Message, "ddlListarArquivosProcessadosPeriodo_SelectedIndexChanged", "GerenciarArquivos", HttpContext.Current.Server.MapPath(diretorioLog));
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

                    //((System.Web.UI.WebControls.Button)e.Row.FindControl("btnDownloadArquivoProcessado")).OnClientClick = "ShowProgressAnimation();";
                    //((System.Web.UI.WebControls.Button)e.Row.FindControl("btnExcluirArquivoProcessado")).OnClientClick = "ShowProgressAnimation();";

                }
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "gridResultProcessados_RowDataBound", "GerenciarArquivos", HttpContext.Current.Server.MapPath(diretorioLog));
            }
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
                Util.Log.Save("ex:" + ex.Message, "btnExcluirArquivoProcessado_Click", "GerenciarArquivos", HttpContext.Current.Server.MapPath(diretorioLog));
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
                string URLArquivosDNAFTP = "_DNAFTP/ARQUIVOS_PROCESSADOS/" + nomeFantasia;

                DirectoryInfo wDI = new DirectoryInfo(CaminhoDiretorioArquivosDNAFTP);
                FileInfo[] rgFiles = wDI.GetFiles("*.*");
                foreach (FileInfo fi in rgFiles)
                {
                    if (fi.Name.ToUpper().Trim().Equals(nomeArquivo.ToUpper()))
                    {
                        //Response.Clear();
                        //Response.ClearHeaders();
                        //Response.ClearContent();
                        //Response.ContentType = "application/" + fi.Extension;
                        //Response.AddHeader("Content-Disposition", "attachment;filename=\"" + nomeArquivo + "\"");
                        //Response.WriteFile(CaminhoDiretorioArquivosDNAFTP + "\\" + nomeArquivo);
                        //Response.Flush();
                        //Response.End();

                        Response.Redirect("../../../" + URLArquivosDNAFTP + "/" + nomeArquivo, false);
                        break;
                    }
                }


            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "btnDownloadArquivoProcessado_Click", "GerenciarArquivos", HttpContext.Current.Server.MapPath(diretorioLog));
            }
            
        }

        public void ListarArquivosEnviados()
        {
            try
            {
                DateTime dtUltmosArquivosEnviados;

                if (ddlListarArquivosUploadPeriodo.SelectedItem.Value == "1")
                { dtUltmosArquivosEnviados = DateTime.Parse(DataBR.AddDays(-1).ToString("dd/MM/yyyy 00:00:00")); }
                else if (ddlListarArquivosUploadPeriodo.SelectedItem.Value == "5")
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

                if (l.Count > 0)
                {
                    List<Entidades.FTP.Arquivo> listaOrdenada = new List<Entidades.FTP.Arquivo>();

                    listaOrdenada = l.OrderByDescending(p => p.DataCompletaCriacao).ToList();

                    gridResultUpload.DataSource = listaOrdenada;
                    gridResultUpload.DataBind();
                    gridResultUpload.Visible = true;

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
                Util.Log.Save("Erro:" + ex.Message, "ListarArquivosEnviados", "GerenciarArquivos", HttpContext.Current.Server.MapPath(diretorioLog));
                throw ex;
            }
        }

        public void ListarArquivosProcessados()
        {
            try
            {
                DateTime dtUltmosArquivosEnviados;

                if (ddlListarArquivosUploadPeriodo.SelectedItem.Value == "1")
                { dtUltmosArquivosEnviados = DateTime.Parse(DataBR.AddDays(-1).ToString("dd/MM/yyyy 00:00:00")); }
                else if (ddlListarArquivosUploadPeriodo.SelectedItem.Value == "5")
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

                if (l.Count > 0)
                {
                    List<Entidades.FTP.Arquivo> listaOrdenada = new List<Entidades.FTP.Arquivo>();

                    listaOrdenada = l.OrderByDescending(p => p.DataCompletaCriacao).ToList();

                    gridResultProcessados.DataSource = listaOrdenada;
                    gridResultProcessados.DataBind();
                    gridResultProcessados.Visible = true;

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
                Util.Log.Save("Erro:" + ex.Message, "ListarArquivosProcessados", "GerenciarArquivos", HttpContext.Current.Server.MapPath(diretorioLog));
                throw ex;
            }
        }

        protected void gridResultProcessados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }


    }
}