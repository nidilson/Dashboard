
var barChartData = {
    labels: [],
    data: []
}
const primaryColorSemiTrasparent = "rgba(62,142,126,0.7)";
const primaryColor = "rgba(62,142,126,1)";

document.addEventListener("DOMContentLoaded", async () => {
    await ObtenerDatosPaises();
    LoadBarChart();
})
async function ObtenerDatosPaises(){
    await fetch("/Home/CountryData", {
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
        })
        .catch(error => {
            alert(error.message);
        })
}
function LoadBarChart() {
    new Chart(
        document.getElementById('bar-chart-canvas'),
        {
            type: 'bar',
            data: {
                labels: barChartData.labels,
                datasets: [
                    {
                        label: 'Países por región',
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