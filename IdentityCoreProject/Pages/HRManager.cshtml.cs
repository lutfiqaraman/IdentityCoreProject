using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityCoreProject.Pages
{
    [Authorize(Policy = "HRManager")]
    public class HRManagerModel : PageModel
    {
        private readonly IHttpClientFactory HttpClientFactory;

        public HRManagerModel(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
        }

        public void OnGet()
        {
            HttpClient? httpClient = 
                HttpClientFactory.CreateClient("WebAPI");

        }
    }
}
