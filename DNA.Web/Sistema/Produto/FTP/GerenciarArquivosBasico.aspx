<%@ Page Title="" Language="C#" MasterPageFile="~/PrincipalAutenticada.Master" AutoEventWireup="true"
    ValidateRequest="false" EnableEventValidation="false" CodeBehind="GerenciarArquivosBasico.aspx.cs"
    Inherits="DNA.Web.Sistema.Produto.FTP.GerenciarArquivosBasico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- INICIO - Referencias para o modulo de FTP -->
    <link rel="stylesheet" href="../../../CSS/FTPFileUpload/bootstrap.min.css">
    <link rel="stylesheet" href="../../../CSS/FTPFileUpload/blueimp-gallery.min.css">
    <!-- FIM - Referencias para o modulo de FTP -->
    <div style="width: 95%;" class="divResultadoPesquisaCadastral">
        <asp:Label ID="Label1" runat="server" Text="FTP" Style="font-weight: normal; font-size: 20px;"></asp:Label>
        <hr />

    <blockquote>
        <h4>
            Atenção:</h4>
        <h5>
            1 - Só é permitido o envio de arquivos <b>TEXTO</b> (txt), <b>PLANILHAS</b> (xls,
            xlsx e csv) e <b>COMPACTADOS</b> (Zip, Rar, Tar, 7zip, Taz e Gzip).</h5>
        <h5>
            2 - O tamanho máximo do arquivo não pode ultrapassar <b>200MB</b>.</h5>
    </blockquote>
    <div id="divControleFTPPrincipal" style="background-color: #fff" >
        <table id="tbdControleFTPPrincipal" border="0" cellpadding="3" cellspacing="3" width="100%">
            <tr>
                <td colspan="3">
                    <h4>Enviar Arquivos:</h4>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Selecione o Arquivo: " CssClass="LabelSize14"></asp:Label>
                </td>
                <td>
                    <asp:FileUpload ID="fup" runat="server" Width="650px" accept=".txt, .xls, .xlsx, .ace, .arc, .arj, .zip, .rar, .tar, .7zip, .gzip, .csv" />
                </td>
                <td>
                    <asp:Button ID="btnEnviarArquivo" runat="server" Text="Enviar Arquivo" CommandName="Enviar"
                        Style="cursor: pointer; width:150px;" ToolTip="Clique para enviar o arquivo" CssClass="btn btn-success"
                        OnClick="btnEnviarArquivo_Click" OnClientClick="ShowProgressAnimation();"/>
                </td>
            </tr>
            <tr style="height:30px;">
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <h4>Arquivos Enviados:</h4>
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label12" runat="server" Text="Arquivos Enviados nos Últimos: " CssClass="LabelSize14"></asp:Label>
                    <asp:DropDownList ID="ddlListarArquivosUploadPeriodo" runat="server" CssClass="LabelSize14"
                        AutoPostBack="True" 
                        onselectedindexchanged="ddlListarArquivosUploadPeriodo_SelectedIndexChanged">
                        <asp:ListItem Value="5">05 dias</asp:ListItem>
                        <asp:ListItem Value="10">10 dias</asp:ListItem>
                        <asp:ListItem Value="20">20 dias</asp:ListItem>
                        <asp:ListItem Value="30">30 dias</asp:ListItem>
                        <asp:ListItem Value="60">60 dias</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <button type="button" runat="server" class="btn btn-primary start" id="btnAtualizarListaArqEnviados" style="width:150px;" onclick="ShowProgressAnimation();" onserverclick="btnAtualizarListaArqEnviados_Click">
                        <i class="glyphicon glyphicon-refresh"></i><span>&nbsp;&nbsp;Atualizar Lista</span>
                    </button>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <div id="divResultGridUpload" runat="server" style="height: 350px; border: 1px solid #000;">
                    <asp:GridView ID="gridResultUpload" runat="server" AutoGenerateColumns="False" EnableModelValidation="True"
                            Width="100%" onrowdatabound="gridResultUpload_RowDataBound">
                            <Columns>
                                <asp:BoundField HeaderText="Descrição" DataField="NomeExtensao">
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="gridFtpOnlineItem"
                                        Wrap="true" />
                                    <HeaderStyle CssClass="gridFtpOnlineHeader" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Tamanho" DataField="Tamanho">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridFtpOnlineItem" />
                                    <HeaderStyle CssClass="gridFtpOnlineHeader" HorizontalAlign="Center" Width="130px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Data de Envio" DataField="DataCriacao">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridFtpOnlineItem" />
                                    <HeaderStyle CssClass="gridFtpOnlineHeader" HorizontalAlign="Center" Width="130px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Hora de Envio" DataField="HoraCriacao">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridFtpOnlineItem" />
                                    <HeaderStyle CssClass="gridFtpOnlineHeader" HorizontalAlign="Center" Width="130px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Download">
                                    <HeaderStyle CssClass="gridFtpOnlineHeader" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridFtpOnlineItem"
                                        Width="130px" />
                                    <ItemTemplate>
                                        <asp:Button ID="btnDownloadArquivoUpload" runat="server" Text="Download" CommandName="Download"
                                            Style="cursor: pointer;" ToolTip="Fazer download deste arquivo" CssClass="btn btn-success" onclick="btnDownloadArquivoUpload_Click"  />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Excluir">
                                    <HeaderStyle CssClass="gridFtpOnlineHeader" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridFtpOnlineItem"
                                        Width="130px" />
                                    <ItemTemplate>
                                        <asp:Button ID="btnExcluirArquivoUpload" runat="server" Text="Excluir" CommandName="Delete"
                                            Style="cursor: pointer;" ToolTip="Clique para excluir este arquivo" CssClass="btnCustom-danger"
                                            OnClientClick="return confirm('Deseja realmente excluir este arquivo?');"
                                            onclick="btnExcluirArquivoUpload_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <br />
                    </div>
                </td>
            </tr>
            <tr style="height:30px;">
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <h4>Arquivos Processados:</h4>
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label3" runat="server" Text="Arquivos Processados nos Últimos: " CssClass="LabelSize14"></asp:Label>
                    <asp:DropDownList ID="ddlListarArquivosProcessadosPeriodo" runat="server" CssClass="LabelSize14"
                        AutoPostBack="True" 
                        onselectedindexchanged="ddlListarArquivosProcessadosPeriodo_SelectedIndexChanged">
                        <asp:ListItem Value="5">05 dias</asp:ListItem>
                        <asp:ListItem Value="10">10 dias</asp:ListItem>
                        <asp:ListItem Value="20">20 dias</asp:ListItem>
                        <asp:ListItem Value="30">30 dias</asp:ListItem>
                        <asp:ListItem Value="60">60 dias</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <button type="button" runat="server" class="btn btn-primary start" id="Button1" style="width:150px;" onclick="ShowProgressAnimation();" onserverclick="btnAtualizarListaArqProcessados_Click">
                        <i class="glyphicon glyphicon-refresh"></i><span>&nbsp;&nbsp;Atualizar Lista</span>
                    </button>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <div id="divResultGridProcessados" runat="server" style="height: 350px; border: 1px solid #000; overflow-y: scroll">
                    <asp:GridView ID="gridResultProcessados" runat="server" 
                            AutoGenerateColumns="False" EnableModelValidation="True" Width="100%" 
                            onrowdatabound="gridResultProcessados_RowDataBound" 
                        onrowdeleting="gridResultProcessados_RowDeleting">
                            <Columns>
                                <asp:BoundField HeaderText="Descrição" DataField="NomeExtensao">
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="gridFtpOnlineItem" Wrap="true"/>
                                    <HeaderStyle CssClass="gridFtpOnlineHeader" HorizontalAlign="Center"  />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Tamanho" DataField="Tamanho">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridFtpOnlineItem" />
                                    <HeaderStyle CssClass="gridFtpOnlineHeader" HorizontalAlign="Center" Width="130px"/>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Data de Processamento" DataField="DataCriacao">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridFtpOnlineItem" />
                                    <HeaderStyle CssClass="gridFtpOnlineHeader" HorizontalAlign="Center" Width="130px"/>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Hora de Processamento" DataField="HoraCriacao">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridFtpOnlineItem" />
                                    <HeaderStyle CssClass="gridFtpOnlineHeader" HorizontalAlign="Center" Width="130px"/>
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Download">
                                    <HeaderStyle CssClass="gridFtpOnlineHeader" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridFtpOnlineItem" Width="130px"/>
                                    <ItemTemplate>
                                            <asp:Button ID="btnDownloadArquivoProcessado" runat="server" Text="Download" 
                                            CommandName="Download" Style="cursor: pointer;" ToolTip="Fazer download deste arquivo"
                                            CssClass="btn btn-success" 
                                            onclick="btnDownloadArquivoProcessado_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Excluir">
                                    <HeaderStyle CssClass="gridFtpOnlineHeader" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridFtpOnlineItem" Width="130px"/>
                                    <ItemTemplate>
                                        <asp:Button ID="btnExcluirArquivoProcessado" runat="server" Text="Excluir" 
                                            CommandName="Delete" Style="cursor: pointer;"
                                            ToolTip="Clique para excluir este arquivo" CssClass="btnCustom-danger"
                                            OnClientClick="return confirm('Deseja realmente excluir este arquivo?');" 
                                            onclick="btnExcluirArquivoProcessado_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <br />
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        
    </div>
        </div>
    <br />
</asp:Content>
