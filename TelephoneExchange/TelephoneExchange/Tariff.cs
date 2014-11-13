using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public class Tariff
    {
        public string Name { get; set; }
        public int CostOfMinute { get; set; }
        public DateTime CreationDate { get; set; }
        public string NameOfClient { get; set; }

        public Tariff(String name, int cost, DateTime dateTime, Client client)
        {
            Name = name;
            CostOfMinute = cost;
            CreationDate = dateTime;
            NameOfClient = client.SecondName;
        }
    }
}
