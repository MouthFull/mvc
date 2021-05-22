using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Mouthfull.Client.Models;
using Newtonsoft.Json;

namespace Mouthfull.Client.Controllers
{
  [Route("[controller]")]
  public class HomeController : Controller
  {
    private IConfiguration _configuration;

    public HomeController(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    public async Task<IActionResult> Index()
    {
      var client = new HttpClient();
      var response = await client.GetAsync($"{_configuration["Services:mouthfullapi"]}");
      List<object> result = null;

      if (response.IsSuccessStatusCode)
      {
        System.Console.WriteLine("====================================");
        System.Console.WriteLine(response.Content.ReadAsStringAsync());
        result = JsonConvert.DeserializeObject<List<object>>(await response.Content.ReadAsStringAsync());
        ViewBag.response = result;
        return View("Index");
      }
      // if (!response.IsSuccessStatusCode)
      // {
      //   result = JsonConvert.DeserializeObject<List<string>>(await response.Content.ReadAsStringAsync());
      //   ViewBag.response = result;
      //   return View("ResponseSuccess");
      // }
      return View("Index");
    }
  }

}
