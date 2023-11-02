var token = getCookie("Token");

let table = new DataTable('#works', {
    ajax: {
        url: `https://localhost:7238/api/work`,
        dataSrc: "data",
        headers: { "Authorization": "Bearer " + token }
    },
    columns: [
        { data: 'id', title: 'Codigo' },
        { data: 'date', title: 'Fecha' },
        { data: 'hourQuantity', title: 'Cantidad de horas' },
        { data: 'hourValue', title: 'Valor hora' },
        { data: 'cost', title: 'Total' },
        { data: 'proyect.name', title: 'Proyecto' },
        { data: 'service.description', title: 'Servicio' },
        {
            data: function (data) {              
                return `<td><a href='javascript:editWork(${JSON.stringify(data)})'><i class="fa-solid fa-pen-to-square "></i></td>`;
            }
        },
        {
            data: function (data) {
                return `<td><a href='javascript:deleteWork(${JSON.stringify(data)})'><i class="fa-solid fa-trash "></i></td>`;
            }
        }

    ],
    "language": {
        "lengthMenu": "Mostrar _MENU_ registros por pagina",
        "zeroRecords": "No se encontraron resgistros - sorry",
        "info": "Pagina _PAGE_ de _PAGES_",
        "infoEmpty": "No hay registros disponibles",
        "infoFiltered": "(Filtrada de _MAX_ registros totales)",
        "search": "Buscar: ",
        "paginate": {
            "first": "Primero",
            "last": "Ultimo",
            "next": "Siguiente",
            "previous": "Anterior"
        }
    }
});


function addWork() {
    debugger
    $.ajax({
        type: "GET",
        url: "/Work/WorkAddPartial",
        data: "",
        contentType: 'application/json',
        'dataType': "html",
        success: function (result) {
            $('#workAddPartial').html(result);
            $('#workModal').modal('show');
        }

    });
}

function editWork(data) {
    debugger
    $.ajax({
        type: "POST",
        url: "/Work/WorkAddPartial",
        data: JSON.stringify(data),
        contentType: 'application/json',
        'dataType': "html",
        success: function (result) {
            $('#workAddPartial').html(result);
            $('#workModal').modal('show');
        }

    });
}

function deleteWork(data) {
    debugger
    $.ajax({
        type: "POST",
        url: "/Work/WorkDeletePartial",
        data: JSON.stringify(data),
        contentType: 'application/json',
        'dataType': "html",
        success: function (result) {
            $('#workDeletePartial').html(result);
            $('#workDModal').modal('show');
        },
        error: function () { }

    });
}