using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TelephoneExchange
{
    public class Call
    {
        private int _timeSpan;
        public Client Caller { get; set; }
        public Client Answerer { get; set; }
        public DateTime TimeOfStartCall { get; set; }
        public DateTime TimeOfFinishCall { get; set; }
        public bool IsStartTalk { get; set; }

        public int DurationOfCall
        {
            get { return DurationOfCall; }
            set { DurationOfCall = _timeSpan; }
        }

        public int CalculateDurationOfCall(DateTime startTime, DateTime finishTime)
        {
           int start =  startTime.Second;
           int finish = finishTime.Second;
           return _timeSpan = finish - start;
        }

        public void StartCall()
        {
            TimeOfStartCall = DateTime.Now;
        }

        public void EndCall(double value)
        {
            TimeOfFinishCall = DateTime.Now.AddMinutes(value);
        }

    }
}
