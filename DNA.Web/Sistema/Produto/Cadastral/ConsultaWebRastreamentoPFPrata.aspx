<%@ Page Title="" Language="C#" MasterPageFile="~/PrincipalAutenticada.Master" AutoEventWireup="true"
    CodeBehind="ConsultaWebRastreamentoPFPrata.aspx.cs" Inherits="DNA.Web.Sistema.Produto.Cadastral.ConsultaWebRastreamentoPFPrata" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <div id="divTituloFiltro" runat="server" style="width: 96%;" class="divResultadoPesquisaCadastral">
        <asp:Label ID="Label10" runat="server" Text="Filtro" Style="font-weight: normal;
            font-size: 20px;"></asp:Label>
        <hr />
    </div>
    <div style="width: 560px;">
        <table id="tblFiltro" runat="server" border="0" cellpadding="1" cellspacing="1" width="100%">
            <tr>
                <td style="width: 160px;">
                    <select onchange="SetMaxLengthVeiculos(this.value);" id="ddlFiltro" runat="server"
                        style="width: 150px; font-family: 'Segoe UI', 'Open Sans', Arial, sans-serif;
                        text-decoration: none; font-size: 20px;">
                        <option value="CPF">CPF</option>
                    </select>
                </td>
                <td align="right">
                    <asp:TextBox ID="txtParametroInformado" runat="server" MaxLength="14" onKeyUp="Mascara('CPF', this, event);"
                        Style="color: #000; width: 400px; text-align: center; text-transform: uppercase;
                        font-family: 'Segoe UI', 'Open Sans', Arial, sans-serif; text-decoration: none;
                        font-size: 20px;"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    <div>
                        <asp:Button Text="Pesquisar" runat="server" ToolTip="Pesquisar..." CssClass="btnPesquisar"
                            ID="btnPesquisar" BorderStyle="None" TabIndex="0" OnClick="btnPesquisar_Click"
                            OnClientClick="ShowProgressAnimation();" />
                    </div>
                </td>
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
                        <tr style="background-color: #fff;">
                            <td>
                            &nbsp;
                            </td>
                        </tr>
                        <tr style="background-color: #fff;">
                            <td>
                                <asp:Label ID="Label12" runat="server" Text="Dados Cadastrais" Style="font-weight: normal;
                                    font-size: 20px;"></asp:Label>
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="divResultPFPrata" runat="server" style="height: 100%;">
                                    <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                        <tr>
                                            <td class="tabelaColunaLabelResultadoCadastral">
                                                <asp:Label ID="Label4" runat="server" Text="Nome Completo: "></asp:Label>
                                            </td>
                                            <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" colspan="3">
                                                <asp:Label ID="lblNomeCompleto" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tabelaColunaLabelResultadoCadastral">
                                                <asp:Label ID="Label423" runat="server" Text="Nome da Mãe: "></asp:Label>
                                            </td>
                                            <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" colspan="3">
                                                <asp:Label ID="lblNomeMae" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tabelaColunaLabelResultadoCadastral">
                                                <asp:Label ID="Label422" runat="server" Text="CPF:"></asp:Label>
                                            </td>
                                            <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" colspan="3">
                                                <asp:Label ID="lblCPF" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tabelaColunaLabelResultadoCadastral">
                                                <asp:Label ID="lblRGTitulo0" runat="server" Text="Status do CPF:"></asp:Label>
                                            </td>
                                            <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" colspan="3">
                                                <asp:Label ID="lblStatusCPF" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tabelaColunaLabelResultadoCadastral">
                                                <asp:Label ID="lblRGTitulo" runat="server" Text="RG:"></asp:Label>
                                            </td>
                                            <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" colspan="3">
                                                <asp:Label ID="lblRG" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tabelaColunaLabelResultadoCadastral">
                                                <asp:Label ID="lblRGTitulo1" runat="server" Text="Título de Eleitor:"></asp:Label>
                                            </td>
                                            <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" colspan="3">
                                                <asp:Label ID="lblTituloEleitor" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tabelaColunaLabelResultadoCadastral">
                                                <asp:Label ID="Label15" runat="server" Text="Data de Nascimento:"></asp:Label>
                                            </td>
                                            <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" colspan="3">
                                                <asp:Label ID="lblDataNascimento" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tabelaColunaLabelResultadoCadastral">
                                                <asp:Label ID="Label5" runat="server" Text="Idade:"></asp:Label>
                                            </td>
                                            <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" colspan="3">
                                                <asp:Label ID="lblIdade" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tabelaColunaLabelResultadoCadastral">
                                                <asp:Label ID="Label14" runat="server" Text="Signo:"></asp:Label>
                                            </td>
                                            <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" colspan="3">
                                                <asp:Label ID="lblSigno" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tabelaColunaLabelResultadoCadastral">
                                                <asp:Label ID="Label6" runat="server" Text="Sexo:"></asp:Label>
                                            </td>
                                            <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" colspan="3">
                                                <asp:Label ID="lblSexo" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tabelaColunaLabelResultadoCadastral">
                                                <asp:Label ID="Label16" runat="server" Text="Estado Civil:"></asp:Label>
                                            </td>
                                            <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" colspan="3">
                                                <asp:Label ID="lblEstadoCivil" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tabelaColunaLabelResultadoCadastral">
                                                <asp:Label ID="Label17" runat="server" Text="Escolaridade:"></asp:Label>
                                            </td>
                                            <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" colspan="3">
                                                <asp:Label ID="lblEscolaridade" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tabelaColunaLabelResultadoCadastral">
                                                <asp:Label ID="Label18" runat="server" Text="Renda Estimada:"></asp:Label>
                                            </td>
                                            <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" colspan="3">
                                                <asp:Label ID="lblRendaEstimada" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tabelaColunaLabelResultadoCadastral">
                                                <asp:Label ID="Label20" runat="server" Text="Classe Social:"></asp:Label>
                                            </td>
                                            <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" colspan="3">
                                                <asp:Label ID="lblClasseSocial" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tabelaColunaLabelResultadoCadastral">
                                                <asp:Label ID="Label424" runat="server" Text="Óbito:"></asp:Label>
                                            </td>
                                            <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" colspan="3">
                                                <asp:Label ID="lblObito" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tabelaColunaLabelResultadoCadastral">
                                                <asp:Label ID="Label426" runat="server" Text="Data de Óbito:"></asp:Label>
                                            </td>
                                            <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" colspan="3">
                                                <asp:Label ID="lblDtObito" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:Label ID="Label13" runat="server" Text="Endereço(s)" Style="font-weight: normal;
                                                    font-size: 20px;" CssClass="lblTituloDadosVeiculo"></asp:Label>
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:GridView ID="gridResultEnderecos" runat="server" 
                                                    AutoGenerateColumns="False" EnableModelValidation="True" Width="100%" 
                                                    onrowdatabound="gridResultEnderecos_RowDataBound">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Logradouro" DataField="Logradouro">
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="gridCadastralItem" Wrap="False"/>
                                                            <HeaderStyle CssClass="gridCadastralHeader" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Nº." DataField="Numero">
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridCadastralItem" />
                                                            <HeaderStyle CssClass="gridCadastralHeader" HorizontalAlign="Center" Width="60px"/>
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Complemento" DataField="Complemento">
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridCadastralItem" />
                                                            <HeaderStyle CssClass="gridCadastralHeader" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Bairro" DataField="Bairro">
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridCadastralItem" Wrap="False"/>
                                                            <HeaderStyle CssClass="gridCadastralHeader" HorizontalAlign="Center"/>
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="CEP" DataField="CEP">
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridCadastralItem" />
                                                            <HeaderStyle CssClass="gridCadastralHeader" HorizontalAlign="Center" Width="110px"/>
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Cidade" DataField="Cidade">
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" CssClass="gridCadastralItem" Wrap="False"/>
                                                            <HeaderStyle CssClass="gridCadastralHeader" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="UF" DataField="UF">
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridCadastralItem" />
                                                            <HeaderStyle CssClass="gridCadastralHeader" HorizontalAlign="Center" Width="50px"/>
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Moradores">
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridCadastralItem" />
                                                            <HeaderStyle CssClass="gridCadastralHeader" HorizontalAlign="Center" Width="50px"/>
                                                            <ItemTemplate>
                                                            <!--<div id="divVerMoradores" title="Pessoas que moram neste endereço" style="cursor: pointer; background-image: url('../Imagens/lupa2.ico'); width: 16px; height: 16px;" runat="server"></div>-->
                                                            <asp:HyperLink ID="linkMoradores" runat="server" ToolTip="Pessoas que moram neste endereço" Target="_blank">Ver...</asp:HyperLink>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
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
                                                <asp:Label ID="Label21" runat="server" Text="Telefone(s)" Style="font-weight: normal;
                                                    font-size: 20px;" CssClass="lblTituloDadosVeiculo"></asp:Label>
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:GridView ID="gridResultTelefones" runat="server" 
                                                    AutoGenerateColumns="False" EnableModelValidation="True" Width="100%" 
                                                    onrowdatabound="gridResultTelefones_RowDataBound">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="DDD" DataField="DDD">
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridCadastralItem" Width="100px" />
                                                            <HeaderStyle CssClass="gridCadastralHeader" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Número" DataField="Numero">
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="gridCadastralItem" />
                                                            <HeaderStyle CssClass="gridCadastralHeader" HorizontalAlign="Left" />
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
                                                <asp:Label ID="Label23" runat="server" Text="E-mail(s)" Style="font-weight: normal;
                                                    font-size: 20px;" CssClass="lblTituloDadosVeiculo"></asp:Label>
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:GridView ID="gridResultEmails" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" Width="100%">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Endereço" DataField="Endereco">
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="gridCadastralItem" />
                                                            <HeaderStyle CssClass="gridCadastralHeader" HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:Label ID="Label7" runat="server" Text="Participação em Empresas" Style="font-weight: normal;
                                                    font-size: 20px;" CssClass="lblTituloDadosVeiculo"></asp:Label>
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:GridView ID="gridResultQSA" runat="server" 
                                                    AutoGenerateColumns="False" EnableModelValidation="True" Width="100%" 
                                                    onrowdatabound="gridResultQSA_RowDataBound">
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
