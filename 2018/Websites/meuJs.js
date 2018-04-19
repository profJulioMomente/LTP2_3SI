$(document).ready(function () {
    $("#txtCEP").mask("aaa-9999");
    $("#titulo1").text("LTP2");

    $("#txtNumero").keypress(function (tecla) {
        return somenteNumeros(tecla);
    });

    $("#txtSobrenome").blur(function () {
        var cpf = $("#txtSobrenome").val();
        var isValido = TestaCPF(cpf);

        if (!isValido) {
            alert("O CPF não é válido!");
        }
    });

    /*$("#btnOk").click(function () {
        var tamanho = $("#txtCEP").val().length;
        if (tamanho != 9) {
            $("#txtCEP").removeClass("sucess");
            $("#txtCEP").addClass("erro");
            $("#txtCEP").focus();
        } else {
            $("#txtCEP").removeClass("erro");
            $("#txtCEP").addClass("sucess");
        }
    });
    
    $("#txtCEP").keypress(function () {
        var tamanho = $(this).val().length;
        //alert(tamanho);
        if (tamanho == 5) {
            $(this).val($(this).val() + "-");
        }
    });
    */
});

function somenteNumeros(tecla) {
    var codigo = tecla.keyCode || tecla.which;
    if (codigo != 8 && codigo != 9 && codigo != 13 && codigo != 46) {
        if (codigo >= 48 && codigo <= 57) {
            return true;
        } else {
            return false;
        }
    }
}

function TestaCPF(strCPF) {
    var Soma;
    var Resto;
    Soma = 0;
    if (strCPF == "00000000000" ||
        strCPF == "11111111111" ||
        strCPF == "22222222222" ||
        strCPF == "33333333333" ||
        strCPF == "44444444444" ||
        strCPF == "55555555555" ||
        strCPF == "66666666666" ||
        strCPF == "77777777777" ||
        strCPF == "88888888888" ||
        strCPF == "99999999999") {
        return false;
    }

    for (i = 1; i <= 9; i++) {
        Soma = Soma + parseInt(strCPF.substring(i - 1, i)) * (11 - i);
    }
    Resto = (Soma * 10) % 11;

    if ((Resto == 10) || (Resto == 11)) {
        Resto = 0;
    }
    if (Resto != parseInt(strCPF.substring(9, 10))) {
        return false;
    }

    Soma = 0;
    for (i = 1; i <= 10; i++) {
        Soma = Soma + parseInt(strCPF.substring(i - 1, i)) * (12 - i);
    }
    Resto = (Soma * 10) % 11;

    if ((Resto == 10) || (Resto == 11)) {
        Resto = 0;
    }
    if (Resto != parseInt(strCPF.substring(10, 11))) {
        return false;
    }
    return true;
}