using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public class TelephoneStation
    {
        public List<Client> ListOfClient;
        public List<Call> ListOfCall;

        public TelephoneStation()
        {
            ListOfClient = new List<Client>();
            ListOfCall = new List<Call>();
        }

        public Client GetClientBySurname(string surname)
        {
            return ListOfClient.Find(x => x.SecondName == surname);
        }
        /// <summary>
        /// Returning clients by number of phone 
        /// </summary>
        
        public Client GetClientByPhoneNumber(int phoneNumber)
        {
            return ListOfClient.Find(x => x.Terminal.Port.PhoneNumber == phoneNumber);
        }

        /// <summary>
        /// Method returns client which was created in concrete day
        /// </summary>
        public Client GetClientByDateOfCreating(DateTime dateTime)
        {
            return ListOfClient.Find(x => x.Agreement.DateOfAgreement == dateTime);
        }
        /// <summary>
        /// Method returns all calls where concrete number of phone was mentioned
        /// </summary>
        
        public Call GetCallByPhoneNumber(int phoneNumber)
        {
            return
                ListOfCall.Find(
                    x =>
                        x.Answerer.Terminal.Port.PhoneNumber == phoneNumber &&
                        x.Caller.Terminal.Port.PhoneNumber == phoneNumber);
        }

        /// <summary>
        /// Method returns Calls which were made by specific client
        /// </summary>
        public Call GetCallBySurame(string name)
        {
            return ListOfCall.Find(x => x.Caller.SecondName == name);
        }


    }
}
