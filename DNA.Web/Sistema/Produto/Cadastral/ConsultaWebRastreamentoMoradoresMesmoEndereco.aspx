<%@ Page Title="" Language="C#" MasterPageFile="~/PrincipalAutenticada.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="ConsultaWebRastreamentoMoradoresMesmoEndereco.aspx.cs" Inherits="DNA.Web.Sistema.Produto.Cadastral.ConsultaWebRastreamentoMoradoresMesmoEndereco" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function ValidaCampos() {
            
            var txtCep = document.getElementById("ctl00_head_txtCEP").value;
            
            var ddlUF = document.getElementById("ctl00_head_ddlUF");
            var strUF = ddlUF.options[ddlUF.selectedIndex].value;

            var ddlCidade = document.getElementById("ctl00_head_ddlCidade");
            var strCidade = ddlCidade.options[ddlCidade.selectedIndex].value;

            var txtBairro = document.getElementById("ctl00_head_txtBairro").value;
            var txtLogradouro = document.getElementById("ctl00_head_txtLogradouro").value;
            var txtNumero = document.getElementById("ctl00_head_txtNumero").value;

            if (strUF != "00" && strCidade != "00" && txtBairro != '' && txtLogradouro != '' && txtNumero != '') {
                ShowProgressAnimation();
            }
            else {
                return false; 
            }
        }

        function GetEnderecoByCEP(CEP) {
            if (CEP.length == 9) {
                ShowProgressAnimation();
                PageMethods.ConsualtaEnderecoByCEP(CEP, OnGetEnderecos);
                HideProgressAnimation();
            }
        }
        function OnGetEnderecos(result) {

            var UfEstado = result.UF + ' - ' + result.Estado;

            var ddlUF = document.getElementById("ctl00_head_ddlUF");
            var optionUF = document.createElement("option");
            optionUF.text = UfEstado;
            ddlUF.add(optionUF);
            document.getElementById('ctl00_head_ddlUF').selectedIndex = document.getElementById('ctl00_head_ddlUF').options.length-1;

            var ddlCidade = document.getElementById("ctl00_head_ddlCidade");
            var optionCidade = document.createElement("option");
            optionCidade.text = result.Cidade;
            ddlCidade.add(optionCidade);
            document.getElementById('ctl00_head_ddlCidade').selectedIndex = document.getElementById('ctl00_head_ddlCidade').options.length - 1;

            document.getElementById('ctl00_head_ddlUF').selectedIndex = document.getElementById('ctl00_head_ddlUF').options.length - 1;
            document.getElementById("ctl00_head_txtLogradouro").value = result.Logradouro;
            document.getElementById("ctl00_head_txtBairro").value = result.Bairro;

            document.getElementById("ctl00_head_hdnUfEstado").value = result.UF;
            document.getElementById("ctl00_head_hdnCidade").value = result.Cidade;

            document.getElementById("ctl00_head_ddlCidade").disabled = false;

        }
