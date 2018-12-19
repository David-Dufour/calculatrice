using System;

using Calculatrice.UI;
using Calculatrice.Application;

namespace Calculatrice
{
  public class EquationSolver
  {
    private readonly EquationReader equationReader = new EquationReader();
    private readonly ResultWriter resultWriter = new ResultWriter();
    private readonly EquationSolvingService equationSolvingService = new EquationSolvingService();

    public EquationSolver() { }

    public void Start()
    {
      Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
      Console.WriteLine("~~~~~~~~~~~~~~~~ CALCULATRICE V0.1 ~~~~~~~~~~~~~~~~");
      Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

      var equation = ReadEquation();
      double result = equationSolvingService.SolveEquation(equation);
      WriteResult(result);
    }

    private Equation ReadEquation()
    {
      return equationReader.Read();
    }

    private void WriteResult(double result)
    {
      resultWriter.Write(result);
    }

    public void End()
    {
      Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
      Console.WriteLine("~~~~~~~~~~~~~~~~ SEE YOU LATER! ~~~~~~~~~~~~~~~~~~~");
      Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
    }
  }
}
