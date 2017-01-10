<%@ Page Title="" Language="C#" MasterPageFile="~/PrincipalAutenticada.Master" AutoEventWireup="true"
    CodeBehind="PerfilUsuario.aspx.cs" Inherits="DNA.Web.Sistema.PerfilUsuario" %>

<%@ MasterType VirtualPath="~/PrincipalAutenticada.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" href="../../../CSS/FTPFileUpload/bootstrap.min.css">
<link rel="stylesheet" href="../../../CSS/FTPFileUpload/blueimp-gallery.min.css">
    <div style="width: 100%;" class="divResultadoPesquisaVeiculos">
        <asp:Label ID="Label10" runat="server" Text="Dados da Empresa" Style="font-weight: normal;
            font-size: 20px;"></asp:Label>
        <hr />
    </div>
    <div id="divDadosEmpresa" runat="server" style="height: 100%;">
        <table border="0" cellpadding="1" cellspacing="1" width="100%">
            <tr style="height:35px; vertical-align:middle;">
                <td class="tabelaColunaLabelResultadoCadastral" style="vertical-align:middle;">
                    <asp:Label ID="Label4" runat="server" Text="CNPJ: "></asp:Label>
                </td>
                <td class="tabelaColunaResultadoCadastral" 
                    style="vertical-align:middle;">
                    <asp:Label ID="lblCNPJ" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr style="height:35px; vertical-align:middle;">
                <td class="tabelaColunaLabelResultadoCadastral" style="vertical-align:middle;">
                    <asp:Label ID="Label423" runat="server" Text="RAZÃO SOCIAL: "></asp:Label>
                </td>
                <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" style="vertical-align:middle;">
                    <asp:Label ID="lblRazaoSocial" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr style="height:35px; vertical-align:middle;">
                <td class="tabelaColunaLabelResultadoCadastral" style="vertical-align:middle;">
                    <asp:Label ID="lblRGTitulo" runat="server" Text="NOME FANTASIA:"></asp:Label>
                </td>
                <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" style="vertical-align:middle;">
                    <asp:Label ID="lblNomeFantasia" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr style="height:35px; vertical-align:middle;">
                <td class="tabelaColunaLabelResultadoCadastral" style="vertical-align:middle;">
                    <asp:Label ID="lblRGTitulo0" runat="server" Text="LOGRADOURO:"></asp:Label>
                </td>
                <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" style="vertical-align:middle;">
                    <asp:Label ID="lblLogradouro" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr style="height:35px; vertical-align:middle;">
                <td class="tabelaColunaLabelResultadoCadastral" style="vertical-align:middle;"> 
                    <asp:Label ID="Label422" runat="server" Text="NÚMERO:"></asp:Label>
                </td>
                <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" style="vertical-align:middle;">
                    <asp:Label ID="lblEnderecoNumero" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr style="height:35px; vertical-align:middle;">
                <td class="tabelaColunaLabelResultadoCadastral" style="vertical-align:middle;">
                    <asp:Label ID="lblRGTitulo1" runat="server" Text="COMPLEMENTO:"></asp:Label>
                </td>
                <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" style="vertical-align:middle;">
                    <asp:Label ID="lblEnderecoComplemento" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr style="height:35px; vertical-align:middle;">
                <td class="tabelaColunaLabelResultadoCadastral" style="vertical-align:middle;">
                    <asp:Label ID="Label15" runat="server" Text="BAIRRO:"></asp:Label>
                </td>
                <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" style="vertical-align:middle;">
                    <asp:Label ID="lblBairro" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr style="height:35px; vertical-align:middle;">
                <td class="tabelaColunaLabelResultadoCadastral" style="vertical-align:middle;">
                    <asp:Label ID="Label5" runat="server" Text="CIDADE:"></asp:Label>
                </td>
                <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" style="vertical-align:middle;">
                    <asp:Label ID="lblCidade" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr style="height:35px; vertical-align:middle;">
                <td class="tabelaColunaLabelResultadoCadastral" style="vertical-align:middle;">
                    <asp:Label ID="Label424" runat="server" Text="UF:"></asp:Label>
                </td>
                <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" style="vertical-align:middle;">
                    <asp:Label ID="lblUF" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr style="height:35px; vertical-align:middle;">
                <td class="tabelaColunaLabelResultadoCadastral" style="vertical-align:middle;">
                    <asp:Label ID="Label426" runat="server" Text="CEP:"></asp:Label>
                </td>
                <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" style="vertical-align:middle;">
                    <asp:Label ID="lblCEP" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr style="height:35px; vertical-align:middle;">
                <td class="tabelaColunaLabelResultadoCadastral" style="vertical-align:middle;">
                    <asp:Label ID="Label24" runat="server" Text="E-MAIL 1:"></asp:Label>
                </td>
                <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" style="vertical-align:middle;">
                    <asp:Label ID="lblEmail1" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr style="height:35px; vertical-align:middle;">
                <td class="tabelaColunaLabelResultadoCadastral" style="vertical-align:middle;">
                    <asp:Label ID="Label27" runat="server" Text="E-MAIL 2:"></asp:Label>
                </td>
                <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" style="vertical-align:middle;">
                    <asp:Label ID="lblEmail2" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr style="height:35px; vertical-align:middle;">
                <td class="tabelaColunaLabelResultadoCadastral" style="vertical-align:middle;">
                    <asp:Label ID="Label28" runat="server" Text="TELEFONE 1:"></asp:Label>
                </td>
                <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" style="vertical-align:middle;">
                    <asp:Label ID="lblTelefoneRes" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr style="height:35px; vertical-align:middle;">
                <td class="tabelaColunaLabelResultadoCadastral" style="vertical-align:middle;">
                    <asp:Label ID="Label30" runat="server" Text="TELEFONE 2:"></asp:Label>
                </td>
                <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" style="vertical-align:middle;">
                    <asp:Label ID="lblTelefoneCom" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr style="height:35px; vertical-align:middle;">
                <td class="tabelaColunaLabelResultadoCadastral" style="vertical-align:middle;">
                    <asp:Label ID="Label32" runat="server" Text="CELULAR:"></asp:Label>
                </td>
                <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" style="vertical-align:middle;">
                    <asp:Label ID="lblCelular" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr style="height:35px; vertical-align:middle;">
                <td class="tabelaColunaLabelResultadoCadastral" style="vertical-align:middle;">
                    <asp:Label ID="Label29" runat="server" Text="DATA DE CADASTRO:"></asp:Label>
                </td>
                <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" style="vertical-align:middle;">
                    <asp:Label ID="lblDataCadastro" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr style="height:90px; vertical-align:middle;">
                <td class="tabelaColunaLabelResultadoCadastral" style="vertical-align:middle;">
                    <asp:Label ID="Label31" runat="server" Text="OBSERVAÇÃO:"></asp:Label>
                </td>
                <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" style="vertical-align:middle;">
                    <asp:TextBox ID="txtObservacao" runat="server" TextMode="MultiLine" style="height:80px; width:400px; background-color: rgb(240, 240, 240);"></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div style="width: 100%;" class="divResultadoPesquisaVeiculos">
        <asp:Label ID="Label21" runat="server" Text="Dados do Usuário" Style="font-weight: normal;
            font-size: 20px;"></asp:Label>
        <hr />
    </div>
    <div id="divDadosUsuario" runat="server" style="height: 100%;">
        <table border="0" cellpadding="1" cellspacing="1" width="100%">
            <tr style="height:35px; vertical-align:middle;">
                <td class="tabelaColunaLabelResultadoCadastral" style="vertical-align:middle;">
                    <asp:Label ID="Label1" runat="server" Text="NOME: "></asp:Label>
                </td>
                <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" style="vertical-align:middle;">
                    <asp:Label ID="lblNomeUsuario" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr style="height:35px; vertical-align:middle;">
                <td class="tabelaColunaLabelResultadoCadastral" style="vertical-align:middle;">
                    <asp:Label ID="Label3" runat="server" Text="LOGIN:"></asp:Label>
                </td>
                <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" style="vertical-align:middle;">
                    <asp:Label ID="lblLoginUsuario" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr style="height:35px; vertical-align:middle;">
                <td class="tabelaColunaLabelResultadoCadastral" style="vertical-align:middle;">
                    <asp:Label ID="Label7" runat="server" Text="E-MAIL 1:"></asp:Label>
                </td>
                <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" style="vertical-align:middle;">
                    <asp:Label ID="lblEmail1Usuario" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr style="height:35px; vertical-align:middle;">
                <td class="tabelaColunaLabelResultadoCadastral" style="vertical-align:middle;">
                    <asp:Label ID="Label9" runat="server" Text="E-MAIL 2:"></asp:Label>
                </td>
                <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" style="vertical-align:middle;">
                    <asp:Label ID="lblEmail2Usuario" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr style="height:35px; vertical-align:middle;">
                <td class="tabelaColunaLabelResultadoCadastral" style="vertical-align:middle;">
                    <asp:Label ID="Label12" runat="server" Text="DATA DE CADASTRO:"></asp:Label>
                </td>
                <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" style="vertical-align:middle;">
                    <asp:Label ID="lblDataCadastroUsuario" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr style="height:35px; vertical-align:middle;">
                <td class="tabelaColunaLabelResultadoCadastral" style="vertical-align:middle;">
                    <asp:Label ID="Label14" runat="server" Text="ÚLTIMA ALTERAÇÃO:"></asp:Label>
                </td>
                <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" style="vertical-align:middle;">
                    <asp:Label ID="lblUltimaAlteracaoUsuario" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr style="height:90px; vertical-align:middle;">
                <td class="tabelaColunaLabelResultadoCadastral" style="vertical-align:middle;">
                    <asp:Label ID="Label17" runat="server" Text="PRODUTOS LIBERADOS:"></asp:Label>
                </td>
                <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado"  style="vertical-align:middle;">
                    <asp:TextBox ID="txtProdutosUsuario" runat="server" TextMode="MultiLine"  
                        style="height:80px; width:400px;background-color: rgb(240, 240, 240);"></asp:TextBox>
                </td>
            </tr>
            <tr style="height:90px; vertical-align:middle;">
                <td class="tabelaColunaLabelResultadoCadastral" style="vertical-align:middle;">
                    <asp:Label ID="Label19" runat="server" Text="OBSERVAÇÃO:"></asp:Label>
                </td>
                <td class="tabelaColunaResultadoCadastral tabelaColunaResultadoAgregado" style="vertical-align:middle;">
                    <asp:TextBox ID="txtObservacaoUsuario" runat="server" TextMode="MultiLine" 
                        style="height:80px; width:400px;background-color: rgb(240, 240, 240);"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div style="width: 100%;" class="divResultadoPesquisaVeiculos">
        <asp:Label ID="Label22" runat="server" Text="Alterar Senha" Style="font-weight: normal;
            font-size: 20px;"></asp:Label>
        <hr />
    </div>
    <table border="0" cellpadding="1" cellspacing="1" width="100%">
            <tr style="height:40px;">
                <td class="tabelaColunaLabelResultadoCadastral" style="vertical-align:middle; width:355px;">
                    <asp:Label ID="Label23" runat="server" Text="SENHA ATUAL:"></asp:Label>
                </td>
                <td class="tabelaColunaResultadoCadastral" style="vertical-align:middle;">
                    <asp:TextBox ID="txtSenhaAtual" runat="server" MaxLength="20" TextMode="Password"
                        Style="color: #000; width: 227px; text-align: LEFT; text-transform: uppercase;
                        font-family: 'Segoe UI', 'Open Sans', Arial, sans-serif; text-decoration: none;
                        font-size: 20px;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtSenhaAtual" ErrorMessage="INFORME SEU SENHA ATUAL"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr style="height:40px;">
                <td class="tabelaColunaLabelResultadoCadastral" style="vertical-align:middle;">
                    <asp:Label ID="Label25" runat="server" Text="NOVA SENHA:"></asp:Label>
                </td>
                <td class="tabelaColunaResultadoCadastral" style="vertical-align:middle;">
                    <asp:TextBox ID="txtNovaSenha" runat="server" MaxLength="20" TextMode="Password"
                        Style="color: #000; width: 227px; text-align: LEFT; text-transform: uppercase;
                        font-family: 'Segoe UI', 'Open Sans', Arial, sans-serif; text-decoration: none;
                        font-size: 20px;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtNovaSenha" ErrorMessage="DIGITE SUA NOVA SENHA"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr style="height:40px;">
                <td class="tabelaColunaLabelResultadoCadastral" style="vertical-align:middle;">
                    <asp:Label ID="Label26" runat="server" Text="CONFIRME A NOVA SENHA:"></asp:Label>
                </td>
                <td class="tabelaColunaResultadoCadastral" style="vertical-align:middle;">
                    <asp:TextBox ID="txtConfirmaNovaSenha" runat="server" MaxLength="20" TextMode="Password"
                        Style="color: #000; width: 227px; text-align: LEFT; text-transform: uppercase;
                        font-family: 'Segoe UI', 'Open Sans', Arial, sans-serif; text-decoration: none;
                        font-size: 20px;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtConfirmaNovaSenha" ErrorMessage="CONFIRME A NOVA SENHA"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr style="height:21px;">
                <td class="" style="vertical-align:middle;">
                    &nbsp;</td>
                <td class="" style="vertical-align:middle;">
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToCompare="txtNovaSenha" ControlToValidate="txtConfirmaNovaSenha" 
                        ErrorMessage="A NOVA SENHA E A CONFIRMAÇÃO DEVEM SER IGUAIS"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="" style="vertical-align:middle;">
                    &nbsp;</td>
                <td class="">
                <asp:Button ID="btnSalvarSenha" runat="server" Text="Salvar" 
                        Style="cursor: pointer;margin-left: 20px; margin-top: 10px;" ToolTip="Salvar"
                                            CssClass="btn btn-success" 
                        OnDataBinding="PostBackBind_DataBinding" onclick="btnSalvarSenha_Click" />
                <asp:Button ID="btnCancelarSenha" runat="server" Text="Cancelar"
                        Style="cursor: pointer;margin-left: 30px; margin-top: 10px;" ToolTip="Cancelar" CssClass="btn btn-danger" 
                        OnDataBinding="PostBackBind_DataBinding" OnClientClick="javascript:document.getElementById('ctl00_head_txtSenhaAtual').value=''; javascript:document.getElementById('ctl00_head_txtNovaSenha').value='';javascript:document.getElementById('ctl00_head_txtConfirmaNovaSenha').value=''; document.getElementById('ctl00_head_txtSenhaAtual').focus(); return false;" />
                
                </td>
            </tr>
    </table>
<br />
<br />
<br />
<br />
</asp:Content>
