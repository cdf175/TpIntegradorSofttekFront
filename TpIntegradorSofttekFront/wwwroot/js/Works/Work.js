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
