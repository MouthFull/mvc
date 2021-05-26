using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Mouthfull.Client.Singletons;
using Mouthfull.Client.Models;

namespace Mouthfull.Client.Controllers
{
  [Route("[controller]/[action]")]
  public class HomeController : Controller
  {
    private static IConfiguration _configuration;
    private ClientSingleton _clientSingleton;
    private HomeViewModel _homeViewModel;

    public HomeController(IConfiguration configuration, HomeViewModel homeViewModel)
    {
      _configuration = configuration;
      _clientSingleton = ClientSingleton.Instance(configuration);
      _homeViewModel = homeViewModel;
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
           // var response = await _clientSingleton.GetRecipies("");
            HomeViewModel home = new HomeViewModel();
            home.LoadDummyData();
            var recipes = home.Recipes;
            return View("History", recipes);
        }
  }
}
