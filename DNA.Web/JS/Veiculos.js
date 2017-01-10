function printDiv(divAll) {
    var div1 = document.getElementById(divAll);
    var printContents = div1.innerHTML;
    var originalContents = document.body.innerHTML;
    document.body.innerHTML = printContents;
    window.print();
    document.body.innerHTML = originalContents;
}


function SetMaxLengthVeiculos(tipo) {
    document.getElementById("ctl00_head_txtParametroInformado").value = "";
    document.getElementById("ctl00_head_txtParametroInformado").focus();
    
    if (tipo == "PLACA") {
        document.getElementById("ctl00_head_txtParametroInformado").setAttribute("onkeyup", "Mascara('PLACA', this, event);");
        document.getElementById("ctl00_head_txtParametroInformado").maxLength = '8';
    }
    else if (tipo == "CHASSI") {
        document.getElementById("ctl00_head_txtParametroInformado").setAttribute("onkeyup","Mascara('', this, event);");
        document.getElementById("ctl00_head_txtParametroInformado").maxLength = '20';
    }
    else if (tipo == "CPF") {
        document.getElementById("ctl00_head_txtParametroInformado").setAttribute("onkeyup", "Mascara('CPF', this, event);");
        document.getElementById("ctl00_head_txtParametroInformado").maxLength = '14';
    }
    else if (tipo == "CNPJ") {
        document.getElementById("ctl00_head_txtParametroInformado").setAttribute("onkeyup", "Mascara('CNPJ', this, event);");
        document.getElementById("ctl00_head_txtParametroInformado").maxLength = '18';
    }
    else {
        document.getElementById("ctl00_head_txtParametroInformado").setAttribute("onkeyup","Mascara('', this, event);");
        document.getElementById("ctl00_head_txtParametroInformado").maxLength = '30';
    }
}

function ValidaPlacaChassiPrecificador() {
    var placa = Trim(document.getElementById('txtPlaca').value);
    var chassi = Trim(document.getElementById('txtChassi').value);

    if (placa.length == 0 && chassi.length == 0) {

        alert('Informe a Placa ou o Chassi do veículo.');

        return false;
    }
    window.setTimeout("disableButton('" + window.event.srcElement.id + "')", 0);
    return true;
}

function ValidaPlacaChassiAgregado() {

    var placa = Trim(document.getElementById('txtPlaca').value);
    var chassi = Trim(document.getElementById('txtChassi').value);

    if (placa.length == 0 && chassi.length == 0) {

        alert('Informe a Placa ou o Chassi do veículo.');

        return false;
    }
    window.setTimeout("disableButton('" + window.event.srcElement.id + "')", 0);
    return true;
}

