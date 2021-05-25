using System;
using System.Collections.Generic;
using Xunit;
using Mouthfull.Client.Models;

namespace Mouthfull.Testing
{
  public class UnitTest1
  {
    [Fact]
    public void ConcatinatesIngredients()
    {
      var HomeViewModel = new HomeViewModel();
      HomeViewModel.InputArray = new List<string>() { "chicken", "rice" };
      string actual = HomeViewModel.ParseIngredients();
      var expected = "chicken,rice";
      Assert.Equal(actual, expected);
    }
    [Fact]
    public void RemovesWhiteSpace()
    {
      var HomeViewModel = new HomeViewModel();
      HomeViewModel.InputArray = new List<string>() { " chicken ", " rice" };
      string actual = HomeViewModel.ParseIngredients();
      var expected = "chicken,rice";
      Assert.Equal(actual, expected);
    }
  }
}
