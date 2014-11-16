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

        
            Client c1 = factory.CreateNewClient("Igor", "Vasil'ev", new DateTime(1996, 10, 25), "Limozha 48 27", new Terminal(new Port(PortState.Connected, 767993 )));
            Client c2 = factory.CreateNewClient("Petia", "Kern", new DateTime(200, 10, 25), "Brikelia 24 3", new Terminal(new Port(PortState.Connected, 767994)));


            station.ListOfClient.Last().Terminal.StartedCall += station.CallTo;
            station.ListOfClient.Last().Terminal.StartedCall += station.AnswerOnCall;
            station.ListOfClient.Last().Terminal.StartedCall += station.EndCall;

            Billing.GetCallReport(station.ListOfClient[0], station.ListOfCall);

        }
    }
}
