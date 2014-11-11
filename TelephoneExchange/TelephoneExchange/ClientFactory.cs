using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public class ClientFactory
    {
        public event EventHandler ClientCreated;

        public Client CreateNewClient(string name, string surname, string dateOfBirth, string address)
        {
            Client client = new Client(name, surname, dateOfBirth, address);

            OnClientCreated();

            return client;
        }

        protected virtual void OnClientCreated(EventArgs e)
        {
            var handler = ClientCreated;
            if (handler != null)
                handler(this, e);
        }
        private void OnClientCreated()
        {
            OnClientCreated(EventArgs.Empty);
        }
    }
}
