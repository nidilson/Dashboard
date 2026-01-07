var table;
var tableData;
var today = new Date();
var tenYearsAgo = new Date();
var datePicker;

document.addEventListener("DOMContentLoaded", async () => {
    today = new Date();
    tenYearsAgo = new Date();
    tenYearsAgo.setFullYear(today.getFullYear() - 10);

    AddBtnEventListener();
    CreateDatePicker();
    await GetTableData(GetFormatDate(today));
    UpdateTable();
})

/**
 * Función que añade event listener al botón que carga los datos de la fecha seleccionada
 */
function AddBtnEventListener() {
    let btn = document.getElementById("load-btn");
    let date;
    btn.addEventListener("click", async () => {
        date = datePicker.selectedDates[0];
        await GetTableData(GetFormatDate(date));
        UpdateTable();
    })
}

/**
 * Función que crea el date picker
 */
function CreateDatePicker() {
    datePicker = flatpickr("#date", {
        locale: "es",
        dateFormat: "Y-m-d",
        defaultDate: today,
        maxDate: today,
        minDate: tenYearsAgo
    });
}

/**
 * Función que actualiza el DataTable
 */
function UpdateTable() {
    if (table != undefined) {
        table.destroy();
    }
    table = new DataTable("#nasa-table", {
        data: tableData,
        columns: [
            { data: 'id' },
            { data: 'name' },
            { data: 'nasa_jpl_url' },
            { data: 'is_potencially_hazardous' },
            { data: 'velocity' },
            { data: 'max_diam' },
            { data: 'min_diam' }
        ],
        responsive: true
    });
}

/**
 * Función que obtiene datos de los objetos cercanos a la tierra para llenar la tabla
 * @param {any} date - Fecha de la cual se desean obtener los datos de objetos cercanos a la tierra
 */
async function GetTableData(date){
    await fetch(`/Home/NearEarthObjects/${date}`, {
        method: "GET",
        headers: {
            "Content-Type": "application/json"
        }
    })
        .then(response => {
            let res = response.json();
            if (!response.ok) {
                throw new Error(res.message)
            }
            return res;
        })
        .then(data => {
            tableData = data;
        })
        .catch(err => {
            alert(`Hubo un error al cargar la tabla: ${err.message}`);
        })
}

/**
 * Función que da formato "YYYY-MM-DD" a una fecha
 * @param {any} date - Fecha a la que se desea dar formato
 * @returns string con la fecha según el formato "YYYY-MM-DD"
 */
function GetFormatDate(date) {
    let year = date.getFullYear();
    let month = date.getMonth() + 1;
    let day = date.getDate();
    return `${year}-${month.toString().padStart(2, '0')}-${day.toString().padStart(2, '0') }`
}
