using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    class Program
    {
        static void Main(string[] args)
        {
            Client m = new Client();
            m.DateOfBirth = "10.15.1993";
            Console.WriteLine(m.DateOfBirth);
        }
    }
}
