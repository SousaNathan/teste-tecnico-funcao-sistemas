var beneficiarios = [];

function incluirBeneficiario() {
    var cpf = $('#cpf').val();
    var nome = $('#nome').val();

    if (!validarCPF(cpf)) {
        ModalDialog("", "CPF inválido.");
        return;
    }

    if (cpf && nome) {
        
        var cpfLimpo = cpf.replace(/\D/g, '');

        var cpfExiste = beneficiarios.some(function (beneficiario) {
            return beneficiario.cpf.replace(/\D/g, '') === cpfLimpo;
        });

        if (cpfExiste) {
            ModalDialog("Erro", "Beneficiário com este CPF já foi adicionado.");
        } else {
            beneficiarios.push({ cpf: cpf, nome: nome.toUpperCase() });
            atualizarListaBeneficiarios();
            $('#cpf').val('');
            $('#nome').val('');
        }
    } else {
        ModalDialog("Preencha todos os campos.");
    }
}

function excluirBeneficiario(cpf) {
    beneficiarios = beneficiarios.filter(function (beneficiario) {
        return beneficiario.cpf !== cpf;
    });
    atualizarListaBeneficiarios();
}

function atualizarListaBeneficiarios() {
    $('#listaBeneficiarios').empty();
    beneficiarios.forEach(function (beneficiario) {
        var cpfFormatado = beneficiario.cpf.replace(/^(\d{3})(\d{3})(\d{3})(\d{2})$/, "$1.$2.$3-$4");
        var linha = `
            <tr>
                <td class="cpf">${cpfFormatado}</td>
                <td>${beneficiario.nome}</td>
                <td>
                    <button class="btn btn-outline-danger btn-sm" onclick="excluirBeneficiario('${beneficiario.cpf}')">Excluir</button>
                </td>
            </tr>
        `;
        $('#listaBeneficiarios').append(linha);
    });
}

$(document).ready(function () {

    $('#btnIncluir').on('click', function () {
        incluirBeneficiario();
    });
});