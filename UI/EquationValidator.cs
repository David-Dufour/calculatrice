using System;
using System.Text.RegularExpressions;

using Calculatrice.Application;

namespace Calculatrice.UI
{
  public class EquationValidator
  {
    private const string VALID_CHARACTERS = @"^[\d\+\-\*\/\.\,\(\)]*$";
    public EquationValidator() { }

    public bool Validate(string text)
    {
      bool hasValidParenthesis = ValidateParenthesis(text);
      bool hasValidCharacters = ValidateCharacters(text);

      return hasValidParenthesis && hasValidCharacters;
    }

    private bool ValidateParenthesis(string text)
    {
      int numberOfOpenedParenthesis = 0;

      foreach (char c in text)
      {
        switch (c)
        {
          case '(':
            numberOfOpenedParenthesis++;
            break;

          case ')':
            numberOfOpenedParenthesis--;
            break;

          default:
            break;
        }

        if (numberOfOpenedParenthesis < 0)
        {
          return false;
        }
      }

      return numberOfOpenedParenthesis == 0;
    }

    private bool ValidateCharacters(string text)
    {
      Regex regexForValidCharacters = new Regex(VALID_CHARACTERS);

      return regexForValidCharacters.IsMatch(text);
    }
  }
}