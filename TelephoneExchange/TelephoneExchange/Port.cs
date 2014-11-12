using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public class Port
    {
        private PortState _portState;
        public Terminal Terminal { get; set; }
        public int PhoneNumber { get; set; }

        public PortState PortState
        {
            get { return this._portState; }
            set
            {
                if (_portState != value)
                {
                    OnStateChanging(this, null);
                    _portState = value;
                    OnStateChanged(this, null);
                }
            }
        }
       

        public Port(PortState portState, int phoneNumber)
        {
            PortState = portState;
            PhoneNumber = phoneNumber;
        }


        protected virtual void OnStateChanging(object sender, EventArgs e)
        {
            var temp = StateChanging;
            if (temp != null)
            {
                temp(sender, e);
            }
        }


        protected virtual void OnStateChanged(object sender, EventArgs e)
        {
            var temp = StateChanged;
            if (temp != null)
            {
                temp(sender, e);
            }
        }

        public event EventHandler<EventArgs> StateChanged;
        public event EventHandler<EventArgs> StateChanging;
    }
}
