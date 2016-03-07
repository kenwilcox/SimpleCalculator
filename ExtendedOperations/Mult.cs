using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCalculator;

namespace ExtendedOperations
{
    [Export(typeof(IOperation))]
    [ExportMetadata("Symbol", '*')]
    class Mult: IOperation
    {
        public int Operate(int left, int right)
        {
            return left * right;
        }
    }
}
