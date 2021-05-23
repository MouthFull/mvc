using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Mouthfull.Client.Singletons;

namespace Mouthfull.Client.Controllers
{
  [Route("[controller]/[action]")]
  public class HomeController : Controller
  {
    private static IConfiguration _configuration;
    private ClientSingleton _clientSingleton;

    public HomeController(IConfiguration configuration)
    {
      _configuration = configuration;
      _clientSingleton = ClientSingleton.Instance(configuration);
    }
    public IActionResult Index(string ingredients)
    {
      return View("Index");
    }
    public async Task<IActionResult> SearchRecipes(string ingredients)
    {
      ingredients = "chicken";
      var response = await _clientSingleton.GetRecipies(ingredients);
      ViewBag.response = response;
      return View("Index");
    }
  }
}
