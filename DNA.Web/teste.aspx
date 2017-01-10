<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="teste.aspx.cs" Inherits="DNA.Web.teste" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <script type="text/javascript">
        $("a#exportView").click(function () {
            alert('');
            var exportId = $('#serviceRules option:selected').attr("stream");
            var TakeHref = "http://onlinehomolog.dnamais.com.br/downteste.txt";
            document.getElementById("exportView").setAttribute("href", TakeHref);
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <a id="exportView" style="cursor:pointer">Export</a>
    <a href="http://onlinehomolog.dnamais.com.br/downteste.txt" download id="download">kkkkkkkkkkkk</a>
    
    </div>
    </form>
</body>
</html>
