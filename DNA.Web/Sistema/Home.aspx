<%@ Page Title="" Language="C#" MasterPageFile="~/PrincipalAutenticada.Master" AutoEventWireup="true"
    CodeBehind="Home.aspx.cs" Inherits="DNA.Web.Sistema.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <div style="width: 95%;" class="divResultadoPesquisaVeiculos">
        <label for="lblDescricaoCategoriaProdutos" style="font-weight: normal; font-size: 20px;">
            Produtos Online
        </label>
        <hr />
    </div>
    <br />
    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="margin-left:-20px;">
        <tr align="center">
            <td>
                <div style="text-align: left;" class="btnDivPrincipal btnDivPrincipal-1 btnDivPrincipal-1a"
                    id="btnDivPrincipalCadastralPF" runat="server">
                    <asp:ImageButton ID="imgLinkBtnCadastralPF" ToolTip="Clique para fazer sua pesquisa"
                        runat="server" 
                        ImageUrl='../Images/Produtos/BotaoProdutoCadastralVermelho.png' 
                        onclick="imgLinkBtnCadastralPF_Click" />
                    <div id="divPrincipalDescProdutoCadastralPF" runat="server" style="color: #fff; text-transform: uppercase;
                        font-family: 'Segoe UI', 'Open Sans', Arial, sans-serif; text-decoration: none;
                        font-size: 18px; height: 100px; width: 150px; position: relative; top: -150px;
                        left: 160px; text-align: left;">
                        <asp:LinkButton CssClass="TextoBotaoProdutos" ID="linkDescProdutosPF" Style="z-index: 103;"
                            runat="server" Text='Produtos Cadastrais PF' onclick="linkDescProdutosPF_Click"></asp:LinkButton>
                    </div>
                    <div id="divPrincipalNomeProdutoCadastralPF" runat="server" style="color: #fff; font-family: 'Segoe UI', 'Open Sans', Arial, sans-serif;
                        text-decoration: none; font-size: 12px; width: 310px; position: relative; top: -130px;
                        left: 20px;">
                        <asp:LinkButton CssClass="TextoBotaoProdutos" ID="linkNomeProdutoPF" Style="z-index: 103;"
                            runat="server" Text='Produtos Cadastrais Pessoa Física' onclick="linkNomeProdutoPF_Click"></asp:LinkButton>
                    </div>
                </div>
            </td>
            <td>
                <div style="text-align: left;" class="btnDivPrincipal btnDivPrincipal-1 btnDivPrincipal-1a"
                    id="btnDivPrincipalCadastralPJ" runat="server">
                    <asp:ImageButton ID="imgLinkBtnCadastralPJ" ToolTip="Clique para fazer sua pesquisa"
                        runat="server" 
                        ImageUrl='../Images/Produtos/PrincipalPesquisaPJRoxo.png' 
                        onclick="imgLinkBtnCadastralPJ_Click" />
                    <div id="divPrincipalDescProdutoCadastralPJ" runat="server" style="color: #fff; text-transform: uppercase;
                        font-family: 'Segoe UI', 'Open Sans', Arial, sans-serif; text-decoration: none;
                        font-size: 18px; height: 100px; width: 150px; position: relative; top: -150px;
                        left: 160px; text-align: left;">
                        <asp:LinkButton CssClass="TextoBotaoProdutos" ID="linkDescProdutosPJ" Style="z-index: 103;"
                            runat="server" Text='Produtos Cadastrais PJ' onclick="linkDescProdutosPJ_Click"></asp:LinkButton>
                    </div>
                    <div id="divPrincipalNomeProdutoCadastralPJ" runat="server" style="color: #fff; font-family: 'Segoe UI', 'Open Sans', Arial, sans-serif;
                        text-decoration: none; font-size: 12px; width: 310px; position: relative; top: -130px;
                        left: 20px;">
                        <asp:LinkButton CssClass="TextoBotaoProdutos" ID="linkNomeProdutoPJ" Style="z-index: 103;"
                            runat="server" Text='Produtos Cadastrais Pessoa Jurídica' onclick="linkNomeProdutoPJ_Click"></asp:LinkButton>
                    </div>
                </div>
            </td>
            
        </tr>
        <tr align="center">
            <td>
                <div style="text-align: left;" class="btnDivPrincipal btnDivPrincipal-1 btnDivPrincipal-1a"
                    id="btnDivPrincipalVeicular" runat="server">
                    <asp:ImageButton ID="imgLinkBtnVeicular" ToolTip="Clique para fazer sua pesquisa"
                        runat="server" ImageUrl='../Images/Produtos/BotaoVeiculoAzul.png' 
                        onclick="imgLinkBtnVeicular_Click"/>
                    <div id="divPrincipalDescProdutoVeicular" runat="server" style="color: #fff; text-transform: uppercase; font-family: 'Segoe UI', 'Open Sans', Arial, sans-serif;
                        text-decoration: none; font-size: 18px; height: 100px; width: 150px; position: relative;
                        top: -150px; left: 160px; text-align: left;">
                        <asp:LinkButton CssClass="TextoBotaoProdutos" ID="linkDescProdutosVeiculares" Style="z-index: 103;"
                            runat="server" Text='Produtos Veiculares'></asp:LinkButton>
                    </div>
                    <div id="divPrincipalNomeProdutoVeicular" runat="server" style="color: #fff; font-family: 'Segoe UI', 'Open Sans', Arial, sans-serif;
                        text-decoration: none; font-size: 12px; width: 310px; position: relative; top: -130px;
                        left: 20px;">
                        <asp:LinkButton CssClass="TextoBotaoProdutos" ID="linkNomeProdutoVeicular" Style="z-index: 103;"
                            runat="server" Text='Produtos Veiculares'></asp:LinkButton>
                    </div>
                </div>
            </td>
            <td>
                <div style="text-align: left;" class="btnDivPrincipal btnDivPrincipal-1 btnDivPrincipal-1a"
                    id="btnDivPrincipalFTP" runat="server">
                    <asp:ImageButton ID="imgLinkBtnFTP" ToolTip="Clique para fazer sua pesquisa"
                        runat="server" ImageUrl='../Images/Produtos/BotaoFTPVerde.png' 
                        onclick="imgLinkBtnFTP_Click" />
                    <div id="divPrincipalDescProdutoFTP" runat="server" style="color: #fff; text-transform: uppercase; font-family: 'Segoe UI', 'Open Sans', Arial, sans-serif;
                        text-decoration: none; font-size: 18px; height: 100px; width: 150px; position: relative;
                        top: -150px; left: 160px; text-align: left;">
                        <asp:LinkButton CssClass="TextoBotaoProdutos" ID="linkDescFTP" Style="z-index: 103;"
                            runat="server" Text='Gerenciamento de Arquivos Enviados e Processados' 
                            onclick="linkDescFTP_Click"></asp:LinkButton>
                    </div>
                    <div id="divPrincipalNomeProdutoFTP" runat="server" style="color: #fff; font-family: 'Segoe UI', 'Open Sans', Arial, sans-serif;
                        text-decoration: none; font-size: 12px; width: 310px; position: relative; top: -130px;
                        left: 20px;">
                        <asp:LinkButton CssClass="TextoBotaoProdutos" ID="linkNomeProdutoFTP" Style="z-index: 103;"
                            runat="server" Text='FTP'></asp:LinkButton>
                    </div>
                </div>
            </td>
            
        </tr>
    </table>
    <div id="divEspacoBranco" style="height: 100px;" runat="server">
    </div>
</asp:Content>
