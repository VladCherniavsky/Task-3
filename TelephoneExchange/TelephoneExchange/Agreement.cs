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
        public Tariff Tariff { get; set; }

        public Agreement(int number, DateTime date,Tariff tariff )
        {
            NumberOfAgreement = number;
            DateOfAgreement = date;
            Tariff = tariff;
        }
    }
}
