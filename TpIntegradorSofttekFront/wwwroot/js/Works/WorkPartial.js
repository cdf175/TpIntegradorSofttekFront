var token = getCookie("Token");

$(function () {

    fetch("https://localhost:7238/api/service", {
        headers: { Authorization: 'Bearer ' + token }
    }).then(response => {
            return response.ok?response.json() : Promise.reject(response);
    }).then(responseJson => {
        if (responseJson.data.length > 0) {
            responseJson.data.forEach((item) => {
                $("#cmbWorks").append(
                    $("<option>").val(item.id).text(item.description)
                )
            })
        }
    })

    //console.log("aca paso proyect");
    //$("#cmbWorks").append(
    //    $("<option>").val(1).text("primero")
    //)
})
