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

    public HomeController(IConfiguration configuration)
    {
      _configuration = configuration;
      _clientSingleton = ClientSingleton.Instance(configuration);
      _homeViewModel = new HomeViewModel();
    }
    public IActionResult Index(string ingredients)
    {
      return View("Index");
    }
    public async Task<IActionResult> SearchRecipes()
    {
      var ingredients = HomeViewModel.ParseIngredients();
      var response = await _clientSingleton.GetRecipies(ingredients);
      _homeViewModel.LoadRecipes(response);
      return View("Index");
    }
  }
}
