using Microsoft.AspNetCore.Mvc;
using Assesment3.Services;
using Newtonsoft.Json;
using System.Net;

namespace Assesment3.Controllers
{
    public class StackOverFlowController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService _categoryService;
        private readonly HttpClient _httpClient;

        public StackOverFlowController(ILogger<HomeController> logger,
            ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
            _httpClient = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
            _httpClient.BaseAddress = new Uri("https://api.stackexchange.com/2.3/");


        }




        public async Task<IActionResult> Index()
        {
            try
            {


                var response = await _httpClient.GetAsync("questions?page=1&pagesize=50&order=desc&sort=activity&site=stackoverflow");

                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrWhiteSpace(json))
                {
                    var result = JsonConvert.DeserializeObject<StackOverFlowResponse>(json);
                    return View(result);
                }


            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);

            }

            return View(new StackOverFlowResponse());
        }


        public async Task<IActionResult> Question(long id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/questions/{id}?order=desc&sort=activity&site=stackoverflow");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrWhiteSpace(json))
                {
                    var result = JsonConvert.DeserializeObject<StackOverFlowResponse>(json);
                    if (result != null && result.items.Any())
                        return View(result);
                }

            }
            catch (Exception)
            {
                // ignored
            }

            return RedirectToAction(nameof(Index));
        }
    }

    public class StackOverFlowResponse
    {
        public StackOverFlowResponse()
        {
            items = new List<Item>();
        }
        public List<Item> items { get; set; }
        public class Item
        {
            public List<string> tags { get; set; }
            public OwnerResponse owner { get; set; }
            public string title { get; set; }
            public long question_id { get; set; }
        }

        public class OwnerResponse
        {
            public string display_name { get; set; }
        }
    }
}
