using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Library.Exceptions
{
    public class LoanNotFoundException : Exception
    {
        public int LoanId { get; } 

        public LoanNotFoundException(string message, int loanId) : base(message)
        {
            LoanId = loanId;
        }

        public LoanNotFoundException(string message) : base(message)
        {
        }

        public string GetDetailedMessage()
        {
            string errorMessage = Message;
            if (LoanId != 0)
            {
                errorMessage += $" ID del préstamo: {LoanId}";
            }
            return errorMessage;
        }
    }
}

