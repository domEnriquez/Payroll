using System;

namespace PaymentImplementation
{
    public class ServiceCharge
    {
        private double charge;
        private DateTime time;

        public ServiceCharge(DateTime time, double charge)
        {
            this.time = time;
            this.charge = charge;
        }

        public double Amount {
            get
            {
                return charge;
            }
            set
            {
                charge = value;
            }
        }

        public DateTime Time {
            get
            {
                return time;
            }

            set
            {
                time = value;
            }
        }
    }
}
