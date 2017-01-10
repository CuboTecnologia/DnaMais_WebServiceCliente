<%@ Page Title="" Language="C#" MasterPageFile="~/PrincipalAutenticada.Master" AutoEventWireup="true"
    ValidateRequest="false" EnableEventValidation="false"
    CodeBehind="GerenciarArquivos.aspx.cs" Inherits="DNA.Web.Sistema.Produto.FTP.GerenciarArquivos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- INICIO - Referencias para o modulo de FTP -->
    <link rel="stylesheet" href="../../../CSS/FTPFileUpload/bootstrap.min.css">
    <link rel="stylesheet" href="../../../CSS/FTPFileUpload/blueimp-gallery.min.css">
    <!-- FIM - Referencias para o modulo de FTP -->
    <!---->
    <!-- INICIO - Incluindo novos campos de UPLOAD -->
    <script type="text/javascript">
        $(function () {
            $('#btnIncluirMaisArquivos').on('click', function () {
                //$('#tr1').css("display", "none");

                for (var i = 0; i < $('#tblUploadPrincipal tr').length; i++) {

                    if ($('#tblUploadPrincipal').find('#tr' + i).css('display') == 'none') {
                        $('#tr' + i).css("display", "block");

                        if ($('#tr' + i).attr('id') == 'tr10') {
                            $('#btnIncluirMaisArquivos').prop("disabled", true);
                        }

                        i = 100;
                    }
                }

            });
        })
    </script>
    <!-- FIM - Incluindo novos campos de UPLOAD -->
    <!---->
    <!-- INICIO - scripts Controle de tamanho do arquivo selecioado -->
    <script type="text/javascript">
        $(function () {
            $('#ctl00_head_fup1').bind('change', function () {

                $('#btnEnviar1').prop("disabled", false);
                $('#btnExcluir1').prop("disabled", false);
                $('#spamMaxMB1').text('');
                $('#pSize1').text('');

                var ext = $('#ctl00_head_fup1').val().split('.').pop().toLowerCase();
                if ($.inArray(ext, ['txt', 'xls', 'xlsx', 'ace', 'arc', 'arj', 'zip', 'rar', 'tar', '7zip', 'gzip', 'csv']) == -1) {
                    $('#btnEnviar1').prop("disabled", true);
                    $('#btnExcluir1').prop("disabled", true);
                    $('#spamMaxMB1').text('');
                    $('#pSize1').text('');
                    $('#ctl00_head_fup1').val('');
                    $('#ctl00_head_fup1').text('');

                    alert('O arquivo selecionado é inválido');
                }
                else {
                    var bytes = this.files[0].size;

                    if (typeof bytes !== 'number') {
                        return '';
                    }

                    if (bytes >= 1000000000) {
                        var result = (bytes / 1000000000).toFixed(2);
                        $('#pSize1').text(result + ' GB');

                        if (result > 200) {
                            $('#spamMaxMB1').text('(max. 200 MB)');
                            $('#btnEnviar1').prop("disabled", true);
                            $('#btnExcluir1').prop("disabled", true);
                        }
                        else {
                            $('#spamMaxMB1').text('');
                            $('#btnEnviar1').prop("disabled", false);
                            $('#btnExcluir1').prop("disabled", false);
                        }

                        return true;
                    }

                    if (bytes >= 1000000) {
                        var result = (bytes / 1000000).toFixed(2);
                        $('#pSize1').text(result + ' MB');

                        if (result > 200) {
                            $('#spamMaxMB1').text('(max. 200 MB)');
                            $('#btnEnviar1').prop("disabled", true);
                            $('#btnExcluir1').prop("disabled", true);
                        }
                        else {
                            $('#spamMaxMB1').text('');
                            $('#btnEnviar1').prop("disabled", false);
                            $('#btnExcluir1').prop("disabled", false);
                        }

                        return true;
                    }

                    return $('#pSize1').text((bytes / 1000).toFixed(2) + ' KB');
                }
            });

            $('#ctl00_head_fup2').bind('change', function () {

                $('#btnEnviar2').prop("disabled", false);
                $('#btnExcluir2').prop("disabled", false);
                $('#spamMaxMB2').text('');
                $('#pSize2').text('');

                var ext = $('#ctl00_head_fup2').val().split('.').pop().toLowerCase();
                if ($.inArray(ext, ['txt', 'xls', 'xlsx', 'ace', 'arc', 'arj', 'zip', 'rar', 'tar', '7zip', 'gzip', 'csv']) == -1) {
                    $('#btnEnviar2').prop("disabled", true);
                    $('#btnExcluir2').prop("disabled", true);
                    $('#spamMaxMB2').text('');
                    $('#pSize2').text('');
                    $('#ctl00_head_fup2').val('');
                    $('#ctl00_head_fup2').text('');

                    alert('O arquivo selecionado é inválido');
                }
                else {

                    var bytes = this.files[0].size;

                    if (typeof bytes !== 'number') {
                        return '';
                    }

                    if (bytes >= 1000000000) {
                        var result = (bytes / 1000000000).toFixed(2);
                        $('#pSize2').text(result + ' GB');

                        if (result > 200) {
                            $('#spamMaxMB2').text('(max. 200 MB)');
                            $('#btnEnviar2').prop("disabled", true);
                            $('#btnExcluir2').prop("disabled", true);
                        }
                        else {
                            $('#spamMaxMB2').text('');
                            $('#btnEnviar2').prop("disabled", false);
                            $('#btnExcluir2').prop("disabled", false);
                        }

                        return true;
                    }

                    if (bytes >= 1000000) {
                        var result = (bytes / 1000000).toFixed(2);
                        $('#pSize2').text(result + ' MB');

                        if (result > 200) {
                            $('#spamMaxMB2').text('(max. 200 MB)');
                            $('#btnEnviar2').prop("disabled", true);
                            $('#btnExcluir2').prop("disabled", true);
                        }
                        else {
                            $('#spamMaxMB2').text('');
                            $('#btnEnviar2').prop("disabled", false);
                            $('#btnExcluir2').prop("disabled", false);
                        }

                        return true;
                    }

                    return $('#pSize2').text((bytes / 1000).toFixed(2) + ' KB');
                }
            });

            $('#ctl00_head_fup3').bind('change', function () {

                $('#btnEnviar3').prop("disabled", false);
                $('#btnExcluir3').prop("disabled", false);
                $('#spamMaxMB3').text('');
                $('#pSize3').text('');

                var ext = $('#ctl00_head_fup3').val().split('.').pop().toLowerCase();
                if ($.inArray(ext, ['txt', 'xls', 'xlsx', 'ace', 'arc', 'arj', 'zip', 'rar', 'tar', '7zip', 'gzip', 'csv']) == -1) {
                    $('#btnEnviar3').prop("disabled", true);
                    $('#btnExcluir3').prop("disabled", true);
                    $('#spamMaxMB3').text('');
                    $('#pSize3').text('');
                    $('#ctl00_head_fup3').val('');
                    $('#ctl00_head_fup3').text('');

                    alert('O arquivo selecionado é inválido');
                }
                else {

                    var bytes = this.files[0].size;

                    if (typeof bytes !== 'number') {
                        return '';
                    }

                    if (bytes >= 1000000000) {
                        var result = (bytes / 1000000000).toFixed(2);
                        $('#pSize3').text(result + ' GB');

                        if (result > 200) {
                            $('#spamMaxMB3').text('(max. 200 MB)');
                            $('#btnEnviar3').prop("disabled", true);
                            $('#btnExcluir3').prop("disabled", true);
                        }
                        else {
                            $('#spamMaxMB3').text('');
                            $('#btnEnviar3').prop("disabled", false);
                            $('#btnExcluir3').prop("disabled", false);
                        }

                        return true;
                    }

                    if (bytes >= 1000000) {
                        var result = (bytes / 1000000).toFixed(2);
                        $('#pSize3').text(result + ' MB');

                        if (result > 200) {
                            $('#spamMaxMB3').text('(max. 200 MB)');
                            $('#btnEnviar3').prop("disabled", true);
                            $('#btnExcluir3').prop("disabled", true);
                        }
                        else {
                            $('#spamMaxMB3').text('');
                            $('#btnEnviar3').prop("disabled", false);
                            $('#btnExcluir3').prop("disabled", false);
                        }

                        return true;
                    }

                    return $('#pSize3').text((bytes / 1000).toFixed(2) + ' KB');
                }
            });

            $('#ctl00_head_fup4').bind('change', function () {

                $('#btnEnviar4').prop("disabled", false);
                $('#btnExcluir4').prop("disabled", false);
                $('#spamMaxMB4').text('');
                $('#pSize4').text('');

                var ext = $('#ctl00_head_fup4').val().split('.').pop().toLowerCase();
                if ($.inArray(ext, ['txt', 'xls', 'xlsx', 'ace', 'arc', 'arj', 'zip', 'rar', 'tar', '7zip', 'gzip', 'csv']) == -1) {
                    $('#btnEnviar4').prop("disabled", true);
                    $('#btnExcluir4').prop("disabled", true);
                    $('#spamMaxMB4').text('');
                    $('#pSize4').text('');
                    $('#ctl00_head_fup4').val('');
                    $('#ctl00_head_fup4').text('');

                    alert('O arquivo selecionado é inválido');
                }
                else {
                    var bytes = this.files[0].size;

                    if (typeof bytes !== 'number') {
                        return '';
                    }

                    if (bytes >= 1000000000) {
                        var result = (bytes / 1000000000).toFixed(2);
                        $('#pSize4').text(result + ' GB');

                        if (result > 200) {
                            $('#spamMaxMB4').text('(max. 200 MB)');
                            $('#btnEnviar4').prop("disabled", true);
                            $('#btnExcluir4').prop("disabled", true);
                        }
                        else {
                            $('#spamMaxMB4').text('');
                            $('#btnEnviar4').prop("disabled", false);
                            $('#btnExcluir4').prop("disabled", false);
                        }

                        return true;
                    }

                    if (bytes >= 1000000) {
                        var result = (bytes / 1000000).toFixed(2);
                        $('#pSize4').text(result + ' MB');

                        if (result > 200) {
                            $('#spamMaxMB4').text('(max. 200 MB)');
                            $('#btnEnviar4').prop("disabled", true);
                            $('#btnExcluir4').prop("disabled", true);
                        }
                        else {
                            $('#spamMaxMB4').text('');
                            $('#btnEnviar4').prop("disabled", false);
                            $('#btnExcluir4').prop("disabled", false);
                        }

                        return true;
                    }

                    return $('#pSize4').text((bytes / 1000).toFixed(2) + ' KB');
                }
            });

            $('#ctl00_head_fup5').bind('change', function () {

                $('#btnEnviar5').prop("disabled", false);
                $('#btnExcluir5').prop("disabled", false);
                $('#spamMaxMB5').text('');
                $('#pSize5').text('');

                var ext = $('#ctl00_head_fup5').val().split('.').pop().toLowerCase();
                if ($.inArray(ext, ['txt', 'xls', 'xlsx', 'ace', 'arc', 'arj', 'zip', 'rar', 'tar', '7zip', 'gzip', 'csv']) == -1) {
                    $('#btnEnviar5').prop("disabled", true);
                    $('#btnExcluir5').prop("disabled", true);
                    $('#spamMaxMB5').text('');
                    $('#pSize5').text('');
                    $('#ctl00_head_fup5').val('');
                    $('#ctl00_head_fup5').text('');

                    alert('O arquivo selecionado é inválido');
                }
                else {
                    var bytes = this.files[0].size;

                    if (typeof bytes !== 'number') {
                        return '';
                    }

                    if (bytes >= 1000000000) {
                        var result = (bytes / 1000000000).toFixed(2);
                        $('#pSize5').text(result + ' GB');

                        if (result > 200) {
                            $('#spamMaxMB5').text('(max. 200 MB)');
                            $('#btnEnviar5').prop("disabled", true);
                            $('#btnExcluir5').prop("disabled", true);
                        }
                        else {
                            $('#spamMaxMB5').text('');
                            $('#btnEnviar5').prop("disabled", false);
                            $('#btnExcluir5').prop("disabled", false);
                        }

                        return true;
                    }

                    if (bytes >= 1000000) {
                        var result = (bytes / 1000000).toFixed(2);
                        $('#pSize5').text(result + ' MB');

                        if (result > 200) {
                            $('#spamMaxMB5').text('(max. 200 MB)');
                            $('#btnEnviar5').prop("disabled", true);
                            $('#btnExcluir5').prop("disabled", true);
                        }
                        else {
                            $('#spamMaxMB5').text('');
                            $('#btnEnviar5').prop("disabled", false);
                            $('#btnExcluir5').prop("disabled", false);
                        }

                        return true;
                    }

                    return $('#pSize5').text((bytes / 1000).toFixed(2) + ' KB');
                }
            });

            $('#ctl00_head_fup6').bind('change', function () {

                $('#btnEnviar6').prop("disabled", false);
                $('#btnExcluir6').prop("disabled", false);
                $('#spamMaxMB6').text('');
                $('#pSize6').text('');

                var ext = $('#ctl00_head_fup6').val().split('.').pop().toLowerCase();
                if ($.inArray(ext, ['txt', 'xls', 'xlsx', 'ace', 'arc', 'arj', 'zip', 'rar', 'tar', '7zip', 'gzip', 'csv']) == -1) {
                    $('#btnEnviar6').prop("disabled", true);
                    $('#btnExcluir6').prop("disabled", true);
                    $('#spamMaxMB6').text('');
                    $('#pSize2').text('');
                    $('#ctl00_head_fup6').val('');
                    $('#ctl00_head_fup6').text('');

                    alert('O arquivo selecionado é inválido');
                }
                else {

                    var bytes = this.files[0].size;

                    if (typeof bytes !== 'number') {
                        return '';
                    }

                    if (bytes >= 1000000000) {
                        var result = (bytes / 1000000000).toFixed(2);
                        $('#pSize6').text(result + ' GB');

                        if (result > 200) {
                            $('#spamMaxMB6').text('(max. 200 MB)');
                            $('#btnEnviar6').prop("disabled", true);
                            $('#btnExcluir6').prop("disabled", true);
                        }
                        else {
                            $('#spamMaxMB6').text('');
                            $('#btnEnviar6').prop("disabled", false);
                            $('#btnExcluir6').prop("disabled", false);
                        }

                        return true;
                    }

                    if (bytes >= 1000000) {
                        var result = (bytes / 1000000).toFixed(2);
                        $('#pSize6').text(result + ' MB');

                        if (result > 200) {
                            $('#spamMaxMB6').text('(max. 200 MB)');
                            $('#btnEnviar6').prop("disabled", true);
                            $('#btnExcluir6').prop("disabled", true);
                        }
                        else {
                            $('#spamMaxMB6').text('');
                            $('#btnEnviar6').prop("disabled", false);
                            $('#btnExcluir6').prop("disabled", false);
                        }

                        return true;
                    }

                    return $('#pSize6').text((bytes / 1000).toFixed(2) + ' KB');
                }
            });

            $('#ctl00_head_fup7').bind('change', function () {

                $('#btnEnviar7').prop("disabled", false);
                $('#btnExcluir7').prop("disabled", false);
                $('#spamMaxMB7').text('');
                $('#pSize7').text('');

                var ext = $('#ctl00_head_fup7').val().split('.').pop().toLowerCase();
                if ($.inArray(ext, ['txt', 'xls', 'xlsx', 'ace', 'arc', 'arj', 'zip', 'rar', 'tar', '7zip', 'gzip', 'csv']) == -1) {
                    $('#btnEnviar7').prop("disabled", true);
                    $('#btnExcluir7').prop("disabled", true);
                    $('#spamMaxMB7').text('');
                    $('#pSize7').text('');
                    $('#ctl00_head_fup7').val('');
                    $('#ctl00_head_fup7').text('');

                    alert('O arquivo selecionado é inválido');
                }
                else {

                    var bytes = this.files[0].size;

                    if (typeof bytes !== 'number') {
                        return '';
                    }

                    if (bytes >= 1000000000) {
                        var result = (bytes / 1000000000).toFixed(2);
                        $('#pSize7').text(result + ' GB');

                        if (result > 200) {
                            $('#spamMaxMB7').text('(max. 200 MB)');
                            $('#btnEnviar7').prop("disabled", true);
                            $('#btnExcluir7').prop("disabled", true);
                        }
                        else {
                            $('#spamMaxMB7').text('');
                            $('#btnEnviar7').prop("disabled", false);
                            $('#btnExcluir7').prop("disabled", false);
                        }

                        return true;
                    }

                    if (bytes >= 1000000) {
                        var result = (bytes / 1000000).toFixed(2);
                        $('#pSize7').text(result + ' MB');

                        if (result > 200) {
                            $('#spamMaxMB7').text('(max. 200 MB)');
                            $('#btnEnviar7').prop("disabled", true);
                            $('#btnExcluir7').prop("disabled", true);
                        }
                        else {
                            $('#spamMaxMB7').text('');
                            $('#btnEnviar7').prop("disabled", false);
                            $('#btnExcluir7').prop("disabled", false);
                        }

                        return true;
                    }

                    return $('#pSize7').text((bytes / 1000).toFixed(2) + ' KB');
                }
            });

            $('#ctl00_head_fup8').bind('change', function () {

                $('#btnEnviar8').prop("disabled", false);
                $('#btnExcluir8').prop("disabled", false);
                $('#spamMaxMB8').text('');
                $('#pSize8').text('');

                var ext = $('#ctl00_head_fup8').val().split('.').pop().toLowerCase();
                if ($.inArray(ext, ['txt', 'xls', 'xlsx', 'ace', 'arc', 'arj', 'zip', 'rar', 'tar', '7zip', 'gzip', 'csv']) == -1) {
                    $('#btnEnviar8').prop("disabled", true);
                    $('#btnExcluir8').prop("disabled", true);
                    $('#spamMaxMB8').text('');
                    $('#pSize8').text('');
                    $('#ctl00_head_fup8').val('');
                    $('#ctl00_head_fup8').text('');

                    alert('O arquivo selecionado é inválido');
                }
                else {

                    var bytes = this.files[0].size;

                    if (typeof bytes !== 'number') {
                        return '';
                    }

                    if (bytes >= 1000000000) {
                        var result = (bytes / 1000000000).toFixed(2);
                        $('#pSize8').text(result + ' GB');

                        if (result > 200) {
                            $('#spamMaxMB8').text('(max. 200 MB)');
                            $('#btnEnviar8').prop("disabled", true);
                            $('#btnExcluir8').prop("disabled", true);
                        }
                        else {
                            $('#spamMaxMB8').text('');
                            $('#btnEnviar8').prop("disabled", false);
                            $('#btnExcluir8').prop("disabled", false);
                        }

                        return true;
                    }

                    if (bytes >= 1000000) {
                        var result = (bytes / 1000000).toFixed(2);
                        $('#pSize8').text(result + ' MB');

                        if (result > 200) {
                            $('#spamMaxMB8').text('(max. 200 MB)');
                            $('#btnEnviar8').prop("disabled", true);
                            $('#btnExcluir8').prop("disabled", true);
                        }
                        else {
                            $('#spamMaxMB8').text('');
                            $('#btnEnviar8').prop("disabled", false);
                            $('#btnExcluir8').prop("disabled", false);
                        }

                        return true;
                    }

                    return $('#pSize8').text((bytes / 1000).toFixed(2) + ' KB');
                }
            });

            $('#ctl00_head_fup9').bind('change', function () {

                $('#btnEnviar9').prop("disabled", false);
                $('#btnExcluir9').prop("disabled", false);
                $('#spamMaxMB9').text('');
                $('#pSize9').text('');

                var ext = $('#ctl00_head_fup9').val().split('.').pop().toLowerCase();
                if ($.inArray(ext, ['txt', 'xls', 'xlsx', 'ace', 'arc', 'arj', 'zip', 'rar', 'tar', '7zip', 'gzip', 'csv']) == -1) {
                    $('#btnEnviar9').prop("disabled", true);
                    $('#btnExcluir9').prop("disabled", true);
                    $('#spamMaxMB9').text('');
                    $('#pSize9').text('');
                    $('#ctl00_head_fup9').val('');
                    $('#ctl00_head_fup9').text('');

                    alert('O arquivo selecionado é inválido');
                }
                else {

                    var bytes = this.files[0].size;

                    if (typeof bytes !== 'number') {
                        return '';
                    }

                    if (bytes >= 1000000000) {
                        var result = (bytes / 1000000000).toFixed(2);
                        $('#pSize9').text(result + ' GB');

                        if (result > 200) {
                            $('#spamMaxMB9').text('(max. 200 MB)');
                            $('#btnEnviar9').prop("disabled", true);
                            $('#btnExcluir9').prop("disabled", true);
                        }
                        else {
                            $('#spamMaxMB9').text('');
                            $('#btnEnviar9').prop("disabled", false);
                            $('#btnExcluir9').prop("disabled", false);
                        }

                        return true;
                    }

                    if (bytes >= 1000000) {
                        var result = (bytes / 1000000).toFixed(2);
                        $('#pSize9').text(result + ' MB');

                        if (result > 200) {
                            $('#spamMaxMB9').text('(max. 200 MB)');
                            $('#btnEnviar9').prop("disabled", true);
                            $('#btnExcluir9').prop("disabled", true);
                        }
                        else {
                            $('#spamMaxMB9').text('');
                            $('#btnEnviar9').prop("disabled", false);
                            $('#btnExcluir9').prop("disabled", false);
                        }

                        return true;
                    }

                    return $('#pSize9').text((bytes / 1000).toFixed(2) + ' KB');
                }
            });

            $('#ctl00_head_fup10').bind('change', function () {

                $('#btnEnviar10').prop("disabled", false);
                $('#btnExcluir10').prop("disabled", false);
                $('#spamMaxMB10').text('');
                $('#pSize10').text('');

                var ext = $('#ctl00_head_fup10').val().split('.').pop().toLowerCase();
                if ($.inArray(ext, ['txt', 'xls', 'xlsx', 'ace', 'arc', 'arj', 'zip', 'rar', 'tar', '7zip', 'gzip', 'csv']) == -1) {
                    $('#btnEnviar10').prop("disabled", true);
                    $('#btnExcluir10').prop("disabled", true);
                    $('#spamMaxMB10').text('');
                    $('#pSize10').text('');
                    $('#ctl00_head_fup10').val('');
                    $('#ctl00_head_fup10').text('');

                    alert('O arquivo selecionado é inválido');
                }
                else {

                    var bytes = this.files[0].size;

                    if (typeof bytes !== 'number') {
                        return '';
                    }

                    if (bytes >= 1000000000) {
                        var result = (bytes / 1000000000).toFixed(2);
                        $('#pSize10').text(result + ' GB');

                        if (result > 200) {
                            $('#spamMaxMB10').text('(max. 200 MB)');
                            $('#btnEnviar10').prop("disabled", true);
                            $('#btnExcluir10').prop("disabled", true);
                        }
                        else {
                            $('#spamMaxMB10').text('');
                            $('#btnEnviar10').prop("disabled", false);
                            $('#btnExcluir10').prop("disabled", false);
                        }

                        return true;
                    }

                    if (bytes >= 1000000) {
                        var result = (bytes / 1000000).toFixed(2);
                        $('#pSize10').text(result + ' MB');

                        if (result > 200) {
                            $('#spamMaxMB10').text('(max. 200 MB)');
                            $('#btnEnviar10').prop("disabled", true);
                            $('#btnExcluir10').prop("disabled", true);
                        }
                        else {
                            $('#spamMaxMB10').text('');
                            $('#btnEnviar10').prop("disabled", false);
                            $('#btnExcluir10').prop("disabled", false);
                        }

                        return true;
                    }

                    return $('#pSize10').text((bytes / 1000).toFixed(2) + ' KB');
                }
            });
        })
    </script>
    <!-- FIM - scripts Controle de tamanho do arquivo selecioado -->
    <!---->
    <!-- INICIO - Incluindo novos campos de UPLOAD -->
    <script type="text/javascript">

        function LiberarObjNovoEnvio(idSpanFup, idFup, idSize) {
            $('#' + idSpanFup).css("display", "none");
            $('#' + idFup).css("display", "block");
            $('#' + idSize).css("display", "block");

            $('#' + idFup).val('');
            $('#' + idFup).text('');
            $('#' + idSize).text('');
        }

        $(document).ready(function () {
            $('#btnEnviar1').on('click', function () {

                $('#btnEnviar1').prop("disabled", true);
                $('#btnExcluir1').prop("disabled", true);
                $('#imgLoadingFile1').css("display", "block");

                var data = new FormData();
                var files = $("#ctl00_head_fup1").get(0).files;

                //Add the uploaded image content to the form data collection
                if (files.length > 0) {
                    data.append("UploadedImage", files[0]);
                }

                // Make Ajax request with the contentType = false, and procesDate = false
                var ajaxRequest = $.ajax({
                    type: "POST",
                    url: "GerenciamentoArquivos.ashx",
                    contentType: false,
                    processData: false,
                    data: data,
                    success: function (result) {

                        $('#imgLoadingFile1').css("display", "none");
                        $('#ctl00_head_fup1').css("display", "none");
                        $('#divFup1Msg').css("display", "block");
                        $('#pSize1').css("display", "none");

                        if (result == 'ARQUIVO INVALIDO') {
                            $('#msgRetornoSucesso1').css("display", "none");
                            $('#msgRetornoErro1').css("display", "block");
                            $('#msgRetornoErro1').text('Tipo de arquivo inválido. Verifique os tipos permitidos.');
                        }
                        else if (result == 'ARQUIVO COM MAIS DE 200MB') {
                            $('#msgRetornoSucesso1').css("display", "none");
                            $('#msgRetornoErro1').css("display", "block");

                            $('#msgRetornoErro1').text('O tamanho máximo do arquivo não pode ultrapassar 200MB.');
                        }
                        else if (result.indexOf('159ERROR753:') >= 0) {

                            $('#msgRetornoSucesso1').css("display", "none");
                            $('#msgRetornoErro1').css("display", "block");
                            $('#msgRetornoErro1').text(result.replace('159ERROR753: ', ''));

                        }
                        else {
                            $('#msgRetornoSucesso1').css("display", "block");
                            $('#msgRetornoErro1').css("display", "none");
                        }
                    }
                });

                //                ajaxRequest.done(function (xhr, textStatus) {
                //                    alert('');
                //                });
            });
        });

        $(document).ready(function () {
            $('#btnEnviar2').on('click', function () {

                $('#btnEnviar2').prop("disabled", true);
                $('#btnExcluir2').prop("disabled", true);
                $('#imgLoadingFile2').css("display", "block");

                var data = new FormData();
                var files = $("#ctl00_head_fup2").get(0).files;

                //Add the uploaded image content to the form data collection
                if (files.length > 0) {
                    data.append("UploadedImage", files[0]);
                }

                // Make Ajax request with the contentType = false, and procesDate = false
                var ajaxRequest = $.ajax({
                    type: "POST",
                    url: "GerenciamentoArquivos.ashx",
                    contentType: false,
                    processData: false,
                    data: data,
                    success: function (result) {
                        $('#imgLoadingFile2').css("display", "none");
                        $('#ctl00_head_fup2').css("display", "none");
                        $('#divFup2Msg').css("display", "block");
                        $('#pSize2').css("display", "none");

                        if (result == 'ARQUIVO INVALIDO') {
                            $('#msgRetornoSucesso2').css("display", "none");
                            $('#msgRetornoErro2').css("display", "block");
                            $('#msgRetornoErro2').text('Tipo de arquivo inválido. Verifique os tipos permitidos.');
                        }
                        else if (result == 'ARQUIVO COM MAIS DE 200MB') {
                            $('#msgRetornoSucesso2').css("display", "none");
                            $('#msgRetornoErro2').css("display", "block");

                            $('#msgRetornoErro2').text('O tamanho máximo do arquivo não pode ultrapassar 200MB.');
                        }
                        else if (result.indexOf('159ERROR753:') >= 0) {

                            $('#msgRetornoSucesso2').css("display", "none");
                            $('#msgRetornoErro2').css("display", "block");
                            $('#msgRetornoErro2').text(result.replace('159ERROR753: ', ''));

                        }
                        else {
                            $('#msgRetornoSucesso2').css("display", "block");
                            $('#msgRetornoErro2').css("display", "none");
                        }
                    }
                });
            });
        });

        $(document).ready(function () {
            $('#btnEnviar3').on('click', function () {

                $('#btnEnviar3').prop("disabled", true);
                $('#btnExcluir3').prop("disabled", true);
                $('#imgLoadingFile3').css("display", "block");

                var data = new FormData();
                var files = $("#ctl00_head_fup3").get(0).files;

                //Add the uploaded image content to the form data collection
                if (files.length > 0) {
                    data.append("UploadedImage", files[0]);
                }

                // Make Ajax request with the contentType = false, and procesDate = false
                var ajaxRequest = $.ajax({
                    type: "POST",
                    url: "GerenciamentoArquivos.ashx",
                    contentType: false,
                    processData: false,
                    data: data,
                    success: function (result) {
                        $('#imgLoadingFile3').css("display", "none");
                        $('#ctl00_head_fup3').css("display", "none");
                        $('#divFup3Msg').css("display", "block");
                        $('#pSize3').css("display", "none");

                        if (result == 'ARQUIVO INVALIDO') {
                            $('#msgRetornoSucesso3').css("display", "none");
                            $('#msgRetornoErro3').css("display", "block");
                            $('#msgRetornoErro3').text('Tipo de arquivo inválido. Verifique os tipos permitidos.');
                        }
                        else if (result == 'ARQUIVO COM MAIS DE 200MB') {
                            $('#msgRetornoSucesso3').css("display", "none");
                            $('#msgRetornoErro3').css("display", "block");

                            $('#msgRetornoErro3').text('O tamanho máximo do arquivo não pode ultrapassar 200MB.');
                        }
                        else if (result.indexOf('159ERROR753:') >= 0) {

                            $('#msgRetornoSucesso3').css("display", "none");
                            $('#msgRetornoErro3').css("display", "block");
                            $('#msgRetornoErro3').text(result.replace('159ERROR753: ', ''));

                        }
                        else {
                            $('#msgRetornoSucesso3').css("display", "block");
                            $('#msgRetornoErro3').css("display", "none");
                        }
                    }
                });
            });
        });

        $(document).ready(function () {
            $('#btnEnviar4').on('click', function () {

                $('#btnEnviar4').prop("disabled", true);
                $('#btnExcluir4').prop("disabled", true);
                $('#imgLoadingFile4').css("display", "block");

                var data = new FormData();
                var files = $("#ctl00_head_fup4").get(0).files;

                //Add the uploaded image content to the form data collection
                if (files.length > 0) {
                    data.append("UploadedImage", files[0]);
                }

                // Make Ajax request with the contentType = false, and procesDate = false
                var ajaxRequest = $.ajax({
                    type: "POST",
                    url: "GerenciamentoArquivos.ashx",
                    contentType: false,
                    processData: false,
                    data: data,
                    success: function (result) {
                        $('#imgLoadingFile4').css("display", "none");
                        $('#ctl00_head_fup4').css("display", "none");
                        $('#divFup4Msg').css("display", "block");
                        $('#pSize4').css("display", "none");

                        if (result == 'ARQUIVO INVALIDO') {
                            $('#msgRetornoSucesso4').css("display", "none");
                            $('#msgRetornoErro4').css("display", "block");
                            $('#msgRetornoErro4').text('Tipo de arquivo inválido. Verifique os tipos permitidos.');
                        }
                        else if (result == 'ARQUIVO COM MAIS DE 200MB') {
                            $('#msgRetornoSucesso4').css("display", "none");
                            $('#msgRetornoErro4').css("display", "block");

                            $('#msgRetornoErro4').text('O tamanho máximo do arquivo não pode ultrapassar 200MB.');
                        }
                        else if (result.indexOf('159ERROR753:') >= 0) {

                            $('#msgRetornoSucesso4').css("display", "none");
                            $('#msgRetornoErro4').css("display", "block");
                            $('#msgRetornoErro4').text(result.replace('159ERROR753: ', ''));

                        }
                        else {
                            $('#msgRetornoSucesso4').css("display", "block");
                            $('#msgRetornoErro4').css("display", "none");
                        }
                    }
                });
            });
        });

        $(document).ready(function () {
            $('#btnEnviar5').on('click', function () {

                $('#btnEnviar5').prop("disabled", true);
                $('#btnExcluir5').prop("disabled", true);
                $('#imgLoadingFile5').css("display", "block");

                var data = new FormData();
                var files = $("#ctl00_head_fup5").get(0).files;

                //Add the uploaded image content to the form data collection
                if (files.length > 0) {
                    data.append("UploadedImage", files[0]);
                }

                // Make Ajax request with the contentType = false, and procesDate = false
                var ajaxRequest = $.ajax({
                    type: "POST",
                    url: "GerenciamentoArquivos.ashx",
                    contentType: false,
                    processData: false,
                    data: data,
                    success: function (result) {
                        $('#imgLoadingFile5').css("display", "none");
                        $('#ctl00_head_fup5').css("display", "none");
                        $('#divFup5Msg').css("display", "block");
                        $('#pSize5').css("display", "none");

                        if (result == 'ARQUIVO INVALIDO') {
                            $('#msgRetornoSucesso5').css("display", "none");
                            $('#msgRetornoErro5').css("display", "block");
                            $('#msgRetornoErro5').text('Tipo de arquivo inválido. Verifique os tipos permitidos.');
                        }
                        else if (result == 'ARQUIVO COM MAIS DE 200MB') {
                            $('#msgRetornoSucesso5').css("display", "none");
                            $('#msgRetornoErro5').css("display", "block");

                            $('#msgRetornoErro5').text('O tamanho máximo do arquivo não pode ultrapassar 200MB.');
                        }
                        else if (result.indexOf('159ERROR753:') >= 0) {

                            $('#msgRetornoSucesso5').css("display", "none");
                            $('#msgRetornoErro5').css("display", "block");
                            $('#msgRetornoErro5').text(result.replace('159ERROR753: ', ''));

                        }
                        else {
                            $('#msgRetornoSucesso5').css("display", "block");
                            $('#msgRetornoErro5').css("display", "none");
                        }
                    }
                });
            });
        });

        $(document).ready(function () {
            $('#btnEnviar6').on('click', function () {

                $('#btnEnviar6').prop("disabled", true);
                $('#btnExcluir6').prop("disabled", true);
                $('#imgLoadingFile6').css("display", "block");

                var data = new FormData();
                var files = $("#ctl00_head_fup6").get(0).files;

                //Add the uploaded image content to the form data collection
                if (files.length > 0) {
                    data.append("UploadedImage", files[0]);
                }

                // Make Ajax request with the contentType = false, and procesDate = false
                var ajaxRequest = $.ajax({
                    type: "POST",
                    url: "GerenciamentoArquivos.ashx",
                    contentType: false,
                    processData: false,
                    data: data,
                    success: function (result) {
                        $('#imgLoadingFile6').css("display", "none");
                        $('#ctl00_head_fup6').css("display", "none");
                        $('#divFup6Msg').css("display", "block");
                        $('#pSize6').css("display", "none");

                        if (result == 'ARQUIVO INVALIDO') {
                            $('#msgRetornoSucesso6').css("display", "none");
                            $('#msgRetornoErro6').css("display", "block");
                            $('#msgRetornoErro6').text('Tipo de arquivo inválido. Verifique os tipos permitidos.');
                        }
                        else if (result == 'ARQUIVO COM MAIS DE 200MB') {
                            $('#msgRetornoSucesso6').css("display", "none");
                            $('#msgRetornoErro6').css("display", "block");

                            $('#msgRetornoErro6').text('O tamanho máximo do arquivo não pode ultrapassar 200MB.');
                        }
                        else if (result.indexOf('159ERROR753:') >= 0) {

                            $('#msgRetornoSucesso6').css("display", "none");
                            $('#msgRetornoErro6').css("display", "block");
                            $('#msgRetornoErro6').text(result.replace('159ERROR753: ', ''));

                        }
                        else {
                            $('#msgRetornoSucesso6').css("display", "block");
                            $('#msgRetornoErro6').css("display", "none");
                        }
                    }
                });
            });
        });

        $(document).ready(function () {
            $('#btnEnviar7').on('click', function () {

                $('#btnEnviar7').prop("disabled", true);
                $('#btnExcluir7').prop("disabled", true);
                $('#imgLoadingFile7').css("display", "block");

                var data = new FormData();
                var files = $("#ctl00_head_fup7").get(0).files;

                //Add the uploaded image content to the form data collection
                if (files.length > 0) {
                    data.append("UploadedImage", files[0]);
                }

                // Make Ajax request with the contentType = false, and procesDate = false
                var ajaxRequest = $.ajax({
                    type: "POST",
                    url: "GerenciamentoArquivos.ashx",
                    contentType: false,
                    processData: false,
                    data: data,
                    success: function (result) {
                        $('#imgLoadingFile7').css("display", "none");
                        $('#ctl00_head_fup7').css("display", "none");
                        $('#divFup7Msg').css("display", "block");
                        $('#pSize7').css("display", "none");

                        if (result == 'ARQUIVO INVALIDO') {
                            $('#msgRetornoSucesso7').css("display", "none");
                            $('#msgRetornoErro7').css("display", "block");
                            $('#msgRetornoErro7').text('Tipo de arquivo inválido. Verifique os tipos permitidos.');
                        }
                        else if (result == 'ARQUIVO COM MAIS DE 200MB') {
                            $('#msgRetornoSucesso7').css("display", "none");
                            $('#msgRetornoErro7').css("display", "block");

                            $('#msgRetornoErro7').text('O tamanho máximo do arquivo não pode ultrapassar 200MB.');
                        }
                        else if (result.indexOf('159ERROR753:') >= 0) {

                            $('#msgRetornoSucesso7').css("display", "none");
                            $('#msgRetornoErro7').css("display", "block");
                            $('#msgRetornoErro7').text(result.replace('159ERROR753: ', ''));

                        }
                        else {
                            $('#msgRetornoSucesso7').css("display", "block");
                            $('#msgRetornoErro7').css("display", "none");
                        }
                    }
                });
            });
        });

        $(document).ready(function () {
            $('#btnEnviar8').on('click', function () {

                $('#btnEnviar8').prop("disabled", true);
                $('#btnExcluir8').prop("disabled", true);
                $('#imgLoadingFile8').css("display", "block");

                var data = new FormData();
                var files = $("#ctl00_head_fup8").get(0).files;

                //Add the uploaded image content to the form data collection
                if (files.length > 0) {
                    data.append("UploadedImage", files[0]);
                }

                // Make Ajax request with the contentType = false, and procesDate = false
                var ajaxRequest = $.ajax({
                    type: "POST",
                    url: "GerenciamentoArquivos.ashx",
                    contentType: false,
                    processData: false,
                    data: data,
                    success: function (result) {
                        $('#imgLoadingFile8').css("display", "none");
                        $('#ctl00_head_fup8').css("display", "none");
                        $('#divFup8Msg').css("display", "block");
                        $('#pSize8').css("display", "none");

                        if (result == 'ARQUIVO INVALIDO') {
                            $('#msgRetornoSucesso8').css("display", "none");
                            $('#msgRetornoErro8').css("display", "block");
                            $('#msgRetornoErro8').text('Tipo de arquivo inválido. Verifique os tipos permitidos.');
                        }
                        else if (result == 'ARQUIVO COM MAIS DE 200MB') {
                            $('#msgRetornoSucesso8').css("display", "none");
                            $('#msgRetornoErro8').css("display", "block");

                            $('#msgRetornoErro8').text('O tamanho máximo do arquivo não pode ultrapassar 200MB.');
                        }
                        else if (result.indexOf('159ERROR753:') >= 0) {

                            $('#msgRetornoSucesso8').css("display", "none");
                            $('#msgRetornoErro8').css("display", "block");
                            $('#msgRetornoErro8').text(result.replace('159ERROR753: ', ''));

                        }
                        else {
                            $('#msgRetornoSucesso8').css("display", "block");
                            $('#msgRetornoErro8').css("display", "none");
                        }
                    }
                });
            });
        });

        $(document).ready(function () {
            $('#btnEnviar9').on('click', function () {

                $('#btnEnviar9').prop("disabled", true);
                $('#btnExcluir9').prop("disabled", true);
                $('#imgLoadingFile9').css("display", "block");

                var data = new FormData();
                var files = $("#ctl00_head_fup9").get(0).files;

                //Add the uploaded image content to the form data collection
                if (files.length > 0) {
                    data.append("UploadedImage", files[0]);
                }

                // Make Ajax request with the contentType = false, and procesDate = false
                var ajaxRequest = $.ajax({
                    type: "POST",
                    url: "GerenciamentoArquivos.ashx",
                    contentType: false,
                    processData: false,
                    data: data,
                    success: function (result) {
                        $('#imgLoadingFile9').css("display", "none");
                        $('#ctl00_head_fup9').css("display", "none");
                        $('#divFup9Msg').css("display", "block");
                        $('#pSize9').css("display", "none");

                        if (result == 'ARQUIVO INVALIDO') {
                            $('#msgRetornoSucesso9').css("display", "none");
                            $('#msgRetornoErro9').css("display", "block");
                            $('#msgRetornoErro9').text('Tipo de arquivo inválido. Verifique os tipos permitidos.');
                        }
                        else if (result == 'ARQUIVO COM MAIS DE 200MB') {
                            $('#msgRetornoSucesso9').css("display", "none");
                            $('#msgRetornoErro9').css("display", "block");

                            $('#msgRetornoErro9').text('O tamanho máximo do arquivo não pode ultrapassar 200MB.');
                        }
                        else if (result.indexOf('159ERROR753:') >= 0) {

                            $('#msgRetornoSucesso9').css("display", "none");
                            $('#msgRetornoErro9').css("display", "block");
                            $('#msgRetornoErro9').text(result.replace('159ERROR753: ', ''));

                        }
                        else {
                            $('#msgRetornoSucesso9').css("display", "block");
                            $('#msgRetornoErro9').css("display", "none");
                        }
                    }
                });
            });
        });

        $(document).ready(function () {
            $('#btnEnviar10').on('click', function () {

                $('#btnEnviar10').prop("disabled", true);
                $('#btnExcluir10').prop("disabled", true);
                $('#imgLoadingFile10').css("display", "block");

                var data = new FormData();
                var files = $("#ctl00_head_fup10").get(0).files;

                //Add the uploaded image content to the form data collection
                if (files.length > 0) {
                    data.append("UploadedImage", files[0]);
                }

                // Make Ajax request with the contentType = false, and procesDate = false
                var ajaxRequest = $.ajax({
                    type: "POST",
                    url: "GerenciamentoArquivos.ashx",
                    contentType: false,
                    processData: false,
                    data: data,
                    success: function (result) {
                        $('#imgLoadingFile10').css("display", "none");
                        $('#ctl00_head_fup10').css("display", "none");
                        $('#divFup10Msg').css("display", "block");
                        $('#pSize10').css("display", "none");

                        if (result == 'ARQUIVO INVALIDO') {
                            $('#msgRetornoSucesso10').css("display", "none");
                            $('#msgRetornoErro10').css("display", "block");
                            $('#msgRetornoErro10').text('Tipo de arquivo inválido. Verifique os tipos permitidos.');
                        }
                        else if (result == 'ARQUIVO COM MAIS DE 200MB') {
                            $('#msgRetornoSucesso10').css("display", "none");
                            $('#msgRetornoErro10').css("display", "block");

                            $('#msgRetornoErro10').text('O tamanho máximo do arquivo não pode ultrapassar 200MB.');
                        }
                        else if (result.indexOf('159ERROR753:') >= 0) {

                            $('#msgRetornoSucesso10').css("display", "none");
                            $('#msgRetornoErro10').css("display", "block");
                            $('#msgRetornoErro10').text(result.replace('159ERROR753: ', ''));

                        }
                        else {
                            $('#msgRetornoSucesso10').css("display", "block");
                            $('#msgRetornoErro10').css("display", "none");
                        }
                    }
                });
            });
        });
