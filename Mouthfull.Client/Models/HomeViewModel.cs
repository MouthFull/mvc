using System.Collections.Generic;
using Mouthfull.Domain.Models;

namespace Mouthfull.Client.Models
{
  public class HomeViewModel
  {
    public List<Recipe> Recipes { get; set; }
    public List<string> InputArray { get; set; }
    public string Input { get; set; }
    public string IngredientQuery { get; set; }

    public void LoadRecipes(List<Recipe> recipes)
    {
      Recipes = recipes;
    }
    public string ParseIngredients()
    {
      string queryString = "";
      for (int i = 0; i < InputArray.Count; i++)
      {
        queryString += InputArray[i].Trim();
        if (i != InputArray.Count - 1)
        {
          queryString += ",";
        }
      }
      IngredientQuery = queryString;
      return IngredientQuery;
    }

    public List<Recipe> LoadDummyData()
    {
      var recipeList = new List<Recipe>() {
      };
      Recipes = recipeList;
      return recipeList;
    }

  }
}