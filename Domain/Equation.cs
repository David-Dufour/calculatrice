using System;

namespace Calculatrice.Domain
{
  public class Equation
  {
    private readonly Calculator calculator = new Calculator();
    private readonly string equation;

    public Equation(string equation)
    {
      this.equation = equation;
    }

    private double? result;
    public double Result
    {
      get
      {
        if (!result.HasValue)
        {
          result = Solve(equation);
        }

        return result.Value;
      }
    }

    private double Solve(string equation)
    {
      double result;
      if (double.TryParse(equation, out result))
      {
        return result;
      }

      return 0;
    }
  }
}
