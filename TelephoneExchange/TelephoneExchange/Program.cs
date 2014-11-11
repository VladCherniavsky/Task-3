using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientFactory factory = new ClientFactory();

            factory.ClientCreated += (s, e) => Console.WriteLine("Client created");

            Client c1 = factory.CreateNewClient("Igor", "Pety", "10.25.15", "Limizha");

        }
    }

}
