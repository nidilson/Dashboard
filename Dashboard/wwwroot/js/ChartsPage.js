
var barChartData = {
    labels: [],
    data: []
}
var pieChartData = {
    labels: [],
    data: []
}
var lineChartData = {
    labels: [],
    data: []
}
var horBarChartData = {
    labels: [],
    data: []
}
var dataRadarChart;
var radarChart;

var pokemonList = [];
var pokemonSelected;

const primaryColorSemiTrasparent = "rgba(62,142,126,0.7)";
const primaryColor = "rgba(62,142,126,1)";
var input;
var options;

/**
 * Método que se ejecuta al cargar DOM
 */
document.addEventListener("DOMContentLoaded", async () => {
    await GetCountryData();
    LoadBarChart();
    LoadPieChart();
    LoadLineChart();
    LoadHorBarChart();
    await GetPokemonData();
    loadPokemonData(1);
    AddEventListeners();
    


})

/**
 * Función que añade event listeners a la selección de pokemon
 */
function AddEventListeners() {
    input = document.getElementById("pokemon-input");
    options = document.querySelectorAll(".pokemon-option");

    options.forEach(e => {
        e.addEventListener("click", evt => {
            options.forEach(select => {
                select.classList.remove("selected")
            });
            evt.target.classList.add("selected");
            loadPokemonData(evt.target.dataset.id);
        });
    })

    input.addEventListener("input", evt => {
        var val = input.value;
        options.forEach(opt => {
            opt.classList.remove("option-hidden");
            opt.classList.remove("selected");
            if (val == "") {
                return;
            }
            if (opt.dataset.value.indexOf(val) == -1) {
                opt.classList.add("option-hidden")
            }
        })
    });
}

/**
 * Función que carga las estadísticas de un pokemon
 * @param {any} id - ID de pokemon a buscar
 */
async function loadPokemonData(id) {
    await fetch(`/home/PokemonStats/${id}`, {
        method: "GET",
        headers: {
            "Content-Type": "application/json"
        }
    })
        .then(response => {
            let res = response.json();
            if (!response.ok) {
                throw new Error(res.message);
            }
            return res;
        })
        .then(data => {
            dataRadarChart = {
                labels: data.labels,
                datasets: [{
                    label: data.name,
                    data: data.data,
                    fill: true,
                    backgroundColor: primaryColorSemiTrasparent,
                    borderColor: primaryColor,
                    pointBackgroundColor: primaryColor,
                    pointBorderColor: primaryColor,
                    pointHoverBackgroundColor: '#fff',
                    pointHoverBorderColor: 'rgb(255, 99, 132)'
                }]
            };

            let pokemonImg = document.getElementById("sprite");
            pokemonImg.setAttribute("src", data.sprite);
            if (radarChart != undefined) {
                UpdateRadarChart();
            } else {
                CreateRadarChart();
            }
        })
        .catch(err => {
            alert("Hubo un error al cargar los datos" + err.message);
        })
}

/**
 * Función que obtiene los datos de los países
 */
async function GetCountryData(){
    await fetch("/Home/Countries", {
        method: "GET",
        headers: {
            "Content-Type" : "application/json"
        }
    })
        .then(response => {
            if(!response.ok){
                throw new Error(response.message)
            }
            return response.json();
        })
        .then(data => {
            barChartData.labels = data.bar.labels;
            barChartData.data = data.bar.data;

            pieChartData.labels = data.pie.labels;
            pieChartData.data = data.pie.data;

            lineChartData.labels = data.line.labels;
            lineChartData.data = data.line.data;

            horBarChartData.labels = data.horBar.labels;
            horBarChartData.data = data.horBar.data;
        })
        .catch(error => {
            alert(error.message);
        })
}

/**
 * Función que obtiene los nombres de los pokemon 1ra generación
 */
