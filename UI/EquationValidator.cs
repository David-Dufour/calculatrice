using System;

using Calculatrice.Application;

namespace Calculatrice.UI
{
  public class EquationValidator
  {
    public EquationValidator() { }

    public bool Validate(string text)
    {
      bool hasValidParenthesis = ValidateParenthesis(text);
      bool hasValidCharacters = ValidateCharacters(text);

      return hasValidParenthesis && hasValidCharacters;
    }

    private bool ValidateParenthesis(string text)
    {
      bool hasValidParenthesis = true;

      return hasValidParenthesis;
    }

    private bool ValidateCharacters(string text)
    {
      bool hasValidCharacters = true;

      return hasValidCharacters;
    }
  }
}