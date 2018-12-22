using System;
using System.Linq;

namespace Calculatrice.Domain
{
  public class Equation
  {
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
          result = SolveEquation();
        }

        return result.Value;
      }
    }

    private double SolveEquation()
    {
      string equationToSolve = SimplifyParentheses(equation);
      return double.Parse(Solve(equationToSolve));
    }

    private string SimplifyParentheses(string equation)
    {
      string equationToSimplify = equation;

      while (equationToSimplify.Contains('('))
      {
        SimplifyFirstParenthese(equationToSimplify);
      }

      return equationToSimplify;
    }

    private void SimplifyFirstParenthese(string equation)
    {
      int firstClosingParenthese = equation.IndexOf(')');
      int precedingOpeningParenthese = equation.Substring(0, firstClosingParenthese).LastIndexOf('(');

      string equationPrecedingParentheseToSimplify = equation.Substring(0, precedingOpeningParenthese);
      string equationToSolve = equation.Substring(precedingOpeningParenthese, firstClosingParenthese - precedingOpeningParenthese);
      string equationFollowingParentheseToSimplify = equation.Substring(firstClosingParenthese);

      equation = equationPrecedingParentheseToSimplify + Solve(equationToSolve) + equationFollowingParentheseToSimplify;
    }

    private string Solve(string equation)
    {
      equation = SolveMultiplicationsAndDivisions(equation);
      equation = SolveAdditionsAndSubstractions(equation);

      return equation;
    }

    private string SolveMultiplicationsAndDivisions(string equation)
    {
      while (equation.Contains('*') || equation.Contains('/'))
      {
        equation = Solve(equation, GetFirstOperatorIndexBetween('*', '/', equation));
      }

      if (equation.Contains("--"))
      {
        equation.Replace("--", "+");

        if (equation[0] == '+')
        {
          equation = equation.Substring(1);
        }
      }

      return equation;
    }

    private string SolveAdditionsAndSubstractions(string equation)
    {
      while (equation.Contains('+') || equation.Substring(1).Contains('-'))
      {
        equation = Solve(equation, GetFirstOperatorIndexBetween('+', '-', equation));
      }

      return equation;
    }

    private string Solve(string equation, int operatorIndex)
    {
      char firstOperator = equation[operatorIndex];

      Console.WriteLine("Equation: " + equation);

      string firstArgument = GetFirstArgument(equation, operatorIndex);
      string secondArgument = GetSecondArgument(equation, operatorIndex);
      string firstEquation = firstArgument + firstOperator + secondArgument;

      int startOfFirstEquation = equation.IndexOf(firstEquation);
      int endOfFirstEquation = startOfFirstEquation + firstEquation.Length;

      string before = equation.Substring(0, startOfFirstEquation);
      string solvedEquation = Solve(firstArgument, firstOperator, secondArgument);
      string after = equation.Substring(endOfFirstEquation, equation.Length - startOfFirstEquation - firstEquation.Length);

      if (before.Length > 0 && !IsAnOperator(before[before.Length - 1]))
      {
        solvedEquation = "+" + solvedEquation;
      }

      return before + solvedEquation + after;
    }

    private bool IsAnOperator(char character)
    {
      return character == '+' || character == '-' || character == '*' || character == '/';
    }

    private string Solve(string firstArgument, char binaryOperator, string secondArgument)
    {
      double first = Double.Parse(firstArgument);
      double second = Double.Parse(secondArgument);
      double result = 0;

      switch (binaryOperator)
      {
        case '+':
          result = first + second;
          break;

        case '-':
          result = first - second;
          break;

        case '*':
          result = first * second;
          break;

        case '/':
          result = first / second;
          break;
      }

      return result.ToString();
    }

    private int GetFirstOperatorIndexBetween(char firstOperator, char secondOperator, string equation)
    {
      string equationWithoutFirstElement = equation.Substring(1);
      int firstOccurenceOfFirstOperator = equationWithoutFirstElement.IndexOf(firstOperator) + 1;
      int firstOccurenceOfSecondOperator = equationWithoutFirstElement.IndexOf(secondOperator) + 1;

      int firstOccurence = Math.Min(firstOccurenceOfFirstOperator, firstOccurenceOfSecondOperator);

      return firstOccurence != 0 ? firstOccurence : Math.Max(firstOccurenceOfFirstOperator, firstOccurenceOfSecondOperator);
    }

    private string GetFirstArgument(string equation, int indexOfOperator)
    {
      string firstArgument = string.Empty;

      for (int i = indexOfOperator - 1; i >= 0; i--)
      {
        char c = equation[i];

        switch (c)
        {
          case '*':
          case '/':
          case '+':
            return firstArgument;

          case '-':
            firstArgument = c + firstArgument;
            return firstArgument;

          default:
            firstArgument = c + firstArgument;
            break;
        }
      }

      return firstArgument;
    }

    private string GetSecondArgument(string equation, int indexOfOperator)
    {
      string secondArgument = string.Empty;

      for (int i = indexOfOperator + 1; i < equation.Length; i++)
      {
        char c = equation[i];
        switch (c)
        {
          case '*':
          case '/':
          case '+':
            return secondArgument;

          case '-':
            if (i > indexOfOperator + 1)
            {
              return secondArgument;
            }
            break;

          default:
            break;
        }
        secondArgument += c;
      }

      return secondArgument;
    }
  }
}