function btnAtualizarListaArqEnviados_onclick() {

}

function btnAtualizarListaArqEnviados_onclick() {

}

    </script>
    <!-- FIM - Incluindo novos campos de UPLOAD -->
    <!---->
    <div style="width: 100%;" class="divResultadoPesquisaCadastral">
        <asp:Label ID="Label1" runat="server" Text="FTP" Style="font-weight: normal; font-size: 20px;"></asp:Label>
        <hr />
    </div>
    <br />
    <div class="main">
        <div class="accordion2">
            <div class="accordion2-section">
                <a class="accordion2-section-title" href="#accordion2-1">Enviar Arquivos</a>
                <div id="accordion2-1" class="accordion2-section-content">
                    <blockquote>
                        <h4>
                            Atenção:</h4>
                        <h5>
                            1 - Só é permitido o envio de arquivos <b>TEXTO</b> (txt), <b>PLANILHAS</b> (xls, xlsx e csv) 
                            e <b>COMPACTADOS</b> (Zip, Rar, Tar, 7zip, Taz e Gzip).</h5>
                        <h5>
                            2 - O tamanho máximo do arquivo não pode ultrapassar <b>200MB</b>.</h5>
                    </blockquote>
                    <div style="background-color: #fff">
                        <table id="tblUploadPrincipal" border="0" cellpadding="3" cellspacing="3" width="100%">
                            <tr id="tr1" style="display: block; vertical-align: middle !important; height: 70px;
                                border-top: 1px solid #ddd;">
                                <td style="vertical-align: middle !important; width: 20px;">
                                    &nbsp;
                                </td>
                                <td style="vertical-align: middle !important; width: 50px;">
                                    <h4>
                                        01 -
                                    </h4>
                                </td>
                                <td style="vertical-align: middle !important; width: 500px;">
                                    <asp:FileUpload ID="fup1" runat="server" Width="450px" accept=".txt, .xls, .xlsx, .ace, .arc, .arj, .zip, .rar, .tar, .7zip, .gzip, .csv" />
                                    <div id="divFup1Msg" style="display: none;">
                                        <h4 id="msgRetornoSucesso1" style='color: #449D44;'>Arquivo enviado com sucesso!!!</h4>
                                        <h4 id="msgRetornoErro1" style='color: #a94442;'>Erro</h4>
                                        <span style='cursor: pointer; color: #3071A9; font-size: 12px;' 
                                            onmouseover=javascript:this.style.textDecoration='underline' 
                                            onmouseleave=javascript:this.style.textDecoration='none'
                                            onclick=javascript:LiberarObjNovoEnvio('divFup1Msg','ctl00_head_fup1','pSize1'); 
                                            title='Clique para enviar outro arquivo'>[Clique aqui para enviar outro arquivo]</span>
                                    </div>
                                </td>
                                <td style="vertical-align: middle !important; width: 100px;">
                                    <h5 id="pSize1">
                                    </h5>
                                    <span id="spamMaxMB1" style="color: #a94442; font-size: 10px;" />
                                </td>
                                <td style="vertical-align: middle !important;">
                                    <table border="0" cellpadding="0" cellspacing="3">
                                        <tr style="height: 60px">
                                            <td style="width: 120px; vertical-align: middle; text-align: center;">
                                                <button type="button" class="btn btn-primary start" id="btnEnviar1" disabled>
                                                    <i class="glyphicon glyphicon-upload"></i><span>&nbsp;&nbsp;Enviar</span>
                                                </button>
                                            </td>
                                            <td style="width: 120px; vertical-align: middle; text-align: center;">
                                                <button type="submit" class="btn btn-danger delete" id="btnExcluir1" disabled>
                                                    <i class="glyphicon glyphicon-trash"></i><span>&nbsp;&nbsp;Excluir</span>
                                                </button>
                                            </td>
                                            <td style="width: 60px; vertical-align: middle; text-align: center; position: relative;
                                                top: 8px;">
                                                <img id="imgLoadingFile1" style="display: none;" src="../../../Images/Loading32x32.GIF"
                                                    alt="Processando. Aguarde..." /><br />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="tr2" style="display: none; vertical-align: middle !important; height: 70px;
                                border-top: 1px solid #ddd;">
                                <td style="vertical-align: middle !important; width: 20px;">
                                    &nbsp;
                                </td>
                                <td style="vertical-align: middle !important; width: 50px;">
                                    <h4>
                                        02 -
                                    </h4>
                                </td>
                                <td style="vertical-align: middle !important; width: 500px;">
                                    <asp:FileUpload ID="fup2" runat="server" accept=".txt, .xls, .xlsx, .ace, .arc, .arj, .zip, .rar, .tar, .7zip, .gzip, .csv" />
                                    <div id="divFup2Msg" style="display: none;">
                                        <h4 id="msgRetornoSucesso2" style='color: #449D44;'>Arquivo enviado com sucesso!!!</h4>
                                        <h4 id="msgRetornoErro2" style='color: #a94442;'>Erro</h4>
                                        <span style='cursor: pointer; color: #3071A9; font-size: 12px;' 
                                            onmouseover=javascript:this.style.textDecoration='underline' onmouseleave=javascript:this.style.textDecoration='none'
                                            onclick=javascript:LiberarObjNovoEnvio('divFup2Msg','ctl00_head_fup2','pSize2'); 
                                            title='Clique para enviar outro arquivo'>[Clique aqui para enviar outro arquivo]</span>
                                    </div>
                                </td>
                                <td style="vertical-align: middle !important; width: 100px;">
                                    <h5 id="pSize2">
                                    </h5>
                                    <span id="spamMaxMB2" style="color: #a94442; font-size: 10px;" />
                                </td>
                                <td style="vertical-align: middle !important;">
                                    <table border="0" cellpadding="0" cellspacing="3">
                                        <tr style="height: 60px">
                                            <td style="width: 120px; vertical-align: middle; text-align: center;">
                                                <button type="submit" class="btn btn-primary start" id="btnEnviar2" disabled>
                                                    <i class="glyphicon glyphicon-upload"></i><span>&nbsp;&nbsp;Enviar</span>
                                                </button>
                                            </td>
                                            <td style="width: 120px; vertical-align: middle; text-align: center;">
                                                <button type="submit" class="btn btn-danger delete" id="btnExcluir2" disabled>
                                                    <i class="glyphicon glyphicon-trash"></i><span>&nbsp;&nbsp;Excluir</span>
                                                </button>
                                            </td>
                                            <td style="width: 60px; vertical-align: middle; text-align: center; position: relative;
                                                top: 8px;">
                                                <img id="imgLoadingFile2" style="display: none;" src="../../../Images/Loading32x32.GIF"
                                                    alt="Processando. Aguarde..." /><br />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="tr3" style="display: none; vertical-align: middle !important; height: 70px;
                                border-top: 1px solid #ddd;">
                                <td style="vertical-align: middle !important; width: 20px;">
                                    &nbsp;
                                </td>
                                <td style="vertical-align: middle !important; width: 50px;">
                                    <h4>
                                        03 -
                                    </h4>
                                </td>
                                <td style="vertical-align: middle !important; width: 500px;">
                                    <asp:FileUpload ID="fup3" runat="server" accept=".txt, .xls, .xlsx, .ace, .arc, .arj, .zip, .rar, .tar, .7zip, .gzip, .csv" />
                                    <div id="divFup3Msg" style="display: none;">
                                        <h4 id="msgRetornoSucesso3" style='color: #449D44;'>Arquivo enviado com sucesso!!!</h4>
                                        <h4 id="msgRetornoErro3" style='color: #a94442;'>Erro</h4>
                                        <span style='cursor: pointer; color: #3071A9; font-size: 12px;' 
                                            onmouseover=javascript:this.style.textDecoration='underline' onmouseleave=javascript:this.style.textDecoration='none'
                                            onclick=javascript:LiberarObjNovoEnvio('divFup3Msg','ctl00_head_fup3','pSize3'); 
                                            title='Clique para enviar outro arquivo'>[Clique aqui para enviar outro arquivo]</span>
                                    </div>
                                </td>
                                <td style="vertical-align: middle !important; width: 100px;">
                                    <h5 id="pSize3">
                                    </h5>
                                    <span id="spamMaxMB3" style="color: #a94442; font-size: 10px;" />
                                </td>
                                <td style="vertical-align: middle !important;">
                                    <table border="0" cellpadding="0" cellspacing="3">
                                        <tr style="height: 60px">
                                            <td style="width: 120px; vertical-align: middle; text-align: center;">
                                                <button type="submit" class="btn btn-primary start" id="btnEnviar3" disabled>
                                                    <i class="glyphicon glyphicon-upload"></i><span>&nbsp;&nbsp;Enviar</span>
                                                </button>
                                            </td>
                                            <td style="width: 120px; vertical-align: middle; text-align: center;">
                                                <button type="submit" class="btn btn-danger delete" id="btnExcluir3" disabled>
                                                    <i class="glyphicon glyphicon-trash"></i><span>&nbsp;&nbsp;Excluir</span>
                                                </button>
                                            </td>
                                            <td style="width: 60px; vertical-align: middle; text-align: center; position: relative;
                                                top: 8px;">
                                                <img id="imgLoadingFile3" style="display: none;" src="../../../Images/Loading32x32.GIF"
                                                    alt="Processando. Aguarde..." /><br />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="tr4" style="display: none; vertical-align: middle !important; height: 70px;
                                border-top: 1px solid #ddd;">
                                <td style="vertical-align: middle !important; width: 20px;">
                                    &nbsp;
                                </td>
                                <td style="vertical-align: middle !important; width: 50px;">
                                    <h4>
                                        04 -
                                    </h4>
                                </td>
                                <td style="vertical-align: middle !important; width: 500px;">
                                    <asp:FileUpload ID="fup4" runat="server" accept=".txt, .xls, .xlsx, .ace, .arc, .arj, .zip, .rar, .tar, .7zip, .gzip, .csv" />
                                    <div id="divFup4Msg" style="display: none;">
                                        <h4 id="msgRetornoSucesso4" style='color: #449D44;'>Arquivo enviado com sucesso!!!</h4>
                                        <h4 id="msgRetornoErro4" style='color: #a94442;'>Erro</h4>
                                        <span style='cursor: pointer; color: #3071A9; font-size: 12px;' 
                                            onmouseover=javascript:this.style.textDecoration='underline' onmouseleave=javascript:this.style.textDecoration='none'
                                            onclick=javascript:LiberarObjNovoEnvio('divFup4Msg','ctl00_head_fup4','pSize4'); 
                                            title='Clique para enviar outro arquivo'>[Clique aqui para enviar outro arquivo]</span>
                                    </div>
                                </td>
                                <td style="vertical-align: middle !important; width: 100px;">
                                    <h5 id="pSize4">
                                    </h5>
                                    <span id="spamMaxMB4" style="color: #a94442; font-size: 10px;" />
                                </td>
                                <td style="vertical-align: middle !important;">
                                    <table border="0" cellpadding="0" cellspacing="3">
                                        <tr style="height: 60px">
                                            <td style="width: 120px; vertical-align: middle; text-align: center;">
                                                <button type="submit" class="btn btn-primary start" id="btnEnviar4" disabled>
                                                    <i class="glyphicon glyphicon-upload"></i><span>&nbsp;&nbsp;Enviar</span>
                                                </button>
                                            </td>
                                            <td style="width: 120px; vertical-align: middle; text-align: center;">
                                                <button type="submit" class="btn btn-danger delete" id="btnExcluir4" disabled>
                                                    <i class="glyphicon glyphicon-trash"></i><span>&nbsp;&nbsp;Excluir</span>
                                                </button>
                                            </td>
                                            <td style="width: 60px; vertical-align: middle; text-align: center; position: relative;
                                                top: 8px;">
                                                <img id="imgLoadingFile4" style="display: none;" src="../../../Images/Loading32x32.GIF"
                                                    alt="Processando. Aguarde..." /><br />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="tr5" style="display: none; vertical-align: middle !important; height: 70px;
                                border-top: 1px solid #ddd;">
                                <td style="vertical-align: middle !important; width: 20px;">
                                    &nbsp;
                                </td>
                                <td style="vertical-align: middle !important; width: 50px;">
                                    <h4>
                                        05 -
                                    </h4>
                                </td>
                                <td style="vertical-align: middle !important; width: 500px;">
                                    <asp:FileUpload ID="fup5" runat="server" accept=".txt, .xls, .xlsx, .ace, .arc, .arj, .zip, .rar, .tar, .7zip, .gzip, .csv" />
                                    <div id="divFup5Msg" style="display: none;">
                                        <h4 id="msgRetornoSucesso5" style='color: #449D44;'>Arquivo enviado com sucesso!!!</h4>
                                        <h4 id="msgRetornoErro5" style='color: #a94442;'>Erro</h4>
                                        <span style='cursor: pointer; color: #3071A9; font-size: 12px;' 
                                            onmouseover=javascript:this.style.textDecoration='underline' onmouseleave=javascript:this.style.textDecoration='none'
                                            onclick=javascript:LiberarObjNovoEnvio('divFup5Msg','ctl00_head_fup5','pSize5'); 
                                            title='Clique para enviar outro arquivo'>[Clique aqui para enviar outro arquivo]</span>
                                    </div>
                                </td>
                                <td style="vertical-align: middle !important; width: 100px;">
                                    <h5 id="pSize5">
                                    </h5>
                                    <span id="spamMaxMB5" style="color: #a94442; font-size: 10px;" />
                                </td>
                                <td style="vertical-align: middle !important;">
                                    <table border="0" cellpadding="0" cellspacing="3">
                                        <tr style="height: 60px">
                                            <td style="width: 120px; vertical-align: middle; text-align: center;">
                                                <button type="submit" class="btn btn-primary start" id="btnEnviar5" disabled>
                                                    <i class="glyphicon glyphicon-upload"></i><span>&nbsp;&nbsp;Enviar</span>
                                                </button>
                                            </td>
                                            <td style="width: 120px; vertical-align: middle; text-align: center;">
                                                <button type="submit" class="btn btn-danger delete" id="btnExcluir5" disabled>
                                                    <i class="glyphicon glyphicon-trash"></i><span>&nbsp;&nbsp;Excluir</span>
                                                </button>
                                            </td>
                                            <td style="width: 60px; vertical-align: middle; text-align: center; position: relative;
                                                top: 8px;">
                                                <img id="imgLoadingFile5" style="display: none;" src="../../../Images/Loading32x32.GIF"
                                                    alt="Processando. Aguarde..." /><br />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="tr6" style="display: none; vertical-align: middle !important; height: 70px;
                                border-top: 1px solid #ddd;">
                                <td style="vertical-align: middle !important; width: 20px;">
                                    &nbsp;
                                </td>
                                <td style="vertical-align: middle !important; width: 50px;">
                                    <h4>
                                        06 -
                                    </h4>
                                </td>
                                <td style="vertical-align: middle !important; width: 500px;">
                                    <asp:FileUpload ID="fup6" runat="server" accept=".txt, .xls, .xlsx, .ace, .arc, .arj, .zip, .rar, .tar, .7zip, .gzip, .csv" />
                                    <div id="divFup6Msg" style="display: none;">
                                        <h4 id="msgRetornoSucesso6" style='color: #449D44;'>Arquivo enviado com sucesso!!!</h4>
                                        <h4 id="msgRetornoErro6" style='color: #a94442;'>Erro</h4>
                                        <span style='cursor: pointer; color: #3071A9; font-size: 12px;' 
                                            onmouseover=javascript:this.style.textDecoration='underline' onmouseleave=javascript:this.style.textDecoration='none'
                                            onclick=javascript:LiberarObjNovoEnvio('divFup6Msg','ctl00_head_fup6','pSize6'); 
                                            title='Clique para enviar outro arquivo'>[Clique aqui para enviar outro arquivo]</span>
                                    </div>
                                </td>
                                <td style="vertical-align: middle !important; width: 100px;">
                                    <h5 id="pSize6">
                                    </h5>
                                    <span id="spamMaxMB6" style="color: #a94442; font-size: 10px;" />
                                </td>
                                <td style="vertical-align: middle !important;">
                                    <table border="0" cellpadding="0" cellspacing="3">
                                        <tr style="height: 60px">
                                            <td style="width: 120px; vertical-align: middle; text-align: center;">
                                                <button type="submit" class="btn btn-primary start" id="btnEnviar6" disabled>
                                                    <i class="glyphicon glyphicon-upload"></i><span>&nbsp;&nbsp;Enviar</span>
                                                </button>
                                            </td>
                                            <td style="width: 120px; vertical-align: middle; text-align: center;">
                                                <button type="submit" class="btn btn-danger delete" id="btnExcluir6" disabled>
                                                    <i class="glyphicon glyphicon-trash"></i><span>&nbsp;&nbsp;Excluir</span>
                                                </button>
                                            </td>
                                            <td style="width: 60px; vertical-align: middle; text-align: center; position: relative;
                                                top: 8px;">
                                                <img id="imgLoadingFile6" style="display: none;" src="../../../Images/Loading32x32.GIF"
                                                    alt="Processando. Aguarde..." /><br />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="tr7" style="display: none; vertical-align: middle !important; height: 70px;
                                border-top: 1px solid #ddd;">
                                <td style="vertical-align: middle !important; width: 20px;">
                                    &nbsp;
                                </td>
                                <td style="vertical-align: middle !important; width: 50px;">
                                    <h4>
                                        07 -
                                    </h4>
                                </td>
                                <td style="vertical-align: middle !important; width: 500px;">
                                    <asp:FileUpload ID="fup7" runat="server" accept=".txt, .xls, .xlsx, .ace, .arc, .arj, .zip, .rar, .tar, .7zip, .gzip, .csv" />
                                    <div id="divFup7Msg" style="display: none;">
                                        <h4 id="msgRetornoSucesso7" style='color: #449D44;'>Arquivo enviado com sucesso!!!</h4>
                                        <h4 id="msgRetornoErro7" style='color: #a94442;'>Erro</h4>
                                        <span style='cursor: pointer; color: #3071A9; font-size: 12px;' 
                                            onmouseover=javascript:this.style.textDecoration='underline' onmouseleave=javascript:this.style.textDecoration='none'
                                            onclick=javascript:LiberarObjNovoEnvio('divFup7Msg','ctl00_head_fup7','pSize7'); 
                                            title='Clique para enviar outro arquivo'>[Clique aqui para enviar outro arquivo]</span>
                                    </div>
                                </td>
                                <td style="vertical-align: middle !important; width: 100px;">
                                    <h5 id="pSize7">
                                    </h5>
                                    <span id="spamMaxMB7" style="color: #a94442; font-size: 10px;" />
                                </td>
                                <td style="vertical-align: middle !important;">
                                    <table border="0" cellpadding="0" cellspacing="3">
                                        <tr style="height: 60px">
                                            <td style="width: 120px; vertical-align: middle; text-align: center;">
                                                <button type="submit" class="btn btn-primary start" id="btnEnviar7" disabled>
                                                    <i class="glyphicon glyphicon-upload"></i><span>&nbsp;&nbsp;Enviar</span>
                                                </button>
                                            </td>
                                            <td style="width: 120px; vertical-align: middle; text-align: center;">
                                                <button type="submit" class="btn btn-danger delete" id="btnExcluir7" disabled>
                                                    <i class="glyphicon glyphicon-trash"></i><span>&nbsp;&nbsp;Excluir</span>
                                                </button>
                                            </td>
                                            <td style="width: 60px; vertical-align: middle; text-align: center; position: relative;
                                                top: 8px;">
                                                <img id="imgLoadingFile7" style="display: none;" src="../../../Images/Loading32x32.GIF"
                                                    alt="Processando. Aguarde..." /><br />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="tr8" style="display: none; vertical-align: middle !important; height: 70px;
                                border-top: 1px solid #ddd;">
                                <td style="vertical-align: middle !important; width: 20px;">
                                    &nbsp;
                                </td>
                                <td style="vertical-align: middle !important; width: 50px;">
                                    <h4>
                                        08 -
                                    </h4>
                                </td>
                                <td style="vertical-align: middle !important; width: 500px;">
                                    <asp:FileUpload ID="fup8" runat="server" accept=".txt, .xls, .xlsx, .ace, .arc, .arj, .zip, .rar, .tar, .7zip, .gzip, .csv" />
                                    <div id="divFup8Msg" style="display: none;">
                                        <h4 id="msgRetornoSucesso8" style='color: #449D44;'>Arquivo enviado com sucesso!!!</h4>
                                        <h4 id="msgRetornoErro8" style='color: #a94442;'>Erro</h4>
                                        <span style='cursor: pointer; color: #3071A9; font-size: 12px;' 
                                            onmouseover=javascript:this.style.textDecoration='underline' onmouseleave=javascript:this.style.textDecoration='none'
                                            onclick=javascript:LiberarObjNovoEnvio('divFup8Msg','ctl00_head_fup8','pSize8'); 
                                            title='Clique para enviar outro arquivo'>[Clique aqui para enviar outro arquivo]</span>
                                    </div>
                                </td>
                                <td style="vertical-align: middle !important; width: 100px;">
                                    <h5 id="pSize8">
                                    </h5>
                                    <span id="spamMaxMB8" style="color: #a94442; font-size: 10px;" />
                                </td>
                                <td style="vertical-align: middle !important;">
                                    <table border="0" cellpadding="0" cellspacing="3">
                                        <tr style="height: 60px">
                                            <td style="width: 120px; vertical-align: middle; text-align: center;">
                                                <button type="submit" class="btn btn-primary start" id="btnEnviar8" disabled>
                                                    <i class="glyphicon glyphicon-upload"></i><span>&nbsp;&nbsp;Enviar</span>
                                                </button>
                                            </td>
                                            <td style="width: 120px; vertical-align: middle; text-align: center;">
                                                <button type="submit" class="btn btn-danger delete" id="btnExcluir8" disabled>
                                                    <i class="glyphicon glyphicon-trash"></i><span>&nbsp;&nbsp;Excluir</span>
                                                </button>
                                            </td>
                                            <td style="width: 60px; vertical-align: middle; text-align: center; position: relative;
                                                top: 8px;">
                                                <img id="imgLoadingFile8" style="display: none;" src="../../../Images/Loading32x32.GIF"
                                                    alt="Processando. Aguarde..." /><br />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="tr9" style="display: none; vertical-align: middle !important; height: 70px;
                                border-top: 1px solid #ddd;">
                                <td style="vertical-align: middle !important; width: 20px;">
                                    &nbsp;
                                </td>
                                <td style="vertical-align: middle !important; width: 50px;">
                                    <h4>
                                        09 -
                                    </h4>
                                </td>
                                <td style="vertical-align: middle !important; width: 500px;">
                                    <asp:FileUpload ID="fup9" runat="server" accept=".txt, .xls, .xlsx, .ace, .arc, .arj, .zip, .rar, .tar, .7zip, .gzip, .csv" />
                                    <div id="divFup9Msg" style="display: none;">
                                        <h4 id="msgRetornoSucesso9" style='color: #449D44;'>Arquivo enviado com sucesso!!!</h4>
                                        <h4 id="msgRetornoErro9" style='color: #a94442;'>Erro</h4>
                                        <span style='cursor: pointer; color: #3071A9; font-size: 12px;' 
                                            onmouseover=javascript:this.style.textDecoration='underline' onmouseleave=javascript:this.style.textDecoration='none'
                                            onclick=javascript:LiberarObjNovoEnvio('divFup9Msg','ctl00_head_fup9','pSize9'); 
                                            title='Clique para enviar outro arquivo'>[Clique aqui para enviar outro arquivo]</span>
                                    </div>
                                </td>
                                <td style="vertical-align: middle !important; width: 100px;">
                                    <h5 id="pSize9">
                                    </h5>
                                    <span id="spamMaxMB9" style="color: #a94442; font-size: 10px;" />
                                </td>
                                <td style="vertical-align: middle !important;">
                                    <table border="0" cellpadding="0" cellspacing="3">
                                        <tr style="height: 60px">
                                            <td style="width: 120px; vertical-align: middle; text-align: center;">
                                                <button type="submit" class="btn btn-primary start" id="btnEnviar9" disabled>
                                                    <i class="glyphicon glyphicon-upload"></i><span>&nbsp;&nbsp;Enviar</span>
                                                </button>
                                            </td>
                                            <td style="width: 120px; vertical-align: middle; text-align: center;">
                                                <button type="submit" class="btn btn-danger delete" id="btnExcluir9" disabled>
                                                    <i class="glyphicon glyphicon-trash"></i><span>&nbsp;&nbsp;Excluir</span>
                                                </button>
                                            </td>
                                            <td style="width: 60px; vertical-align: middle; text-align: center; position: relative;
                                                top: 8px;">
                                                <img id="imgLoadingFile9" style="display: none;" src="../../../Images/Loading32x32.GIF"
                                                    alt="Processando. Aguarde..." /><br />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="tr10" style="display: none; vertical-align: middle !important; height: 70px;
                                border-top: 1px solid #ddd;">
                                <td style="vertical-align: middle !important; width: 20px;">
                                    &nbsp;
                                </td>
                                <td style="vertical-align: middle !important; width: 50px;">
                                    <h4>
                                        10 -
                                    </h4>
                                </td>
                                <td style="vertical-align: middle !important; width: 500px;">
                                    <asp:FileUpload ID="fup10" runat="server" accept=".txt, .xls, .xlsx, .ace, .arc, .arj, .zip, .rar, .tar, .7zip, .gzip, .csv" />
                                    <div id="divFup10Msg" style="display: none;">
                                        <h4 id="msgRetornoSucesso10" style='color: #449D44;'>Arquivo enviado com sucesso!!!</h4>
                                        <h4 id="msgRetornoErro10" style='color: #a94442;'>Erro</h4>
                                        <span style='cursor: pointer; color: #3071A9; font-size: 12px;' 
                                            onmouseover=javascript:this.style.textDecoration='underline' onmouseleave=javascript:this.style.textDecoration='none'
                                            onclick=javascript:LiberarObjNovoEnvio('divFup10Msg','ctl00_head_fup10','pSize10'); 
                                            title='Clique para enviar outro arquivo'>[Clique aqui para enviar outro arquivo]</span>
                                    </div>
                                </td>
                                <td style="vertical-align: middle !important; width: 100px;">
                                    <h5 id="pSize10">
                                    </h5>
                                    <span id="spamMaxMB10" style="color: #a94442; font-size: 10px;" />
                                </td>
                                <td style="vertical-align: middle !important;">
                                    <table border="0" cellpadding="0" cellspacing="3">
                                        <tr style="height: 60px">
                                            <td style="width: 120px; vertical-align: middle; text-align: center;">
                                                <button type="submit" class="btn btn-primary start" id="btnEnviar10" disabled>
                                                    <i class="glyphicon glyphicon-upload"></i><span>&nbsp;&nbsp;Enviar</span>
                                                </button>
                                            </td>
                                            <td style="width: 120px; vertical-align: middle; text-align: center;">
                                                <button type="submit" class="btn btn-danger delete" id="btnExcluir10" disabled>
                                                    <i class="glyphicon glyphicon-trash"></i><span>&nbsp;&nbsp;Excluir</span>
                                                </button>
                                            </td>
                                            <td style="width: 60px; vertical-align: middle; text-align: center; position: relative;
                                                top: 8px;">
                                                <img id="imgLoadingFile10" style="display: none;" src="../../../Images/Loading32x32.GIF"
                                                    alt="Processando. Aguarde..." /><br />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr style="display: block; vertical-align: middle !important; height: 70px; border-top: 0px solid #ddd;
                                background-color: #F7F7F7;">
                                <td style="vertical-align: middle !important;" width="20px">
                                    &nbsp;
                                </td>
                                <td style="vertical-align: middle !important;" width="50px">
                                    &nbsp;
                                </td>
                                <td style="vertical-align: middle !important;" width="500px">
                                    &nbsp;
                                </td>
                                <td style="vertical-align: middle !important;" width="100px">
                                    &nbsp;
                                </td>
                                <td style="vertical-align: middle !important; vertical-align: middle !important;">
                                    <button id="btnIncluirMaisArquivos" type="button" class="btn btn-success fileinput-button"
                                        style="margin-left: 17px; margin-top: 10px;">
                                        <i class="glyphicon glyphicon-plus"></i><span>&nbsp;&nbsp;Incluir Mais Arquivos</span>
                                    </button>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <div class="accordion2-section">
                <a class="accordion2-section-title" href="#accordion2-2">Arquivos Enviados</a>
                <div id="accordion2-2" class="accordion2-section-content">
                    <asp:UpdatePanel ID="uppListaUpload" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr align="center" style="height: 0px;">
                                <td colspan="2">
                                    <button type="button" runat="server" class="btn btn-primary start" id="btnAtualizarListaArqEnviados1" 
                                        onserverclick="btnAtualizarListaArqEnviados_Click">
                                        <i class="glyphicon glyphicon-refresh"></i><span>&nbsp;&nbsp;Atualizar Lista</span>
                                    </button>
                                </td>
                                
                                </tr>
                                <tr style="height:40px;">
                                    <td style="width: 320px; vertical-align:middle; position:relative; left:2px;">
                                        <asp:Label ID="Label12" runat="server" Text="Arquivos Enviados nos Últimos: " CssClass="LabelSize14"></asp:Label>
                                        <asp:DropDownList ID="ddlListarArquivosUploadPeriodo" runat="server" CssClass="LabelSize14" AutoPostBack="True" OnSelectedIndexChanged="ddlListarArquivosUploadPeriodo_SelectedIndexChanged">
                                            <asp:ListItem Value="1">01 dia</asp:ListItem>
                                            <asp:ListItem Value="5">05 dias</asp:ListItem>
                                            <asp:ListItem Value="10">10 dias</asp:ListItem>
                                            <asp:ListItem Value="20">20 dias</asp:ListItem>
                                            <asp:ListItem Value="30">30 dias</asp:ListItem>
                                            <asp:ListItem Value="60">60 dias</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                    <div style="height:0px;">
                                    <asp:UpdateProgress ID="upprog" runat="server" AssociatedUpdatePanelID="uppListaUpload" DisplayAfter="100">
                                    <ProgressTemplate>
                                        <table border="0" cellpadding="0" cellspacing="0" style="margin-left: 10px;">
                                            <tr>
                                                <td>
                                                    <img src="../../../images/loading.gif" alt="Loading..." />
                                                </td>
                                                <td>
                                                    <h5 style="color: gray; font-weight: normal; margin-left: 10px;">
                                                    AGUARDE... PROCESSANDO SOLICITAÇÃO.</h2>
                                                </td>
                                            </tr>
                                        </table>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                </div>
                                </td>
                            </tr>
                        </table>
                        <asp:GridView ID="gridResultUpload" runat="server" 
                            AutoGenerateColumns="False" EnableModelValidation="True" Width="100%" 
                            onrowdatabound="gridResultUpload_RowDataBound">
                            <Columns>
                                <asp:BoundField HeaderText="Descrição" DataField="NomeExtensao">
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="gridFtpOnlineItem" Wrap="true"/>
                                    <HeaderStyle CssClass="gridFtpOnlineHeader" HorizontalAlign="Center"  />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Tamanho" DataField="Tamanho">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridFtpOnlineItem" />
                                    <HeaderStyle CssClass="gridFtpOnlineHeader" HorizontalAlign="Center" Width="130px"/>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Data de Envio" DataField="DataCriacao">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridFtpOnlineItem" />
                                    <HeaderStyle CssClass="gridFtpOnlineHeader" HorizontalAlign="Center" Width="130px"/>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Hora de Envio" DataField="HoraCriacao">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridFtpOnlineItem" />
                                    <HeaderStyle CssClass="gridFtpOnlineHeader" HorizontalAlign="Center" Width="130px"/>
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Download">
                                    <HeaderStyle CssClass="gridFtpOnlineHeader" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridFtpOnlineItem" Width="130px"/>
                                    <ItemTemplate>
                                            <asp:Button ID="btnDownloadArquivoUpload" runat="server" Text="Download" 
                                            CommandName="Download" Style="cursor: pointer;" ToolTip="Fazer download deste arquivo"
                                            CssClass="btn btn-success" OnDataBinding="PostBackBind_DataBinding"
                                            onclick="btnDownloadArquivoUpload_Click" OnClientClick="document.forms[0].target = '_blank';"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Excluir">
                                    <HeaderStyle CssClass="gridFtpOnlineHeader" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridFtpOnlineItem" Width="130px"/>
                                    <ItemTemplate>
                                        <asp:Button ID="btnExcluirArquivoUpload" runat="server" Text="Excluir" 
                                            CommandName="Delete" Style="cursor: pointer;"
                                            ToolTip="Clique para excluir este arquivo" CssClass="btnCustom-danger"
                                            OnClientClick="return confirm('Deseja realmente excluir este arquivo?');" 
                                            onclick="btnExcluirArquivoUpload_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnAtualizarListaArqEnviados1" 
                                EventName="ServerClick" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <br />
                </div>
            </div>
            <div class="accordion2-section">
                <a class="accordion2-section-title active" href="#accordion2-3">Arquivos Processados</a>
                <div id="accordion2-3" class="accordion2-section-content">
                    <asp:UpdatePanel ID="uppListaProcessados" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr align="center" style="height: 0px;">
                                <td colspan="2">
                                    <button type="button" runat="server" class="btn btn-primary start" id="btnAtualizarListaArqProcessados" 
                                        onserverclick="btnAtualizarListaArqProcessados_Click">
                                        <i class="glyphicon glyphicon-refresh"></i><span>&nbsp;&nbsp;Atualizar Lista</span>
                                    </button>
                                </td>
                                
                                </tr>
                                <tr style="height:40px;">
                                    <td style="width: 350px; vertical-align:middle; position:relative; left:2px;">
                                        <asp:Label ID="Label2" runat="server" Text="Arquivos Processados nos Últimos: " CssClass="LabelSize14"></asp:Label>
                                        <asp:DropDownList ID="ddlListarArquivosProcessadosPeriodo" runat="server" CssClass="LabelSize14" AutoPostBack="True" OnSelectedIndexChanged="ddlListarArquivosProcessadosPeriodo_SelectedIndexChanged">
                                            <asp:ListItem Value="1">01 dia</asp:ListItem>
                                            <asp:ListItem Value="5">05 dias</asp:ListItem>
                                            <asp:ListItem Value="10">10 dias</asp:ListItem>
                                            <asp:ListItem Value="20">20 dias</asp:ListItem>
                                            <asp:ListItem Value="30">30 dias</asp:ListItem>
                                            <asp:ListItem Value="60">60 dias</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                    <div style="height:0px;">
                                    <asp:UpdateProgress ID="upprogPro" runat="server" AssociatedUpdatePanelID="uppListaProcessados" DisplayAfter="100">
                                    <ProgressTemplate>
                                        <table border="0" cellpadding="0" cellspacing="0" style="margin-left: 10px;">
                                            <tr>
                                                <td>
                                                    <img src="../../../images/loading.gif" alt="Loading..." />
                                                </td>
                                                <td>
                                                    <h5 style="color: gray; font-weight: normal; margin-left: 10px;">
                                                    AGUARDE... PROCESSANDO SOLICITAÇÃO.</h2>
                                                </td>
                                            </tr>
                                        </table>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                </div>
                                </td>
                            </tr>
                        </table>
                        <asp:GridView ID="gridResultProcessados" runat="server" 
                            AutoGenerateColumns="False" EnableModelValidation="True" Width="100%" 
                            onrowdatabound="gridResultProcessados_RowDataBound" 
                        onrowdeleting="gridResultProcessados_RowDeleting">
                            <Columns>
                                <asp:BoundField HeaderText="Descrição" DataField="NomeExtensao">
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="gridFtpOnlineItem" Wrap="true"/>
                                    <HeaderStyle CssClass="gridFtpOnlineHeader" HorizontalAlign="Center"  />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Tamanho" DataField="Tamanho">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridFtpOnlineItem" />
                                    <HeaderStyle CssClass="gridFtpOnlineHeader" HorizontalAlign="Center" Width="130px"/>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Data de Processamento" DataField="DataCriacao">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridFtpOnlineItem" />
                                    <HeaderStyle CssClass="gridFtpOnlineHeader" HorizontalAlign="Center" Width="130px"/>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Hora de Processamento" DataField="HoraCriacao">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridFtpOnlineItem" />
                                    <HeaderStyle CssClass="gridFtpOnlineHeader" HorizontalAlign="Center" Width="130px"/>
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Download">
                                    <HeaderStyle CssClass="gridFtpOnlineHeader" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridFtpOnlineItem" Width="130px"/>
                                    <ItemTemplate>
                                            <asp:Button ID="btnDownloadArquivoProcessado" runat="server" Text="Download" 
                                            CommandName="Download" Style="cursor: pointer;" ToolTip="Fazer download deste arquivo"
                                            CssClass="btn btn-success" OnDataBinding="PostBackBind_DataBinding"
                                            onclick="btnDownloadArquivoProcessado_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Excluir">
                                    <HeaderStyle CssClass="gridFtpOnlineHeader" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridFtpOnlineItem" Width="130px"/>
                                    <ItemTemplate>
                                        <asp:Button ID="btnExcluirArquivoProcessado" runat="server" Text="Excluir" 
                                            CommandName="Delete" Style="cursor: pointer;"
                                            ToolTip="Clique para excluir este arquivo" CssClass="btnCustom-danger"
                                            OnClientClick="return confirm('Deseja realmente excluir este arquivo?');" 
                                            onclick="btnExcluirArquivoProcessado_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnAtualizarListaArqProcessados" 
                                EventName="ServerClick" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <br />
                </div>
            </div>
        </div>
    </div>
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
