$(document).ready(function () {

    if (obj) {
        
        $('#formCadastro #Nome').val(obj.Nome);
        $('#formCadastro #CEP').val(obj.CEP);
        $('#formCadastro #CPF').val(obj.CPF);
        $('#formCadastro #Email').val(obj.Email);
        $('#formCadastro #Sobrenome').val(obj.Sobrenome);
        $('#formCadastro #Nacionalidade').val(obj.Nacionalidade);
        $('#formCadastro #Estado').val(obj.Estado);
        $('#formCadastro #Cidade').val(obj.Cidade);
        $('#formCadastro #Logradouro').val(obj.Logradouro);
        $('#formCadastro #Telefone').val(obj.Telefone);

        if (obj.Beneficiarios && obj.Beneficiarios.length > 0) {
            obj.Beneficiarios.forEach(function (beneficiario) {
                beneficiarios.push({
                    cpf: beneficiario.CPF,
                    nome: beneficiario.Nome
                });
            });
            atualizarListaBeneficiarios();
        }
    }

    $('#formCadastro').submit(function (e) {
        e.preventDefault();

        var cpf = $(this).find("#CPF").val();

        if (!validarCPF(cpf)) {
            ModalDialog("", "CPF inválido.");
            return;
        }

        var beneficiariosData = beneficiarios.map(function (beneficiario) {
            return { cpf: beneficiario.cpf, nome: beneficiario.nome };
        });

        $.ajax({
            url: urlPost,
            method: "POST",
            data: {
                "NOME": $(this).find("#Nome").val(),
                "CEP": $(this).find("#CEP").val(),
                "CPF": $(this).find("#CPF").val(),
                "Email": $(this).find("#Email").val(),
                "Sobrenome": $(this).find("#Sobrenome").val(),
                "Nacionalidade": $(this).find("#Nacionalidade").val(),
                "Estado": $(this).find("#Estado").val(),
                "Cidade": $(this).find("#Cidade").val(),
                "Logradouro": $(this).find("#Logradouro").val(),
                "Telefone": $(this).find("#Telefone").val(),
                "Beneficiarios": beneficiariosData
            },
            error: function (r) {
                if (r.status == 400)
                    ModalDialog("Ocorreu um erro", r.responseJSON);
                else if (r.status == 500)
                    ModalDialog("Ocorreu um erro", "Ocorreu um erro interno no servidor.");
            },
            success: function (r) {
                ModalDialog("Sucesso!", r)
            }
        });
    });
});

function ModalDialog(titulo, texto) {
    var random = Math.random().toString().replace('.', '');
    var modalHtml = `
        <div id="${random}" class="modal fade">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title"></h4>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body text-center">
                        <p>${texto}</p>
                    </div>
                </div>
            </div>
        </div>
    `;

    $('body').append(modalHtml);
    var $modal = $('#' + random);
    $modal.modal('show');

    setTimeout(function () {
        $modal.modal('hide');

        $modal.on('hidden.bs.modal', function () {
            $modal.remove();
        });
    }, 3000);
}

$('#btnAbrirModalBeneficiarios').on('click', function () {
    $('#modalBeneficiarios').modal('show');
});

$(document).ready(function () {
    $('.cpf').mask('000.000.000-00');
});

$(document).ready(function () {
    $('#CEP').mask('00000-000');
});

$(document).ready(function () {
    $('#Telefone').mask('(00) 00000-0000');
});