using System;

using Calculatrice.UI;
using Calculatrice.Application;

namespace Calculatrice
{
  public class EquationSolver
  {
    const string EXIT_COMMAND = "";

    private readonly EquationReader equationReader = new EquationReader();
    private readonly ResultWriter resultWriter = new ResultWriter();
    private readonly EquationSolvingService equationSolvingService = new EquationSolvingService();

    public EquationSolver() { }

    public void Start()
    {
      Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
      Console.WriteLine("~~~~~~~~~~~~~~~~ CALCULATRICE V0.1 ~~~~~~~~~~~~~~~~");
      Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

      string equation = string.Empty;
      while (equation != EXIT_COMMAND)
      {
        equation = ReadEquation();

        if (equation != EXIT_COMMAND)
        {
          double result = equationSolvingService.SolveEquation(equation);
          WriteResult(equation);
        }
      }
    }

    private string ReadEquation()
    {
      return equationReader.Read();
    }

    private void WriteResult(string equation)
    {
      resultWriter.Write(equation);
    }

    public void End()
    {
      Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
      Console.WriteLine("~~~~~~~~~~~~~~~~ SEE YOU LATER! ~~~~~~~~~~~~~~~~~~~");
      Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
    }
  }
}
