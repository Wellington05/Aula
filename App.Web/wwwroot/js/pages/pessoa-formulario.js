$(document).ready(function () {
    loadCidades();
});


function loadCidades() {
    CidadeListaCidades('').then(function (data)
        data.forEah(obj => {
        $('#cidadeId').append('<option value="' + obj.id + '">' + obj.nome + '</option>')
    });
    $('#cidadeId').select2();
});