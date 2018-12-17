using System;
using Xunit;
using Domain;

namespace Tests.Domain
{
  public class CalculatorTests
  {
    private readonly Calculator calculator = new Calculator();

    [Fact]
    public void WhenCalculatingTheSumOfTwoNumbers_ThenAddTheNumbersTogether()
    {
      var sum = calculator.Sum(1.111, 2.222);

      Assert.Equal(3.333, sum);
    }

    [Fact]
    public void WhenCalculatingTheSumOfNegativeNumbers_ThenSubstractTheNegativeValueFromThePositive()
    {
      var sum = calculator.Sum(-1.111, 2.222);

      Assert.Equal(1.111, sum);
    }
  }
}
