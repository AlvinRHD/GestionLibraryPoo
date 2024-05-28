using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Library.Interfaces
{
    public interface ILoanService
    {
        void RegisterLoan(string clientEmail, int bookId, int loanDays);
        void ReturnBook(int loanId);
    }
}
