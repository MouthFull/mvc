using System;
using System.Collections.Generic;
using Xunit;
using Mouthfull.Client.Models;

namespace Mouthfull.Testing
{
  public class UnitTest1
  {
    [Fact]
    public void LoadIngredients()
    {
      List<string> IngredientList = new List<string>() { "chicken", "rice" };
      string actual = HomeViewModel.LoadIngredients(IngredientList);
      var expected = "chicken,rice";
      Assert.Equal(actual, expected);
    }
  }
}
