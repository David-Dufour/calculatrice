using System;

namespace Calculatrice.UI
{
  public class ResultWriter
  {
    public ResultWriter() { }

    public void Write(double result)
    {
      Console.WriteLine("The result is: " + result);
    }
  }
}
