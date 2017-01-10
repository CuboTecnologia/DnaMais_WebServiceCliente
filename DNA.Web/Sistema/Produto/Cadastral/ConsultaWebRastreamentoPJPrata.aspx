<%@ Page Title="" Language="C#" MasterPageFile="~/PrincipalAutenticada.Master" AutoEventWireup="true"
    CodeBehind="ConsultaWebRastreamentoPJPrata.aspx.cs" Inherits="DNA.Web.Sistema.Produto.Cadastral.ConsultaWebRastreamentoPJPrata" %>

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
                        <option value="CNPJ">CNPJ</option>
                    </select>
                </td>
                <td align="right">
                    <asp:TextBox ID="txtParametroInformado" runat="server" MaxLength="18" onKeyUp="Mascara('CNPJ', this, event);"
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
                                                <asp:Label ID="Label4" runat="server" Text="CNPJ: "></asp:Label>
                                            </td>
                                            <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" colspan="3">
                                                <asp:Label ID="lblCNPJ" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tabelaColunaLabelResultadoCadastral">
                                                <asp:Label ID="Label423" runat="server" Text="Razão Social: "></asp:Label>
                                            </td>
                                            <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" colspan="3">
                                                <asp:Label ID="lblRazaoSocial" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tabelaColunaLabelResultadoCadastral">
                                                <asp:Label ID="Label422" runat="server" Text="MATRIZ/FILIAL:"></asp:Label>
                                            </td>
                                            <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" colspan="3">
                                                <asp:Label ID="lblMatrizFilial" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tabelaColunaLabelResultadoCadastral">
                                                <asp:Label ID="lblRGTitulo0" runat="server" Text="DATA DE ABERTURA:"></asp:Label>
                                            </td>
                                            <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" colspan="3">
                                                <asp:Label ID="lblDataAbertura" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tabelaColunaLabelResultadoCadastral">
                                                <asp:Label ID="lblRGTitulo" runat="server" Text="NOME FANTASIA:"></asp:Label>
                                            </td>
                                            <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" colspan="3">
                                                <asp:Label ID="lblNomeFantasia" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tabelaColunaLabelResultadoCadastral">
                                                <asp:Label ID="lblRGTitulo1" runat="server" Text="NATUREZA JURIDICA:"></asp:Label>
                                            </td>
                                            <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" colspan="3">
                                                <asp:Label ID="lblNaturezaJuridica" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tabelaColunaLabelResultadoCadastral">
                                                <asp:Label ID="Label15" runat="server" Text="SITUACAO CADASTRAL:"></asp:Label>
                                            </td>
                                            <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" colspan="3">
                                                <asp:Label ID="lblSituacaoCadastral" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tabelaColunaLabelResultadoCadastral">
                                                <asp:Label ID="Label5" runat="server" Text="DATA DA SITUACAO CADASTRAL:"></asp:Label>
                                            </td>
                                            <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" colspan="3">
                                                <asp:Label ID="lblDataSituacaoCadastral" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:Label ID="Label23" runat="server" Text="Atividade(s) Econômica(s)" Style="font-weight: normal;
                                                    font-size: 20px;" CssClass="lblTituloDadosVeiculo"></asp:Label>
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:GridView ID="gridResultCNAEs" runat="server" AutoGenerateColumns="False" EnableModelValidation="True"
                                                    Width="100%">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Código" DataField="Codigo">
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridCadastralItem" />
                                                            <HeaderStyle CssClass="gridCadastralHeader" HorizontalAlign="Center" Width="100px"  />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Descrição" DataField="Descricao">
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="gridCadastralItem" />
                                                            <HeaderStyle CssClass="gridCadastralHeader" HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
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
                                                <asp:GridView ID="gridResultEnderecos" runat="server" AutoGenerateColumns="False"
                                                    EnableModelValidation="True" Width="100%" OnRowDataBound="gridResultEnderecos_RowDataBound">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Logradouro" DataField="Logradouro">
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="gridCadastralItem"
                                                                Wrap="False" />
                                                            <HeaderStyle CssClass="gridCadastralHeader" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Nº." DataField="Numero">
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridCadastralItem" />
                                                            <HeaderStyle CssClass="gridCadastralHeader" HorizontalAlign="Center" Width="60px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Complemento" DataField="Complemento">
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridCadastralItem" />
                                                            <HeaderStyle CssClass="gridCadastralHeader" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Bairro" DataField="Bairro">
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridCadastralItem"
                                                                Wrap="False" />
                                                            <HeaderStyle CssClass="gridCadastralHeader" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="CEP" DataField="CEP">
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridCadastralItem" />
                                                            <HeaderStyle CssClass="gridCadastralHeader" HorizontalAlign="Center" Width="110px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Cidade" DataField="Cidade">
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" CssClass="gridCadastralItem"
                                                                Wrap="False" />
                                                            <HeaderStyle CssClass="gridCadastralHeader" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="UF" DataField="UF">
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridCadastralItem" />
                                                            <HeaderStyle CssClass="gridCadastralHeader" HorizontalAlign="Center" Width="50px" />
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
                                                <asp:Label ID="Label21" runat="server" Text="Telefone(s)" Style="font-weight: normal;
                                                    font-size: 20px;" CssClass="lblTituloDadosVeiculo"></asp:Label>
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:GridView ID="gridResultTelefones" runat="server" AutoGenerateColumns="False"
                                                    EnableModelValidation="True" Width="100%" OnRowDataBound="gridResultTelefones_RowDataBound">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="DDD" DataField="DDD">
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridCadastralItem"
                                                                Width="100px" />
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
                                                <asp:Label ID="Label6" runat="server" Text="Sócio(s) desta Empresa" Style="font-weight: normal;
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
                                                        <asp:TemplateField HeaderText="CPF/CNPJ">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="linkCPFCNPJ" runat="server" Target="_blank">HyperLink</asp:HyperLink>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="250px" VerticalAlign="Middle" CssClass="gridCadastralHeader" HorizontalAlign="Center"/>
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridCadastralItem" Wrap="False" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="NOME DO SÓCIO">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="linkNOME" runat="server" Target="_blank">HyperLink</asp:HyperLink>
                                                            </ItemTemplate>
                                                            <HeaderStyle VerticalAlign="Middle" CssClass="gridCadastralHeader" HorizontalAlign="Center"/>
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridCadastralItem" Wrap="False" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="QUALIFICAÇÃO">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="linkQualificacao" runat="server" Target="_blank">HyperLink</asp:HyperLink>
                                                            </ItemTemplate>
                                                            <HeaderStyle VerticalAlign="Middle" CssClass="gridCadastralHeader" HorizontalAlign="Center"/>
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridCadastralItem" Wrap="False" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="DATA DE ENTRADA NA SOCIEDADE">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="linkDataEntradaSociedade" runat="server" Target="_blank">HyperLink</asp:HyperLink>
                                                            </ItemTemplate>
                                                            <HeaderStyle VerticalAlign="Middle" CssClass="gridCadastralHeader" HorizontalAlign="Center"/>
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridCadastralItem" Wrap="False" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="PARTICIPAÇÃO">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="linkParticipacao" runat="server" Target="_blank">HyperLink</asp:HyperLink>
                                                            </ItemTemplate>
                                                            <HeaderStyle VerticalAlign="Middle" CssClass="gridCadastralHeader" HorizontalAlign="Center"/>
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridCadastralItem" Wrap="False" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="DocumentoSocio" DataField="DocumentoSocio" />
                                                        <asp:BoundField HeaderText="NomeSocio" DataField="NomeSocio"/>
                                                        <asp:BoundField HeaderText="Qualificacao" DataField="Qualificacao"/>
                                                        <asp:BoundField HeaderText="DataEntradaSociedade" DataField="DataEntradaSociedade"/>
                                                        <asp:BoundField HeaderText="ValorParticipacao" DataField="ValorParticipacao"/>
                                                        <asp:BoundField HeaderText="TipoPessoa" DataField="TipoPessoa"/>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                &nbsp;</td>
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
