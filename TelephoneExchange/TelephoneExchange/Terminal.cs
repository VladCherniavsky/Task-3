using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public class Terminal
    {
        private int _phoneNumberOfCaller;
        public Port Port { get; set; }

        public Terminal(Port port)
        {
            Port = port;
        }

        public void ToCall(int abonentNumber)
        {
            if (Port.PhoneNumber != abonentNumber)
            {
                switch (Port.PortState)
                {
                    case PortState.Connected:
                        _phoneNumberOfCaller = abonentNumber;
                        this.Port.PortState = PortState.LineIsEngaged;
                        OnStartedCall(this.Port.PhoneNumber, abonentNumber);//Abonent with "Port.PhoneNumber" is calling to abonent with "abonentNumber"
                        break;

                    case PortState.LineIsEngaged:
                        Console.WriteLine("You're calling to somebody now");
                        break;
                    case PortState.Disconnected:
                        Console.WriteLine("Your phone is unplugged");
                        break;
                }
            }
            throw new Exception("Error!!! You can't  to call to yourself");
        }


        /// <summary>
        /// When abonent has  incoming call  the line changes a  state to "LineIsEngaged"
        /// </summary>
        public void IncomingCall(int numberOfCaller)
        {
            Port.PortState = PortState.LineIsEngaged;
            _phoneNumberOfCaller = numberOfCaller;
        }

        /// <summary>
        /// The meaning of this method is that abonent with "Port.PhoneNumber"
        /// answered on call from  another abonent "_phoneNumberOfCaller"
        /// When one abonent talks with second one the line is engaged
        ///  </summary>
        public void AnswerOnCall()
        {
            if (Port.PortState == PortState.LineIsEngaged)
            {
                OnAnsweredOnCall(Port.PhoneNumber, _phoneNumberOfCaller);
            }
        }
        /// <summary>
        /// One abonent hanged up. Call is finished
        /// </summary>
        public void HangUp()
        {
            if (Port.PortState == PortState.LineIsEngaged)
            {
                Port.PortState = PortState.Connected;
                OnFinishedCall(Port.PhoneNumber, _phoneNumberOfCaller);
            }

        }

        public delegate void StartingCall(int numberOfAnswerer, int numberOfCaller);
        public event  StartingCall StartedCall;
        protected virtual void OnStartedCall(int numberOfAnswerer, int numberOfCaller)
        {
            var handler = StartedCall;
            if (handler != null)
                handler(numberOfAnswerer, numberOfCaller);
        }

        public delegate void AnsweringOnCall(int numberOfAnswerer, int numberOfCaller);
        public event AnsweringOnCall AnsweredCall;
        protected virtual void OnAnsweredOnCall(int numberOfAnswerer, int numberOfCaller)
        {
            var handler = AnsweredCall;
            if (handler != null)
                handler( numberOfAnswerer, numberOfCaller);
        }

        public delegate void FinishingCall(int numberOfAnswerer, int numberOfCaller);
        public event FinishingCall FinishedCall;
        protected virtual void OnFinishedCall(int numberOfAnswerer, int numberOfCaller)
        {
            var handler = FinishedCall;
            if (handler != null)
                handler(numberOfAnswerer, numberOfCaller);
        }

    }
}
