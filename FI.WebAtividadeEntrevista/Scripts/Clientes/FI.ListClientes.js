$(document).ready(function () {
    if (document.getElementById("gridClientes"))
        $('#gridClientes').jtable({
            title: '',
            paging: true,
            pageSize: 5,
            sorting: true,
            defaultSorting: 'Nome ASC',
            actions: {
                listAction: urlClienteList,
            },
            fields: {
                Nome: {
                    title: 'Nome',
                    width: '50%'
                },
                Email: {
                    title: 'Email',
                    width: '35%'
                },
                Acoes: {
                    title: '',
                    width: '15%',
                    display: function (data) {

                        return `
                            <button onclick="window.location.href='${urlAlteracao}/${data.record.Id}'" class="btn btn-primary btn-sm">Alterar</button>
                            <button onclick="excluirCliente(${data.record.Id})" class="btn btn-danger btn-sm ms-2">Excluir</button>
                        `;
                    }
                }
            },
        });

    if (document.getElementById("gridClientes"))
        $('#gridClientes').jtable('load');
});

function excluirCliente(id) {

    var modal = new bootstrap.Modal(document.getElementById('modalConfirmacao'));
    modal.show();

    $('#confirmarExclusao').off('click').on('click', function () {

        $.ajax({
            url: '/Cliente/Excluir/' + id,
            type: 'POST',
            success: function (result) {
                modal.hide();
                $('#gridClientes').jtable('reload');

                ModalDialog("Sucesso", "Cliente excluído com sucesso!");
            },
            error: function (err) {
                modal.hide();

                ModalDialog("Erro", "Erro ao excluir cliente: " + err.responseText);
            }
        });
    });
}

function ModalDialog(titulo, texto) {
    var random = Math.random().toString().replace('.', '');

    var modalHtml = `
        <div id="${random}" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                      <h5 class="modal-title"></h5>
                      <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body text-center">
                        <p>${texto}</p>
                    </div>
                </div>
            </div>
        </div>`;

    $('body').append(modalHtml);

    var modal = new bootstrap.Modal(document.getElementById(random));
    modal.show();

    setTimeout(function () {
        modal.hide();
    }, 3000);

    $('#' + random).on('hidden.bs.modal', function () {
        $(this).remove();
    });
}
