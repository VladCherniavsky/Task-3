using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public static  class Billing
    {
        /// <summary>
        /// This static method  displays report for abonent
        /// Report contains following information:
        /// Number of phone  of caller
        /// Number of phone of  answerer
        /// Time when abonent called another one
        /// Time when an abonent hanged up
        /// Duration of call 
        /// Payment for this call
        /// </summary>
       
        public static void GetCallReport(Client client, List<Call> listOfCall)
        {
            var reports = from x in listOfCall
                where x.IsStartTalk && (x.Caller.Terminal.Port.PhoneNumber == client.Terminal.Port.PhoneNumber
                                        || x.Answerer.Terminal.Port.PhoneNumber == client.Terminal.Port.PhoneNumber)
                select new
                {
                    anotherAbonent = x.Caller.Terminal.Port.PhoneNumber == client.Terminal.Port.PhoneNumber
                        ? x.Caller.Terminal.Port.PhoneNumber
                        : x.Answerer.Terminal.Port.PhoneNumber,
                    OutputCall = x.Caller.Terminal.Port.PhoneNumber == client.Terminal.Port.PhoneNumber,
                    StartTalkTime = x.TimeOfStartCall,
                    EndCalltime = x.TimeOfFinishCall,
                    DurationOfCall = x.DurationOfCall,
                    PriceForCall = x.Caller.Terminal.Port.PhoneNumber == client.Terminal.Port.PhoneNumber
                        ? x.DurationOfCall*client.Agreement.Tariff.CostOfMinute
                        : 0
                };
            Console.WriteLine("Your number of phone is {0}", client.Terminal.Port.PhoneNumber);
            foreach (var call in reports)
            {
                Console.WriteLine("{0} {1} {2} {3} {4}",call.anotherAbonent,call.StartTalkTime,call.EndCalltime, call.DurationOfCall, call.PriceForCall);
            }

        }
    }
}
