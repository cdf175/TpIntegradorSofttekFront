var token = getCookie("Token");

let table = new DataTable('#services', {
    ajax: {
        url: `https://localhost:7238/api/service`,
        dataSrc: "data",
        headers: { "Authorization": "Bearer " + token }
    },
    columns: [
        { data: 'id', title: 'Codigo' },
        { data: 'description', title: 'Descripcion' },
        { data: 'state', title: 'Activo' },
        { data: 'hourValue', title: 'Precio por Hora' },
        {
            data: function (data) {              
                return `<td><a href='javascript:editService(${JSON.stringify(data)})'><i class="fa-solid fa-pen-to-square "></i></td>`;
            }
        },
        {
            data: function (data) {
                return `<td><a href='javascript:deleteService(${JSON.stringify(data)})'><i class="fa-solid fa-trash "></i></td>`;
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


function addService() {
    debugger
    $.ajax({
        type: "GET",
        url: "/Service/ServiceAddPartial",
        data: "",
        contentType: 'application/json',
        'dataType': "html",
        success: function (result) {
            $('#serviceAddPartial').html(result);
            $('#serviceModal').modal('show');
        }

    });
}

function editService(data) {
    debugger
    $.ajax({
        type: "POST",
        url: "/Service/ServiceAddPartial",
        data: JSON.stringify(data),
        contentType: 'application/json',
        'dataType': "html",
        success: function (result) {
            $('#serviceAddPartial').html(result);
            $('#serviceModal').modal('show');
        }

    });
}

function deleteService(data) {
    debugger
    $.ajax({
        type: "POST",
        url: "/Service/ServiceDeletePartial",
        data: JSON.stringify(data),
        contentType: 'application/json',
        'dataType': "html",
        success: function (result) {
            $('#serviceDeletePartial').html(result);
            $('#serviceDModal').modal('show');
        },
        error: function () { }

    });
}
