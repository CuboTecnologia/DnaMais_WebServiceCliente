<%@ Page Title="" Language="C#" MasterPageFile="~/PrincipalAutenticada.Master" AutoEventWireup="true"
    CodeBehind="ConsultaWebRastreamentoSearchTelefonePF.aspx.cs" Inherits="DNA.Web.Sistema.Produto.Cadastral.ConsultaWebRastreamentoSearchTelefonePF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function ValidaCampos() {
            if (document.getElementById('ctl00_head_txtDDD').value != '' && document.getElementById('ctl00_head_txtTelefone').value != '') {
                ShowProgressAnimation(); 
            }
        }
    </script>

    <div style="width: 96%;" class="divResultadoPesquisaCadastral">
        <asp:Label ID="Label10" runat="server" Text="Filtro" Style="font-weight: normal;
            font-size: 20px;"></asp:Label>
        <hr />
    </div>
    <div style="width: 668px;">
        <table border="0" cellpadding="1" cellspacing="1" width="100%">
            <tr>
                <td style="width: 150px;">
                    <asp:Label ID="Label7" runat="server" CssClass="LabelMensagemRetorno"
                        Visible="true" Text="DDD:" Style="font-weight: normal; font-size: 20px;color:#000;"></asp:Label>
                </td>
                <td align="left" valign="middle"    >
                    <asp:TextBox ID="txtDDD" runat="server" MaxLength="2"
                        Style="color: #000; width: 50px; text-align: center; text-transform: uppercase;
                        font-family: 'Segoe UI', 'Open Sans', Arial, sans-serif; text-decoration: none;
                        font-size: 20px;" Text=""  onKeyPress="return digitos(event, this);"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtDDD" ErrorMessage="* INFORME O DDD" 
                        SetFocusOnError="True" style="position:relative; top:-5px;"></asp:RequiredFieldValidator>
                </td>
                <td align="left" valign="middle" style="width:300px;"> </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label427" runat="server" CssClass="LabelMensagemRetorno"
                        Visible="true" Text="TELEFONE:" Style="font-weight: normal; font-size: 20px; color:#000;"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtTelefone" runat="server" MaxLength="10" Style="color: #000; width: 200px; text-align: center; text-transform: uppercase;
                        font-family: 'Segoe UI', 'Open Sans', Arial, sans-serif; text-decoration: none;
                        font-size: 20px;" Text="" onKeyPress="return digitos(event, this);" onKeyUp="Mascara('TEL',this,event);"></asp:TextBox>
                </td>
                <td align="left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtTelefone" 
                        ErrorMessage="* INFORME O NÚMERO DO TELEFONE" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    <div>
                        <asp:Button Text="Pesquisar" runat="server" ToolTip="Pesquisar..." CssClass="btnPesquisar"
                            ID="btnPesquisar" BorderStyle="None" TabIndex="0" OnClick="btnPesquisar_Click"
                            OnClientClick="ValidaCampos();" style="margin-right:10px;" />
                    </div>
                </td>
                <td align="right">
                    &nbsp;</td>
            </tr>
        </table>
    </div>
    <div id="divMensagemRetorno" runat="server" style="width: 1000px; text-align: center;">
        <br />
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:Label ID="lblMensagemRetorno" runat="server" CssClass="LabelMensagemRetorno"
                        Visible="false" Text="" Style="font-weight: normal; font-size: 20px;"></asp:Label>
                </td>
                <td style="width: 150px;">
                    <div id="divImprimirMensagemErro" style="display: none;" runat="server" class="divImprimirResultado divImprimirResultado-1 divImprimirResultado-1a"
                        onclick="printDiv('ctl00_head_divMensagemRetorno');" title="Clique para imprimir este documento">
                        <asp:Label ID="Label109" runat="server" CssClass="lblTextoImprimir" Style="position: relative;
                            top: 2px;" Text="Imprimir"></asp:Label>
                        <input class="imgLogoPrint" src="../../../images/LogoMD202x70.png" style="display: none;"
                            type="image" />
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div id="divEspacoBranco" style="height: 200px;" runat="server">
    </div>
    <div class="divResultadoPesquisaCadastral" runat="server" id="divResultado" style="width: 1000px;">
        <table border="0" cellpadding="1" cellspacing="1" width="100%">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Resultado" Style="font-weight: normal;
                        font-size: 20px;"></asp:Label>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td valign="top">
                                <asp:Label Style="position: relative; top: -15px;" ID="Label2" runat="server" Text="Nº. Protocolo da Consulta: "></asp:Label>
                                <asp:Label Style="position: relative; top: -15px;" ID="lblNumeroConsulta" runat="server"
                                    Text=""></asp:Label>
                            </td>
                            <td rowspan="2" valign="top" align="right">
                                <div id="divImprimirResultado" class="divImprimirResultado divImprimirResultado-1 divImprimirResultado-1a"
                                    title="Clique para imprimir este documento" onclick="printDiv('ctl00_head_divResultado');">
                                    <asp:Label CssClass="lblTextoImprimir" Style="position: relative; top: 2px;" ID="Label9"
                                        runat="server" Text="Imprimir"></asp:Label>
                                    <input type="image" class="imgLogoPrint" src="../../../images/LogoPrint.png" style="display: none;" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label Style="position: relative; top: -15px;" ID="Label3" runat="server" Text="Data e Hora da Consulta: "></asp:Label>
                                <asp:Label Style="position: relative; top: -15px;" ID="lblDataConsulta" runat="server"
                                    Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table border="0" cellpadding="0" cellspacing="2" width="100%">
                        <tr>
                            <td>
                                <div id="divResultPFPrata" runat="server" style="height: 100%;">
                                    <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                        <tr>
                                            <td colspan="4">
                                                <asp:Label ID="Label13" runat="server" Text="REGITRO(S) ENCONTRADO(S)" Style="font-weight: normal;
                                                    font-size: 20px;" CssClass="lblTituloDadosVeiculo"></asp:Label>
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:GridView ID="gridResult" runat="server" 
                                                    AutoGenerateColumns="False" EnableModelValidation="True" Width="100%" 
                                                    onrowdatabound="gridResult_RowDataBound" >
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="CPF">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="linkCPF" runat="server" Target="_blank">HyperLink</asp:HyperLink>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="250px" VerticalAlign="Middle" CssClass="gridCadastralHeader" HorizontalAlign="Center"/>
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridCadastralItem" Wrap="False" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="NOME">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="linkNOME" runat="server" Target="_blank">HyperLink</asp:HyperLink>
                                                            </ItemTemplate>
                                                            <HeaderStyle VerticalAlign="Middle" CssClass="gridCadastralHeader" HorizontalAlign="Center"/>
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridCadastralItem" Wrap="False" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="DATA NASCIMENTO">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="linkDataNascimento" runat="server" Target="_blank">HyperLink</asp:HyperLink>
                                                            </ItemTemplate>
                                                            <HeaderStyle VerticalAlign="Middle" CssClass="gridCadastralHeader" HorizontalAlign="Center"/>
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridCadastralItem" Wrap="False" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="NOME DA MÃE">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="linkNOMEMAE" runat="server" Target="_blank">HyperLink</asp:HyperLink>
                                                            </ItemTemplate>
                                                            <HeaderStyle VerticalAlign="Middle" CssClass="gridCadastralHeader" HorizontalAlign="Center"/>
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridCadastralItem" Wrap="False" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="CPF" DataField="CPF" />
                                                        <asp:BoundField HeaderText="Nome" DataField="Nome"/>
                                                        <asp:BoundField HeaderText="DataNascimento" DataField="DataNascimento"/>
                                                        <asp:BoundField HeaderText="NomeMae" DataField="NomeMae"/>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr align="center">
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr align="center">
                            <td>
                                <fieldset class="MensagemPesquisaFinalizada">
                                    <legend>&nbsp; Pesquisa Finalizada &nbsp;</legend>
                                </fieldset>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div id="divMsgAguarde" runat="server">
        <span id="MsgAguarde" style="display: none; font-size: 11px;">
            <img src="../../../image/loading.gif" alt="Aguarde..." /><br />
            Aguarde... </span>
    </div>
    <asp:Label ID="Label8" runat="server" Text="."></asp:Label>
</asp:Content>
