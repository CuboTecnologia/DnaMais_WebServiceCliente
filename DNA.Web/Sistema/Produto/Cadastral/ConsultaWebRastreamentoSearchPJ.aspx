<%@ Page Title="" Language="C#" MasterPageFile="~/PrincipalAutenticada.Master" AutoEventWireup="true"
    CodeBehind="ConsultaWebRastreamentoSearchPJ.aspx.cs" Inherits="DNA.Web.Sistema.Produto.Cadastral.ConsultaWebRastreamentoSearchPJ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function ValidaCampos() {
            var ddlUF = document.getElementById("ctl00_head_ddlUF");
            var strUF = ddlUF.options[ddlUF.selectedIndex].value;

            var ddlCidade = document.getElementById("ctl00_head_ddlCidade");
            var strCidade = ddlCidade.options[ddlCidade.selectedIndex].value;

            if (document.getElementById('ctl00_head_txtNome').value != '' && strUF != "00" && strCidade != "00") {
                ShowProgressAnimation(); 
            }
        }
    </script>

    <div style="width: 96%;" class="divResultadoPesquisaCadastral">
        <asp:Label ID="Label10" runat="server" Text="Filtro" Style="font-weight: normal;
            font-size: 20px;"></asp:Label>
        <hr />
    </div>
    <div style="width: 1000px;">
        <table border="0" cellpadding="1" cellspacing="1" width="100%">
            <tr>
                <td style="width: 220px;">
                    <asp:Label ID="Label7" runat="server" CssClass="LabelMensagemRetorno"
                        Visible="true" Text="NOME DA EMPRESA:" Style="font-weight: normal; font-size: 20px;color:#000;"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtNome" runat="server" MaxLength="100"
                        Style="color: #000; width: 575px; text-align: left; text-transform: uppercase;
                        font-family: 'Segoe UI', 'Open Sans', Arial, sans-serif; text-decoration: none;
                        font-size: 20px;" Text=""></asp:TextBox>
                </td>
                <td align="left" valign="middle" style="width:185px;"> 

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtNome" ErrorMessage="* INFORME UM NOME" 
                        SetFocusOnError="True"></asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label427" runat="server" CssClass="LabelMensagemRetorno"
                        Visible="true" Text="UF:" Style="font-weight: normal; font-size: 20px; color:#000;"></asp:Label>
                </td>
                <td align="left">
                    <asp:UpdatePanel ID="updpUF" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlUF" runat="server" style="width: 580px; font-family: 'Segoe UI', 'Open Sans', Arial, sans-serif;
	                        text-decoration: none; font-size: 20px;" AutoPostBack="True" 
                            onselectedindexchanged="ddlUF_SelectedIndexChanged">
	                        <asp:ListItem Value="00">SELECIONE...</asp:ListItem>
                            <asp:ListItem Value="26">SP - SÃO PAULO</asp:ListItem>
	                        <asp:ListItem Value="19">RJ - RIO DE JANEIRO</asp:ListItem>
	                        <asp:ListItem Value="00">--------</asp:ListItem>
	                        <asp:ListItem Value="01">AC - ACRE</asp:ListItem>
	                        <asp:ListItem Value="02">AL - ALAGOAS</asp:ListItem>
	                        <asp:ListItem Value="03">AM - AMAZONAS</asp:ListItem>
	                        <asp:ListItem Value="04">AP - AMAPÁ</asp:ListItem>
	                        <asp:ListItem Value="05">BA - BAHIA</asp:ListItem>
	                        <asp:ListItem Value="06">CE - CEARÁ</asp:ListItem>
	                        <asp:ListItem Value="07">DF - DISTRITO FEDERAl</asp:ListItem>
	                        <asp:ListItem Value="08">ES - ESPÍRITO SANTO</asp:ListItem>
	                        <asp:ListItem Value="09">GO - GOIÁS</asp:ListItem>
	                        <asp:ListItem Value="10">MA - MARANHÃO</asp:ListItem>
	                        <asp:ListItem Value="11">MG - MINAS GERAIS</asp:ListItem>
	                        <asp:ListItem Value="12">MS - MATO GROSSO DO SUL</asp:ListItem>
	                        <asp:ListItem Value="13">MT - MATO GROSSO</asp:ListItem>
	                        <asp:ListItem Value="14">PA - PARÁ</asp:ListItem>
	                        <asp:ListItem Value="15">PB - PARAÍBA</asp:ListItem>
	                        <asp:ListItem Value="16">PE - PERNAMBUCO</asp:ListItem>
	                        <asp:ListItem Value="17">PI - PIAUÍ</asp:ListItem>
	                        <asp:ListItem Value="18">PR - PARANÁ</asp:ListItem>
	                        <asp:ListItem Value="20">RN - RIO GRANDE DO NORTE</asp:ListItem>
	                        <asp:ListItem Value="21">RO - RONDÔNIA</asp:ListItem>
	                        <asp:ListItem Value="22">RR - RORAIMA</asp:ListItem>
	                        <asp:ListItem Value="23">RS - RIO GRANDE DO SUL</asp:ListItem>
	                        <asp:ListItem Value="24">SC - SANTA CATARINA</asp:ListItem>
	                        <asp:ListItem Value="25">SE - SERGIPE</asp:ListItem>
	                        <asp:ListItem Value="27">TO - TOCANTINS</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlUF" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td align="left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="ddlUF" ErrorMessage="* SELECIONE O ESTADO" InitialValue="00"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label428" runat="server" CssClass="LabelMensagemRetorno"
                        Visible="true" Text="CIDADE:" Style="font-weight: normal; font-size: 20px;color:#000;"></asp:Label>
                </td>
                <td align="left">
                <asp:UpdatePanel ID="updpCidades" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlCidade" runat="server" style="width: 580px; font-family: 'Segoe UI', 'Open Sans', Arial, sans-serif;
	                            text-decoration: none; font-size: 20px;" AutoPostBack="false">
	                            <asp:ListItem Value="00">SELECIONE...</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlUF" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
               </td>
               <td align="left"  > 
                    <div id="div0" style="">
                        <div id="div1" style="float: left;position:relative; top:5px;" >
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ErrorMessage="* SELECIONE A CIDADE" ControlToValidate="ddlCidade" 
                            InitialValue="00"></asp:RequiredFieldValidator>
                        </div>
                        <div id="div2" style="float: left; position:relative; left:-180px; top:5px;" >
                        <asp:UpdateProgress ID="updlCidade" runat="server" AssociatedUpdatePanelID="updpUF"
                            DisplayAfter="100">
                            <ProgressTemplate>
                                <img src="../../../images/Loading.gif" alt="Carregando..." />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        </div>
                    </div>
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
                                                    onrowdatabound="gridResult_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="CNPJ">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="linkCNPJ" runat="server" Target="_blank">HyperLink</asp:HyperLink>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="250px" VerticalAlign="Middle" CssClass="gridCadastralHeader" HorizontalAlign="Center"/>
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridCadastralItem" Wrap="False" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="RAZÃO SOCIAL">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="linkRazaoSocial" runat="server" Target="_blank">HyperLink</asp:HyperLink>
                                                            </ItemTemplate>
                                                            <HeaderStyle VerticalAlign="Middle" CssClass="gridCadastralHeader" HorizontalAlign="Center"/>
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="gridCadastralItem" Wrap="False" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="NOME FANTASIA">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="linkNomeFantasia" runat="server" Target="_blank">HyperLink</asp:HyperLink>
                                                            </ItemTemplate>
                                                            <HeaderStyle VerticalAlign="Middle" CssClass="gridCadastralHeader" HorizontalAlign="Center"/>
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="gridCadastralItem" Wrap="False" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="CNPJ" DataField="CNPJ">
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="RazaoSocial" DataField="RazaoSocial">
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="NomeFantasia" DataField="NomeFantasia">
                                                        </asp:BoundField>
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
