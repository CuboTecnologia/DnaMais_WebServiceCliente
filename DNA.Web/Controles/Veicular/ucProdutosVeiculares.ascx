<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucProdutosVeiculares.ascx.cs" Inherits="DNA.Web.Controles.Veicular.ucProdutosVeiculares" %>

<div id="divProdutosVeiculares" runat="server" style="">
<div style=" width:565%;" class="divResultadoPesquisaVeiculos">
<label for="lblDescricaoCategoriaProdutos" style="font-weight: normal; font-size: 20px;">Produtos Veiculares</label>
<hr/>
</div>
<input type="hidden" id="hdCodigoProduto" runat="server" />
<input type="hidden" id="hdNomeInternoProduto" runat="server" />
<div id="divProdutosVeicularesResult" style="position:relative; left:-20px;">
<asp:DataList ID="dlProdutosVeiculares" runat="server" CellPadding="1" RepeatColumns="3"
    RepeatDirection="Horizontal" Font-Names="verdana" Font-Size="X-Small" 
        ForeColor="#333333" onitemdatabound="dlProdutosVeiculares_ItemDataBound" >
    <ItemTemplate>
        <input type="hidden" id="hdCodigoProdutoTEMP" runat="server" value='<%# Bind("IdPrecoProduto") %>' />
        <input type="hidden" id="hdNomeInternoProdutoTEMP" runat="server" value='<%# Bind("NomeInterno") %>' />
        <div class="btnDivPrincipal btnDivPrincipal-1 btnDivPrincipal-1a" id="btnDivPrincipal" runat="server">
            <asp:ImageButton ID="imgLinkBotao" ToolTip="Clique para fazer sua pesquisa" runat="server" ImageUrl='<%# Eval("LinkImagem1", "../{0}") %>' />
            <div id="divPrincipalDescProduto" runat="server" style="color:#fff; text-transform: uppercase;font-family: 'Segoe UI', 'Open Sans', Arial, sans-serif; text-decoration: none;font-size:18px; height:100px; width:150px; position:relative; top:-150px; left:160px;">
                <%--<label for="lblDescricao">Pesquisa de Veículos do Estado de São Paulo</label>--%>
                <asp:LinkButton CssClass="TextoBotaoProdutos" id="linkDescProdutos" style="Z-INDEX: 103;" runat="server" Text='<%# Bind("DescricaoProduto", "{0}") %>'></asp:LinkButton>
                <%--<asp:Label ID="lblDescricao" runat="server" Text='<%# Bind("DescricaoProduto", "{0}") %>'></asp:Label>--%>
            </div>
            <div id="divPrincipalNomeProduto" runat="server" style="color:#fff; font-family: 'Segoe UI', 'Open Sans', Arial, sans-serif; text-decoration: none;font-size:12px; width:310px; position:relative; top:-130px; left:20px;">
                <%--<asp:Label ID="lblNomeProduto" runat="server" Text='<%# Bind("NomeProduto") %>'></asp:Label>--%>
                <asp:LinkButton CssClass="TextoBotaoProdutos" id="linkNomeProduto" style="Z-INDEX: 103;" runat="server" Text='<%# Bind("NomeProduto", "{0}") %>'></asp:LinkButton>
            </div>
        </div>
    </ItemTemplate>
    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
    <SelectedItemStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
    <AlternatingItemStyle BorderStyle="Solid" BorderWidth="25px" />
    <ItemStyle BorderColor="White" BorderStyle="Solid" BorderWidth="25px" />
    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
</asp:DataList> 
</div>
</div>