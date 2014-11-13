using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public class HistoryOfTeriffes
    {
        private List<Tariff> _history= new List<Tariff>();

        public HistoryOfTeriffes(Tariff tariff)
        {
            _history.Add(tariff);
        }
        /// <summary>
        /// Method returns tariff by SecondName which client uses
        /// </summary>
        
        public Tariff GetTariffByClient(Client client)
        {
            return _history.Find(x => x.NameOfClient == client.SecondName);
        }

        /// <summary>
        /// Method returns tariff which was created in certain date
        /// </summary>
       

        public Tariff GerTariffByDate(DateTime dateTime)
        {
            return _history.Find(x => x.CreationDate == dateTime);
        }
    }
}
