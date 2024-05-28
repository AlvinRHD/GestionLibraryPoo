using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Library.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string ClientEmail { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsReturned { get; set; } = false;
    }
}
