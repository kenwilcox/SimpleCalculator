using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
  [Export(typeof(ICalculator))]
  class MySimpleCalculator : ICalculator
  {
    [ImportMany]
    IEnumerable<Lazy<IOperation, IOperationData>> operations;

    public string Calculate(string input)
    {
      int left;
      int right;
      Char operation;
      int fn = FindFirstNonDigit(input);
      if (fn < 0) return "Could not parse command.";

      try
      {
        left = int.Parse(input.Substring(0, fn));
        right = int.Parse(input.Substring(fn + 1));
      }
      catch
      {
        return "Could not parse command.";
      }

      operation = input[fn];

      foreach (Lazy<IOperation, IOperationData> i in operations)
      {
        if (i.Metadata.Symbol.Equals(operation)) return i.Value.Operate(left, right).ToString();
      }
      return "Operation Not Found.";
    }

    private int FindFirstNonDigit(String s)
    {
      for (int i = 0; i < s.Length; i++)
      {
        if (!(Char.IsDigit(s[i]))) return i;
      }
      return -1;
    }
  }
}
