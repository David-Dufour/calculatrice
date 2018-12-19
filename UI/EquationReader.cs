using System;

using Calculatrice.Application;

namespace Calculatrice.UI
{
  public class EquationReader
  {
    private EquationValidator equationValidator = new EquationValidator();
    public EquationReader() { }

    public Equation Read()
    {
      string text = null;

      Console.WriteLine("Entrez une équation:");

      bool hasValidText = false;
      while (!hasValidText)
      {
        text = Console.ReadLine();
        hasValidText = equationValidator.Validate(text);

        if (!hasValidText)
        {
          Console.WriteLine("Saisie invalide! Veuillez réessayer:");
        }
      }

      return new Equation(text);
    }
  }
}
