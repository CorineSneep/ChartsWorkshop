# Workshop Charts

In deze workshop gaan we een bar chart toevoegen aan de homepagina van een web app.

## Charts maken met chart.js

#### 1. Maak een nieuw ASP.net core Web Application (mvc)
#### 2. Maak een View Model voor de chart:
    public class CityChartViewModel
    {
        public string name { get; set; }
        public int price { get; set; }
    }
    
#### 3. Voeg dummi code toe aan de homecontroller
    Random rnd = new Random();
    
    var lstModel = new List<CityChartViewModel>();
    lstModel.Add( new CityChartViewModel
    {  
        name = "Amsterdam",  
        price = rnd.Next( 10 )  
    } );
    lstModel.Add(new CityChartViewModel
    {
        name = "Arnhem",
        price = rnd.Next(10)
    });
    lstModel.Add(new CityChartViewModel
    {
        name = "Nijmegen",
        price = rnd.Next(10)
    });
    lstModel.Add(new CityChartViewModel
    {
        name = "Amersfoort",
        price = rnd.Next(10)
    });
    lstModel.Add(new CityChartViewModel
    {
        name = "Utrecht",
        price = rnd.Next(10)
    });
#### 4. Geef de data mee aan de view
    return View(lstModel);

### Aanpassen van de view

#### 1. Voeg de volgende script-tag toe. Hierdoor kan je gebruik maken van chart.js
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.3/Chart.bundle.min.js"></script>
#### 2. Voor het weergeven van de chart voeg je een canvas toe
    <div class="chart-container">
        <canvas id="chart" style="width:100%; height:500px"></canvas>
    </div>
#### 3. Om gebruik te maken van de data uit de controller voeg je bovenaan het view model toe. 
    @model List<Charts_Workshop.ViewModels.CityChartViewModel>
#### 4. Omdat chart.js gebruik maakt van de losse waardes in JSON voegen we hier ook nog de volgende code toe
    @using System.Text.Json
    @{
        var Xlabels = JsonSerializer.Serialize(Model.Select(x => x.name).ToList());
        var YValues = JsonSerializer.Serialize(Model.Select(x => x.price).ToList());
    }

### Maken van de chart

#### 1. Voeg script tags toe voor het maken van de chart
#### 2. Haal het element van je canvas op
    var chartName = "chart";
    var ctx = document.getElementById(chartName).getContext('2d');
#### 3. Geef de chart de goede data
    var data = {
        labels: @Html.Raw(Xlabels),
        datasets: [{
            label: "Products Chart",
            borderWidth: 1,
            data: @Html.Raw(YValues)
        }]
    };
#### 4. Geef de chart de instellingen die jij wilt hebben. Hier is een voorbeeld gegeven. Meer opties zijn te vinden in de documentatie van chart.js
    var options = {
        scales: {
            yAxes: [{
                scaleLabel: {
                    display: true,
                    labelString: "price"
                },
                ticks: {
                    min: 0,
                    beginAtZero: true
                },
                gridLines: {
                    display: true,
                    color: "rgba(255,99,164,0.2)"
                }
            }],
            xAxes: [{
                scaleLabel: {
                    display: true,
                    labelString: "city's"
                },
                gridLines: {
                    display: false
                }
            }]
        }
    };
#### 5. Maak als laatste daadwerkelijk de chart aan
    var myChart = new  Chart(ctx, {
        options: options,
        data: data,
        type:'bar'

    });
    
