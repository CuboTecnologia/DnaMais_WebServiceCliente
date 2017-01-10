<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucLoginUsuario.ascx.cs" Inherits="DNA.Web.Controles.ucLoginUsuario" %>

<div id="divLogar" runat="server" style="display: block;">
    <div id="divCampoLoginUsuario">
        <asp:Label ID="lblLoginUsuario" Text="Login" CssClass="blocklabel" runat="server" />
        <asp:TextBox ID="txtLoginUsuario" runat="server" CssClass="input_login" MaxLength="200"
            TabIndex="0" Style="text-transform: uppercase;" />
    </div>
    <div id="divCampoLoginSenha">
        <asp:Label ID="lblSenha" Text="Senha" class="blocklabel" runat="server" />
        <asp:TextBox ID="txtSenhaUsuario" runat="server" CssClass="input_login" TextMode="Password"
            MaxLength="50" TabIndex="0" />
    </div>
    <div id="divBotaoOkLogin">
        <asp:Button Text="Entrar" runat="server" ToolTip="Clique para ser autenticado no sistema."
            CssClass="btnEntrar" ID="btnOk" BorderStyle="None" TabIndex="0" 
            onclick="btnOk_Click" />
        <!--<a href="#" class="but_ok_3" title="Clique para ser autenticado no sistema.">Entrar</a>-->
    </div>
</div>
<div id="divLogado" runat="server" style="width: 450px; text-align: right; display: block;
    position: relative; left: 30px; top: 0; font-size: 14px;">
    <asp:Label Text="" runat="server" ID="lblNomeUsuarioLogado" style="color: #383838;"/>
    <br />
    <asp:Label Text="" runat="server" ID="lblDataAtual" style="color: #383838;"/>
    <br />
    <asp:Label Text="" runat="server" ID="lblNumeroIPCliente" style="color: #383838;"/>
    <br />
    <a href="/Logoff.aspx" title="Clique para deslogar desta conta." style="font-size:9pt; position:relative;top:-5px;left:-5px;">[Sair]</a>
<%--    <nav id="navMenuUsuario" style="display:none;">
        <ul>
            <li id="liPainelControle"><a href="index.html"><asp:Label Text="Painel de Controle"  style="position:relative; top:25px;" runat="server" ID="Label1" /></a>
            <li id="liPerfilUsuario"><a href="index.html" class=""><asp:Label Text="Perfil"  style="position:relative; top:25px;" runat="server" ID="Label2" /></a>
            <li id="liConsultas"><a href="index.html" class=""><asp:Label Text="Produtos"  style="position:relative; top:25px;" runat="server" ID="Label3" /></a>    
            <li id="liExtrato"><a href="index.html" class=""><asp:Label Text="Extrato"  style="position:relative; top:25px;" runat="server" ID="Label4" /></a> 
            <li id="liSair"><a href="index.html" class=""><asp:Label Text="Sair"  style="position:relative; top:25px;" runat="server" ID="Label5" /></a>   
            </li>
        </ul>
    </nav>--%>
</div>