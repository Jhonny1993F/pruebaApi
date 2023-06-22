using Newtonsoft.Json;
using pruebaApi.Models;
using System.Net;

namespace pruebaApi;

public partial class MainPage : ContentPage
{
	public MainPage()
	{

		InitializeComponent();
	}
    public async void Button_Clicked(object sender, EventArgs e)
    {
        var request = new HttpRequestMessage();
        request.RequestUri = new Uri("http://apiservicios.ecuasolmovsa.com:3009/api/WeatherForecast");
        request.Method = HttpMethod.Get;
        request.Headers.Add("Accept", "application/json");

        var client = new HttpClient();

        HttpResponseMessage response = await client.SendAsync(request);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            String content = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<List<TestApi>>(content);
            ListaTemperatura.ItemsSource = resultado;
        }
    }
}

