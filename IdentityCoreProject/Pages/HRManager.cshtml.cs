using IdentityCoreProject.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Json;

namespace IdentityCoreProject.Pages
{
    [Authorize(Policy = "HRManager")]
    public class HRManagerModel : PageModel
    {
        private readonly IHttpClientFactory HttpClientFactory;

        [BindProperty]
        public List<WeatherForecastDto>? WeatherForecastItems { get; set; }

        public HRManagerModel(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
        }

        public async Task OnGetAsync()
        {
            HttpClient? httpClient = 
                HttpClientFactory.CreateClient("WebAPI");

            WeatherForecastItems = 
                await httpClient.GetFromJsonAsync<List<WeatherForecastDto>>("WeatherForecast");
        }
    }
}
