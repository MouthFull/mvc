using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Mouthfull.Domain.Models;

namespace Mouthfull.Client.Singletons
{
  public class ClientSingleton
  {
    private IConfiguration _configuration;
    private static ClientSingleton _instance;
    private HttpClient Client;
    public static ClientSingleton Instance(IConfiguration configuration)
    {
      {
        if (_instance == null)
        {
          _instance = new ClientSingleton(configuration);
        }
        return _instance;
      }
    }
    public ClientSingleton(IConfiguration configuration)
    {
      Client = new HttpClient();
      _configuration = configuration;
    }

    public async Task<List<Recipe>> GetRecipies(string path)
    {
      var response = await Client.GetAsync($"{_configuration["Services:mouthfullapi"]}{path}");
      List<Recipe> result = null;

      if (response.IsSuccessStatusCode)
      {
        result = await response.Content.ReadFromJsonAsync<List<Recipe>>();

        return result;
      }
      else if (!response.IsSuccessStatusCode)
      {
        return new List<Recipe>() { new Recipe() { title = "no good" } };
      }
      return null;
    }
  }





}