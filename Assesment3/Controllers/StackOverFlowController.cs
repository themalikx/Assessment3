using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Assesment3.Services;
using Newtonsoft.Json;
using RestSharp;

namespace Assesment3.Controllers
{
    public class StackOverFlowController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService _categoryService;

        public StackOverFlowController(ILogger<HomeController> logger,
            ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }




        public IActionResult Index()
        {
            try
            {
                var client = new RestClient("https://api.stackexchange.com/2.3");
                var request = new RestRequest("/questions?page=1&pagesize=50&order=desc&sort=activity&site=stackoverflow", Method.Get);

                var response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    if (response.Content != null)
                    {
                        var result = JsonConvert.DeserializeObject<StackOverFlowResponse>(response.Content);
                        return View(result);
                    }
                }

            }
            catch (Exception)
            {
                // ignored
            }

            return View(new StackOverFlowResponse());
        }


        public IActionResult Question(long id)
        {
            try
            {
                var client = new RestClient("https://api.stackexchange.com/2.3");
                var request = new RestRequest($"/questions/{id}?order=desc&sort=activity&site=stackoverflow", Method.Get);

                var response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    if (response.Content != null)
                    {
                        var result = JsonConvert.DeserializeObject<StackOverFlowResponse>(response.Content);
                        if (result != null && result.items.Any())
                            return View(result);
                    }
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