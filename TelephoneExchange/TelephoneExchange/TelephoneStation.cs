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

        /// <summary>
        /// Method simulates situation when one abonent tries to call to another one
        /// </summary>
        public void CallTo(int incomingNumber,int outgoingNumber)
        {
            Client incomingClient = GetClientByPhoneNumber(incomingNumber);
            Client outgoingClient = GetClientByPhoneNumber(outgoingNumber);

            Call call = new Call()
            {
                Caller = outgoingClient,
                Answerer = incomingClient
            };
            switch (outgoingClient.Terminal.Port.PortState)
            {
                case PortState.Connected:
                    outgoingClient.Terminal.IncomingCall(outgoingNumber);
                    call.StartCall();
                    break;
                case PortState.LineIsEngaged:
                    Console.WriteLine("This abonent is talking now");
                    outgoingClient.Terminal.HangUp();
                    break;
                    case PortState.Disconnected:
                    Console.WriteLine("This abonent doesn't exist");
                    outgoingClient.Terminal.HangUp();
                    break;
            }
            ListOfCall.Add(call);
        }


        /// <summary>
        /// Method simulates situation when one abonent answered on call
        /// </summary>
        public void AnswerOnCall(/*int incomingNumber,int outgoingNumber*/)
        {
            Call call = new Call();
            call.StartCall();
            call.IsStartTalk = true;
        }

        /// <summary>
        /// Method simulates situation when  two of abonents hanged up
        /// </summary>
        public void EndCall(int incomingNumber, int outgoingNumber)
        {
            Client incomingClient = GetClientByPhoneNumber(incomingNumber);
            Client outgoingClient = GetClientByPhoneNumber(outgoingNumber);
            Call call = new Call();
            call = GetCallByPhoneNumber(incomingNumber);
            if (call.IsStartTalk)
            {
                call.EndCall(2);
                incomingClient.Terminal.HangUp();
                outgoingClient.Terminal.HangUp();
            }

        }


    }
}
