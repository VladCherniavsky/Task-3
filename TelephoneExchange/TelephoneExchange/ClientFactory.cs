using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public class ClientFactory
    {
        public event EventHandler ClientCreated;

        public Client CreateNewClient(string name, string surname, DateTime dateOfBirth, string address,Terminal terminal, Agreement agreement)
        {
            Client client = new Client(name, surname, dateOfBirth, address, terminal, agreement);

            OnClientCreated(EventArgs.Empty);

            return client;
        }

        protected virtual void OnClientCreated(EventArgs e)
        {
            var handler = ClientCreated;
            if (handler != null)
                handler(this, e);
        }

    }
}
