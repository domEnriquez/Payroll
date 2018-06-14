using System;

namespace PaymentImplementation
{
    public class SalesReceipt
    {
        private double amount;
        private DateTime date;

        public SalesReceipt(DateTime dateTime, double amount)
        {
            this.date = dateTime;
            this.amount = amount;
        }

        public double Amount
        {
            get { return amount; }
        }

        public DateTime Date
        {
            get { return date; }
        }
    }
}
