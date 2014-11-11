using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public class Agreement
    {
        public int NumberOfAgreement { get; set; }
        public DateTime DateOfAgreement { get; set; }

        public Agreement(int number, DateTime date)
        {
            NumberOfAgreement = number;
            DateOfAgreement = date;
        }
    }
}
