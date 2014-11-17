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
            TelephoneStation station = new TelephoneStation();
            ClientFactory factory = new ClientFactory();

            factory.ClientCreated += (s, e) => Console.WriteLine("Client created");

        
            Client c1 = factory.CreateNewClient("Igor", "Vasil'ev", new DateTime(1996, 10, 25), "Limozha 48 27", new Terminal(new Port(PortState.Connected, 767993 )), new Agreement(123, new DateTime(2014,10,25), new Tariff("Great", 1, new DateTime(2014,10,25))));
            Client c2 = factory.CreateNewClient("Petia", "Kern", new DateTime(200, 10, 25), "Brikelia 24 3", new Terminal(new Port(PortState.Connected, 767994)),new Agreement(124, new DateTime(2014,11,25), new Tariff("Simple", 2, new DateTime(2014,11,25))));


            station.ListOfClient.Last().Terminal.StartedCall += station.CallTo;
            station.ListOfClient.Last().Terminal.StartedCall += station.AnswerOnCall;
            station.ListOfClient.Last().Terminal.StartedCall += station.EndCall;

            Billing.GetCallReport(station.ListOfClient[0], station.ListOfCall);

        }
    }
}
