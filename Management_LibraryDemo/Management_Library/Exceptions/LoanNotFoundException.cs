using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Library.Exceptions
{
    public class LoanNotFoundException : Exception
    {
        public LoanNotFoundException(string message) : base(message)
        {
        }
    }
}
