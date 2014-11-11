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
        public string DateOfBirth { get; set; }
        public string Address { get; set; }

        public Client(string name, string surname, string dateOfBirth, string address)
        {
            FirstName = name;
            SecondName = surname;
            DateOfBirth = name;
            Address = address;
        }

        
    }
}
