using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Runtime.CompilerServices;

namespace SimpleCalculator
{
  class Program
  {
    private CompositionContainer _container;

    [Import(typeof(ICalculator))]
    public ICalculator calculator;

    private Program()
    {
      var catalog = new AggregateCatalog();
      catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));
      //Directory.CreateDirectory(@".\Extensions\");
      catalog.Catalogs.Add(new DirectoryCatalog(@".\Extensions\"));

      _container = new CompositionContainer(catalog);

      try
      {
        this._container.ComposeParts(this);
      }
      catch (CompositionException compositionException)
      {
        Console.Error.WriteLine(compositionException.ToString());
      }
    }

    static void Main(string[] args)
    {
      Program p = new Program();
      String s;
      Console.WriteLine("Enter Command: ");
      while (true)
      {
        s = Console.ReadLine();
        Console.WriteLine(p.calculator.Calculate(s));
      }
    }
  }
}