</script>
    <div id="divTituloFiltro" runat="server" style="width: 96%;" class="divResultadoPesquisaCadastral">
        <asp:Label ID="Label10" runat="server" Text="Filtro" Style="font-weight: normal;
            font-size: 20px;"></asp:Label>
        <hr />
    </div>
    <div style="width: 1020px;">
        <table id="tblFiltro" runat="server" border="0" cellpadding="1" cellspacing="1" width="100%">
            <tr>
                <td style="width: 220px;">
                    <asp:Label ID="Label433" runat="server" CssClass="LabelMensagemRetorno"
                        Visible="true" Text="CEP:" 
                        Style="font-weight: normal; font-size: 20px;color:#000;"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtCEP" runat="server" MaxLength="9"
                        Style="color: #000; width: 575px; text-align: center; text-transform: uppercase;
                        font-family: 'Segoe UI', 'Open Sans', Arial, sans-serif; text-decoration: none;
                        font-size: 20px;" Text="" onKeyPress="return digitos(event, this);" onKeyUp="Mascara('CEP',this,event); GetEnderecoByCEP(this.value);"></asp:TextBox>
                </td>
                <td align="left" valign="middle" style="width:205px;"> 

                    &nbsp;</td>
            </tr>
            <tr align="center" style="height:30px;">
                <td colspan="3">
                    <fieldset class="MensagemPesquisaFinalizada" style="position:relative; top: 8px; color:#000; width:200px; font: 13px Trebuchet MS, Arial, Helvetica, sans-serif;">
                        <legend>&nbsp; OU &nbsp;</legend>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label427" runat="server" CssClass="LabelMensagemRetorno"
                        Visible="true" Text="UF:" Style="font-weight: normal; font-size: 20px; color:#000;"></asp:Label>
                </td>
                <td align="left">
                    <input type="hidden" id="hdnUfEstado" name="hdnUfEstado" runat="server" />
                    <asp:UpdatePanel ID="updpUF" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlUF" runat="server" style="width: 580px; font-family: 'Segoe UI', 'Open Sans', Arial, sans-serif;
	                        text-decoration: none; font-size: 20px;" AutoPostBack="True" 
                            onselectedindexchanged="ddlUF_SelectedIndexChanged" 
                            ValidationGroup="groupValida">
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
	                        <asp:ListItem Value="07">DF - DISTRITO FEDERAL</asp:ListItem>
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
                        ControlToValidate="ddlUF" ErrorMessage="* SELECIONE O ESTADO" 
                        InitialValue="00" ForeColor="Red" ValidationGroup="groupValida"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label428" runat="server" CssClass="LabelMensagemRetorno"
                        Visible="true" Text="CIDADE:" Style="font-weight: normal; font-size: 20px;color:#000;"></asp:Label>
                </td>
                <td align="left">
                <input type="hidden" id="hdnCidade" name="hdnCidade" runat="server" />
                <asp:UpdatePanel ID="updpCidades" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlCidade" runat="server" style="width: 580px; font-family: 'Segoe UI', 'Open Sans', Arial, sans-serif;
	                            text-decoration: none; font-size: 20px;" AutoPostBack="false" 
                            ValidationGroup="groupValida">
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
                            InitialValue="00" ForeColor="Red" ValidationGroup="groupValida"></asp:RequiredFieldValidator>
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
                <td>
                    <asp:Label ID="Label429" runat="server" CssClass="LabelMensagemRetorno"
                        Visible="true" Text="BAIRRO:" 
                        Style="font-weight: normal; font-size: 20px;color:#000;"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtBairro" runat="server" MaxLength="100"
                        Style="color: #000; width: 575px; text-align: left; text-transform: uppercase;
                        font-family: 'Segoe UI', 'Open Sans', Arial, sans-serif; text-decoration: none;
                        font-size: 20px;" Text="" ValidationGroup="groupValida"></asp:TextBox>
                </td>
               <td align="left"  > 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                    ErrorMessage="* INFORME O BAIRRO" ControlToValidate="txtBairro" 
                            ForeColor="Red" ValidationGroup="groupValida"></asp:RequiredFieldValidator>
                        </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label430" runat="server" CssClass="LabelMensagemRetorno"
                        Visible="true" Text="LOGRADOURO:" 
                        Style="font-weight: normal; font-size: 20px;color:#000;"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtLogradouro" runat="server" MaxLength="100"
                        Style="color: #000; width: 575px; text-align: left; text-transform: uppercase;
                        font-family: 'Segoe UI', 'Open Sans', Arial, sans-serif; text-decoration: none;
                        font-size: 20px;" Text="" ValidationGroup="groupValida"></asp:TextBox>
                </td>
               <td align="left"  > 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                    ErrorMessage="* INFORME A RUA" ControlToValidate="txtLogradouro" ForeColor="Red" ValidationGroup="groupValida"></asp:RequiredFieldValidator>
                        </td>
            </tr>
            <tr align="center" style="height:30px;">
                <td colspan="3">
                    <fieldset class="MensagemPesquisaFinalizada" style="position:relative; top: 8px; color:#000; width:200px; font: 13px Trebuchet MS, Arial, Helvetica, sans-serif;">
                        <legend>&nbsp; E &nbsp;</legend>
                    </fieldset>
                </td>
            </tr>
    
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label434" runat="server" CssClass="LabelMensagemRetorno"
                        Visible="true" Text="NÚMERO:" 
                        Style="font-weight: normal; font-size: 20px;color:#000;"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtNumero" runat="server" MaxLength="10"
                        Style="color: #000; width: 575px; text-align: center; text-transform: uppercase;
                        font-family: 'Segoe UI', 'Open Sans', Arial, sans-serif; text-decoration: none;
                        font-size: 20px;" Text="" onKeyPress="return digitos(event, this);" 
                        ValidationGroup="groupValida"></asp:TextBox>
                </td>
               <td align="left"  > 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                    ErrorMessage="* INFORME O NÚMERO" ControlToValidate="txtNumero" 
                            ForeColor="Red" ValidationGroup="groupValida"></asp:RequiredFieldValidator>
                        </td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    <div>
                        <asp:Button Text="Pesquisar" runat="server" ToolTip="Pesquisar..." CssClass="btnPesquisar"
                            ID="btnPesquisar" BorderStyle="None" TabIndex="0" 
                            OnClientClick="ValidaCampos();" style="margin-right:10px;" 
                            ValidationGroup="groupValida" onclick="btnPesquisar_Click" />
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
                        <tr style="background-color: #fff;">
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="background-color: #fff;">
                            <td>
                                <asp:Label ID="Label12" runat="server" Text="Moradores no Mesmo Endereço" Style="font-weight: normal;
                                    font-size: 20px;"></asp:Label>
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="divResultPFPrata" runat="server" style="height: 100%;">
                                    <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                        <tr>
                                            <td colspan="4">
                                                <asp:GridView ID="gridResultMoradores" runat="server" AutoGenerateColumns="False"
                                                    EnableModelValidation="True" Width="100%" 
                                                    onrowdatabound="gridResult_RowDataBound" >
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Dados dos Moradores">
                                                            <ItemTemplate>
                                                                <table border="0" cellpadding="0" cellspacing="1">
                                                                    <tr>
                                                                        <td class="Coluna1">
                                                                            <asp:Label ID="lblCPFMorador" runat="server" Text="Número do CPF:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:HyperLink ID="linkCPF" runat="server" Target="_blank"><%# DataBinder.Eval(Container.DataItem, "CPF", "{0}") %></asp:HyperLink>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label1" runat="server" Text="Nome Completo:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblNomeMorador" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Nome", "{0}") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label4" runat="server" Text="Data de Nascimento:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblDataNascimentoMorador" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DataNascimento", "{0}") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label6" runat="server" Text="Nome da Mãe:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="Label7" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NomeMae", "{0}") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                            <HeaderStyle VerticalAlign="Middle" CssClass="gridCadastralHeader" HorizontalAlign="Left"/>
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="gridCadastralItem" Wrap="False" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="CPF" DataField="CPF" />
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
