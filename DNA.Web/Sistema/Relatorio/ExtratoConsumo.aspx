<%@ Page Title="" Language="C#" MasterPageFile="~/PrincipalAutenticada.Master" AutoEventWireup="true"
    CodeBehind="ExtratoConsumo.aspx.cs" Inherits="DNA.Web.Sistema.Relatorio.ExtratoConsumo" %>

<%@ MasterType VirtualPath="~/PrincipalAutenticada.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <div style="width: 96%;" class="divResultadoPesquisaVeiculos">
        <asp:Label ID="Label10" runat="server" Text="Filtro" Style="font-weight: normal;
            font-size: 20px;"></asp:Label>
        <hr />
    </div>
    <div style="width: 800px;">
        <table border="0" cellpadding="1" cellspacing="1">
            <tr style="height: 35px">
                <td style="width: 10px;">
                    &nbsp;
                </td>
                <td style="width: 100px;">
                    <asp:Label ID="Label2" runat="server" Text="DATA INICIAL:" Font-Size="16px"></asp:Label>
                </td>
                <td style="width: 220px;">
                    <asp:TextBox ID="txtDataInicial" runat="server" Font-Size="16px" Style="text-align: center;"
                        ValidationGroup="groupValida"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDataInicial"
                        ErrorMessage="Informe a Data Incial" ValidationGroup="groupValida">*</asp:RequiredFieldValidator>
                    &nbsp;<img id="imgDataInicio" alt="" onclick="dp_cal1.toggle();" src="../../images/calendario.png"
                        title="Abrir Calendário" style="position: relative; top: 3px; cursor: pointer;
                        left: -45px;" />
                </td>
                <td style="width: 100px; text-align: right">
                    <asp:Label ID="Label1" runat="server" Text="DATA FINAL:" Font-Size="16px"></asp:Label>
                </td>
                <td style="width: 220px;">
                    <asp:TextBox ID="txtDataFinal" runat="server" Font-Size="16px" Style="text-align: center;"
                        ValidationGroup="groupValida" TabIndex="1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Informe a Data Final"
                        ControlToValidate="txtDataFinal" ValidationGroup="groupValida">*</asp:RequiredFieldValidator>
                    &nbsp;<img id="imgDataFim" alt="" onclick="dp_cal2.toggle();" src="../../images/calendario.png"
                        title="Abrir Calendário" style="cursor: pointer; position: relative; top: 3px;
                        left: -45px;" />
                </td>
            </tr>
            <tr style="height: 35px">
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="lblUserAtivo" runat="server" Text="STATUS:" Font-Size="16px"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlStatus" runat="server" Font-Size="14px" Style="height: 28px;
                        width: 175px; margin-left: 2px;" TabIndex="2">
                        <asp:ListItem Value="0">TODOS</asp:ListItem>
                        <asp:ListItem Value="1">SUCESSO</asp:ListItem>
                        <asp:ListItem Value="2">ERRO</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="text-align: right">
                    &nbsp;<asp:Label ID="lblUserAtivo0" runat="server" Text="PRODUTOS:" Font-Size="16px"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlProdutos" runat="server" Font-Size="14px" Style="height: 28px;
                        width: 175px; margin-left: 2px;" TabIndex="2">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="height: 40px;">
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
                <td align="center" style="position: relative; right: 10px;">
                    <asp:Button Text="Pesquisar" runat="server" ToolTip="Pesquisar..." CssClass="btnPesquisar"
                        ID="btnPesquisar" BorderStyle="None" TabIndex="0" OnClick="btnPesquisar_Click" />
                </td>
            </tr>
        </table>
        <br />
    </div>
    <div id="divListarSolicitacoes" runat="server" class="table-style">
        <div style="width: 96%;" class="divResultadoPesquisaVeiculos">
            <asp:Label ID="Label3" runat="server" Text="Resultado" Style="font-weight: normal;
                font-size: 20px;"></asp:Label>
            <hr />
        </div>
        <div id="divMensagemRetorno" runat="server" style="width: 1000px; text-align: center;">
            <asp:Label ID="lblMensagemRetorno" runat="server" CssClass="LabelMensagemRetorno"
                Visible="false" Text="" Style="font-weight: normal; font-size: 20px;"></asp:Label>
        </div>
        <div id="divDetalhesRetorno" runat="server" style="width: 1000px;">
            <asp:Label ID="lblTotalPesquisas" runat="server" Style="font-weight: normal; font-size: 16px;"></asp:Label>
            <asp:Label ID="Label4" runat="server" Text=" | " Style="font-weight: normal; font-size: 16px;"></asp:Label>
            <asp:Label ID="Label5" runat="server" Text="EXPORTAR PARA: " Style="font-weight: normal;
                font-size: 16px;"></asp:Label>
            <asp:Label ID="Label6" runat="server" Text="EXCEL " Style="font-weight: normal; font-size: 16px;"></asp:Label>
            <asp:ImageButton ID="imgExportExcel" runat="server" ImageUrl="../../images/Excel18x18.png"
                Style="cursor: pointer;" ToolTip="Clique para fazer download do arquivo" OnClick="imgExportExcel_Click" />
        </div>
        <asp:GridView ID="gridResult" runat="server" AutoGenerateColumns="False" EnableModelValidation="True"
            CssClass="table-list" OnRowDataBound="gridResult_RowDataBound" Width="1000px">
            <Columns>
                <asp:TemplateField HeaderText="Status" FooterStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Image ID="imgCheckOk" runat="server" ImageUrl="../../images/check18x18.png" />
                        <asp:Image ID="imgError" runat="server" ImageUrl="../../images/Error18x18.png" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nº DA CONSULTA">
                    <ItemTemplate>
                        <asp:HyperLink ID="linkIdHistoricoConsulta" runat="server" ToolTip="Clique para visualizar"
                            Text='<%# Eval("IdHistoricoConsulta") %>'></asp:HyperLink>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="250px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PARÂMETRO PESQUISADO">
                    <ItemTemplate>
                        <asp:HyperLink ID="linkParametroPesquisado" runat="server" ToolTip="Clique para visualizar"
                            Text='<%# Eval("ParametroPesquisado") %>'></asp:HyperLink>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="250px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DATA DA PESQUISA">
                    <ItemTemplate>
                        <asp:HyperLink ID="linkDataHoraPesquisa" runat="server" ToolTip="Clique para visualizar"
                            Text='<%# Eval("DataSolicitacao") %>'></asp:HyperLink>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="250px" />
                </asp:TemplateField>
                <asp:BoundField DataField="LoginUsuarioSolicitante" HeaderText="LOGIN DO USUÁRIO" />
                <asp:BoundField DataField="NomeUsuarioSolicitante" HeaderText="NOME DO USUÁRIO" />
                <asp:BoundField DataField="NomeFantasiaCliente" HeaderText="NOME FANTASIA" />
                <asp:BoundField DataField="RazaoSocialCliente" HeaderText="RAZÃO SOCIAL" />
                <asp:TemplateField HeaderText="PRODUTO">
                    <ItemTemplate>
                        <asp:HyperLink ID="linkNomeProdutoConsultado" runat="server" ToolTip="Clique para visualizar"
                            Text='<%# Eval("NomeProdutoConsultado") %>'></asp:HyperLink>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="250px" />
                </asp:TemplateField>
                <asp:BoundField DataField="IdCliente" HeaderText="IdCliente" />
                <asp:BoundField DataField="StatusPesquisa" HeaderText="StatusPesquisa" />
                <asp:BoundField DataField="NomeInternoProdutoConsultado" HeaderText="NomeInternoProdutoConsultado" />
                <asp:BoundField DataField="StatusHistoricoPesquisa" HeaderText="StatusHistoricoPesquisa" />
                <asp:BoundField DataField="TipoParametroPesquisado" HeaderText="TipoParametroPesquisado" />
                <asp:BoundField DataField="IdProdutoPrecoPesquisado" HeaderText="IdProdutoPrecoPesquisado" />
            </Columns>
        </asp:GridView>
    </div>
    <div id="divEspacoBranco" style="height: 200px;" runat="server">
    </div>
    <br />
    .
</asp:Content>
