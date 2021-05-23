using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

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

    public async Task<List<object>> GetRecipies(string path)
    {
      var response = await Client.GetAsync($"{_configuration["Services:mouthfullapi"]}{path}");
      List<object> result = null;

      if (response.IsSuccessStatusCode)
      {
        result = JsonConvert.DeserializeObject<List<object>>(await response.Content.ReadAsStringAsync());

        return result;
      }
      else if (!response.IsSuccessStatusCode)
      {
        return new List<object>() { "no good", "no good" };
      }
      return null;
    }
  }





}