$(document).ready(function () {
    $("#titulo1").text("LTP2");

    $("#btnOk").click(function () {
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
});