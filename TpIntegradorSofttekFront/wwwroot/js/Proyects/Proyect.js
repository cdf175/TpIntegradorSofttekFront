var token = getCookie("Token");

$(function () {
    console.log("aca paso proyect");
    $("#cmbProyetos").append(
        $("<option>").val(1).text("primero")
    )
})

let table = new DataTable('#proyects', {
    ajax: {
        url: `https://localhost:7238/api/proyect`,
        dataSrc: "data",
        headers: { "Authorization": "Bearer " + token }
    },
    columns: [
        { data: 'id', title: 'Codigo' },
        { data: 'name', title: 'Proyecto' },
        { data: 'state', title: 'Estado' },
        { data: 'address', title: 'Direccion' },
        {
            data: function (data) {              
                return `<td><a href='javascript:editProyect(${JSON.stringify(data)})'><i class="fa-solid fa-pen-to-square "></i></td>`;
            }
        },
        {
            data: function (data) {
                return `<td><a href='javascript:deleteProyect(${JSON.stringify(data)})'><i class="fa-solid fa-trash "></i></td>`;
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


function addProyect() {
    debugger
    $.ajax({
        type: "GET",
        url: "/Proyect/ProyectAddPartial",
        data: "",
        contentType: 'application/json',
        'dataType': "html",
        success: function (result) {
            $('#proyectAddPartial').html(result);
            $('#proyectModal').modal('show');
        }

    });
}

function editProyect(data) {
    debugger
    $.ajax({
        type: "POST",
        url: "/Proyect/ProyectAddPartial",
        data: JSON.stringify(data),
        contentType: 'application/json',
        'dataType': "html",
        success: function (result) {
            $('#proyectAddPartial').html(result);
            $('#proyectModal').modal('show');
        }

    });
}

function deleteProyect(data) {
    debugger
    $.ajax({
        type: "POST",
        url: "/Proyect/ProyectDeletePartial",
        data: JSON.stringify(data),
        contentType: 'application/json',
        'dataType': "html",
        success: function (result) {
            $('#proyectDeletePartial').html(result);
            $('#proyectDModal').modal('show');
        },
        error: function () { }

    });
}
