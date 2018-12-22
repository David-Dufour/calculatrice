using System;
using System.Text.RegularExpressions;

namespace Calculatrice.Application
{
  public class EquationFactory
  {
    private const string WHITE_SPACES = @"\s+";

    public EquationFactory() { }

    public Domain.Equation CreateEquation(UI.Equation equation)
    {
      return new Domain.Equation(RemoveWhiteSpaces(equation.Text));
    }

    private string RemoveWhiteSpaces(string text)
    {
      return Regex.Replace(text, WHITE_SPACES, string.Empty);
    }
  }
}
