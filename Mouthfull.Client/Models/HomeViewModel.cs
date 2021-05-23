using System.Collections.Generic;
using Mouthfull.Domain.Models;

namespace Mouthfull.Client.Models
{
  public class HomeViewModel
  {
    public List<Recipe> Recipes;
    public List<string> Input;
    public static string IngredientQuery;

    public void LoadRecipes(List<Recipe> recipes)
    {
      Recipes = recipes;
    }
    public static string LoadIngredients(List<string> ingredients)
    {
      string queryString = "";
      for (int i = 0; i < ingredients.Count; i++)
      {
        queryString += ingredients[i];
        if (i != ingredients.Count - 1)
        {
          queryString += ",";
        }
      }
      IngredientQuery = queryString;
      return IngredientQuery;
    }

  }
}