function BuscaCep() {
    function limpa_formulário_cep() {
        // Limpa valores do formulário de CEP.
        $("#Endereco_Logradouro").val("");
        $("#Endereco_Bairro").val("");
        $("#Endereco_Cidade").val("");
        $("#Endereco_Estado").val("");
    }

    // Quando o campo CEP perde o foco.
    $("#Endereco_Cep").blur(function () {
        // Nova variável "cep" somente com dígitos.
        var cep = $(this).val().replace(/\D/g, '');

        // Verifica se o campo CEP possui valor informado.
        if (cep != "") {
            // Expressão regular para validar o CEP.
            var validacep = /^[0-9]{8}$/;

            // Valida o formato do CEP.
            if (validacep.test(cep)) {
                // Preenche os campos com "..." enquanto consulta o webservice.
                $("#Endereco_Logradouro").val("...");
                $("#Endereco_Bairro").val("...");
                $("#Endereco_Cidade").val("...");
                $("#Endereco_Estado").val("...");

                // Consulta o webservice viacep.com.br/
                $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {
                    if (!("erro" in dados)) {
                        // Atualiza os campos com os valores da consulta.
                        $("#Endereco_Logradouro").val(dados.logradouro);
                        $("#Endereco_Bairro").val(dados.bairro);
                        $("#Endereco_Cidade").val(dados.localidade);
                        $("#Endereco_Estado").val(dados.uf);
                    } else {
                        // CEP pesquisado não foi encontrado.
                        limpa_formulário_cep();
                        alert("CEP não encontrado.");
                    }
                });
            } else {
                // CEP é inválido.
                limpa_formulário_cep();
                alert("Formato de CEP inválido.");
            }
        } else {
            // CEP sem valor, limpa formulário.
            limpa_formulário_cep();
        }
    });
}

// Chama as funções de inicialização
$(document).ready(function () {

    SetModal();
    BuscaCep();

    // Inicializar DataTables apenas se o elemento existir e não estiver inicializado
    if ($('#idTab').length && !$.fn.DataTable.isDataTable('#idTab')) {
        $('#idTab').DataTable({
            language: {
                url: '/lang/Portuguese-Brasil.json'
            }
        });
    }

    // Selecionar e fazer fadeOut da mensagem de erro específica
    $(".msg-error, .msg-success").fadeOut(2500)
});

function SetModal() {
    $(document).ready(function () {
        $(function () {
            $.ajaxSetup({ cache: false });

            $("a[data-modal]").on("click",
                function (e) {
                    $('#myModalContent').load(this.href,
                        function () {
                            $('#myModal').modal({
                                keyboard: true
                            }, 'show');
                            bindForm(this);
                        });
                    return false;
                });
        });
    });
}

function bindForm(dialog) {
    $('form', dialog).submit(function () {
        $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            success: function (result) {
                if (result.success) {
                    $('#myModal').modal('hide');
                    $('#EnderecoTarget').load(result.url); // Carrega o resultado HTML para a div demarcada
                } else {
                    $('#myModalContent').html(result);
                    bindForm(dialog);
                }
            }
        });

        SetModal();
        return false;
    });
}