async function GetPokemonData() {
    await fetch("/Home/Pokemons", {
        method: "GET",
        headers: {
            "Content-Type": "application-json"
        }
    })
        .then(response => {
            let res = response.json();
            if (!response.ok) {
                throw new Error(res.message);
            }
            return res;
        })
        .then(data => {
            pokemonList = data.pok;
            CreatePokemonOptions();
        })
        .catch(err => {
            alert(`Error: ${err.message}`)
        })
}

/**
 * Función que agrega las opciones de los pokemones a escoger para ver sus estadísticas
 */
function CreatePokemonOptions() {
    let labelsContainer = document.getElementById("options");

    pokemonList.forEach(pokemon => {
        labelsContainer.appendChild(createLabel(pokemon.name, pokemon.url))
    })
}

/**
 * Función que carga los datos al gráfico de barras
 */
function LoadBarChart() {
    new Chart(
        document.getElementById('bar-chart-canvas'),
        {
            type: 'bar',
            data: {
                labels: barChartData.labels,
                datasets: [
                    {
                        label: 'Cantidad de Países',
                        data: barChartData.data,
                        backgroundColor: primaryColorSemiTrasparent,
                        borderColor: primaryColor,
                        borderWidth: 3
                    }
                ]
            },
            responsive: true,
            mantainAspectRatio: true
        }
    );
}

/**
 * Función que carga los datos al gráfico de pie
 */
function LoadPieChart() {
    new Chart(
        document.getElementById('pie-chart-canvas'),
        {
            type: 'pie',
            data: {
                labels: pieChartData.labels,
                datasets: [
                    {
                        label: 'Area en m2',
                        data: pieChartData.data
                    }
                ]
            },
            responsive: true,
            mantainAspectRatio: true
        }
    );
}

/**
 * Función que carga el gráfico de lineas
 */
function LoadLineChart() {
    new Chart(
        document.getElementById('line-chart-canvas'),
        {
            type: 'line',
            data: {
                labels: lineChartData.labels,
                datasets: [
                    {
                        label: 'Cantidad de Población',
                        data: lineChartData.data,
                        backgroundColor: primaryColorSemiTrasparent,
                        borderColor: primaryColor,
                        borderWidth: 3
                    }
                ]
            },
            responsive: true,
            mantainAspectRatio: true
        }
    );
}

/**
 * Función que carga el gráfico de barras horizontales
 */
function LoadHorBarChart() {
    new Chart(
        document.getElementById('hor-bar-chart-canvas'),
        {
            type: 'bar',
            data: {
                labels: horBarChartData.labels,
                datasets: [
                    {
                        label: 'Población/KM2',
                        data: horBarChartData.data,
                        backgroundColor: primaryColorSemiTrasparent,
                        borderColor: primaryColor,
                        borderWidth: 3
                    }
                ]
            },
            responsive: true,
            mantainAspectRatio: true,
            options: {
                indexAxis: 'y'
            }
        }
    );
}

/**
 * Función que crea un option con los datos de un pokemon
 * @param {any} name - Nombre del pokemon
 * @param {any} url - Url donde se encuentran los datos del pokemon
 * @returns Elemento option con los datos
 */
function createLabel(name, url) {
    let label = document.createElement("label");
    label.classList.add("pokemon-option");
    let arrayUrl = url.split("/")
    label.dataset.id = arrayUrl[arrayUrl.length - 2];
    label.dataset.value = name;

    let content = document.createTextNode(name);

    label.appendChild(content);

    return label;
}

/**
 * Función que actualiza los datos en gráfico de radar, primero destruye el gráfico
 * actual (Si existe) y luego lo vuelve a crear con los datos actualizados
 */
function CreateRadarChart() {
    radarChart = new Chart(
        document.getElementById('radar-chart-canvas'),
        {
            type: 'radar',
            data: dataRadarChart,
            responsive: true,
            mantainAspectRatio: true,
            options: {
                scales: {
                    r: {
                        angleLines: {
                            display: false
                        },
                        suggestedMin: 0,
                        suggestedMax: 150
                    }
                }
            }
        }
    );


}

function UpdateRadarChart() {
    radarChart.data = dataRadarChart;
    radarChart.update();
}