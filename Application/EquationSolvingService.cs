using System;

using Calculatrice.UI;

namespace Calculatrice.Application
{
  public class EquationSolvingService
  {
    private readonly EquationFactory equationFactory = new EquationFactory();

    public EquationSolvingService() { }

    public double SolveEquation(Equation equationToSolve)
    {
      var equation = equationFactory.CreateEquation(equationToSolve);
      return equation.Result;
    }
  }
}
