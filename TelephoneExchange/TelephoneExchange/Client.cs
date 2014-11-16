using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public class Client
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public Terminal Terminal { get; set; }
        public Agreement Agreement { get; set; }

        public Client(string name, string surname, DateTime dateOfBirth, string address, Terminal terminal)
        {
            FirstName = name;
            SecondName = surname;
            DateOfBirth = dateOfBirth;
            Address = address;
            Terminal = terminal;
        }


    }
}
