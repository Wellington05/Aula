using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


$(document).Ready(function () {
    load();
});

function load() {
    CidadeListaCidades().then(function (data) {
        data.forEach(obj => {
            $('#table tbody').append('' +
                '<tr id="obj-' + obj.id + '">' +
                '<td>' + (obj.cep || '--') + '</td>' +
                '<td>' + (obj.nome || '--') + '</td>' +
                '<td>' + (obj.uf || '--') + '</td>' +
                '</tr');
        });
    });
}

    
    
