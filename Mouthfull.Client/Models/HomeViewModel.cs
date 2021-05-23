using System.Collections.Generic;
using Mouthfull.Domain.Models;

namespace Mouthfull.Client.Models
{
  public class HomeViewModel
  {
    public List<Recipe> Recipes;
    public static List<string> Input;
    public static string IngredientQuery;

    public void LoadRecipes(List<Recipe> recipes)
    {
      Recipes = recipes;
    }
    public static string ParseIngredients()
    {
      string queryString = "";
      for (int i = 0; i < Input.Count; i++)
      {
        queryString += Input[i].Trim();
        if (i != Input.Count - 1)
        {
          queryString += ",";
        }
      }
      IngredientQuery = queryString;
      return IngredientQuery;
    }

  }
}