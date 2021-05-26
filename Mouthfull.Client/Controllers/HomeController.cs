using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Mouthfull.Client.Singletons;
using Mouthfull.Client.Models;
using Mouthfull.Domain.Models;
using System.Net.Http.Json;

namespace Mouthfull.Client.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private static IConfiguration _configuration;
        private ClientSingleton _clientSingleton;
        private HomeViewModel _homeViewModel;
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IConfiguration configuration, HomeViewModel homeViewModel, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _clientSingleton = ClientSingleton.Instance(configuration);
            _homeViewModel = homeViewModel;
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public IActionResult Index(HomeViewModel home)
        {
            home.LoadDummyData();
            return View("Index", home);
        }
        [HttpPost]
        public async Task<IActionResult> SearchRecipes(HomeViewModel home)
        {
            System.Console.WriteLine("=====================>" + home.Input);
            var ingredients = home.Input;
            System.Console.WriteLine("=====================>" + ingredients);
            var response = await _clientSingleton.GetRecipies(ingredients);
            home.LoadRecipes(response);
            return View("Index", home);
        }
        public async Task<IActionResult> History()
        {
            string endpoints = "http://localhost:5000/api/history";
            var httpclient = _httpClientFactory.CreateClient();
            var response = await httpclient.GetAsync($"{endpoints}");
            List<RecipeSummary> recipes = new List<RecipeSummary>();
            if (response.IsSuccessStatusCode)
            {
                recipes = await response.Content.ReadFromJsonAsync<List<RecipeSummary>>();

                return View("History", recipes);
            }
            else
            {
                return BadRequest();
            }
        }
        public async Task<IActionResult> RecipeSummary(int id)
        {
            string endpoints = "http://localhost:5000/api/recipe/";
            var httpclient = _httpClientFactory.CreateClient();
            var response = await httpclient.GetAsync($"{endpoints}{id}");
            RecipeSummary result = new RecipeSummary();

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadFromJsonAsync<RecipeSummary>();

                return View("RecipeSummary", result);
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
