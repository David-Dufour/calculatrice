using System;

namespace Calculatrice.Application
{
  public class EquationFactory
  {
    public EquationFactory() { }

    public Domain.Equation CreateEquation(UI.Equation equation)
    {
      return new Domain.Equation(equation.Text);
    }
  }
}
