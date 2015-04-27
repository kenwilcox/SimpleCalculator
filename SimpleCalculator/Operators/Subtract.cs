﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator.Operators
{
  [Export(typeof (IOperation))]
  [ExportMetadata("Symbol", '-')]
  internal class Subtract : IOperation
  {
    public int Operate(int left, int right)
    {
      return left - right;
    }
  }
}
