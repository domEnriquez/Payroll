using PayollDomain;
using PayrollBoundary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentImplementation
{
    public class HourlyClassification : PaymentClassification, TimeCardHandler
    {
        private double hourlyRate;
        private List<TimeCard> timeCards;

        public HourlyClassification(double hourlyRate)
        {
            this.hourlyRate = hourlyRate;
            timeCards = new List<TimeCard>();
        }

        public double HourlyRate
        {
            get
            {
                return hourlyRate;
            }
        }

        public void AddTimeCard(DateTime date, double hours)
        {
            TimeCard tc = new TimeCard(date, hours);
            timeCards.Add(tc);
        }

        public override double CalculatePay(PayCheck paycheck)
        {
            if (timeCards.Count == 0)
                return 0;

            double pay = 0;
            foreach (TimeCard tc in timeCards)
                pay += hourlyRate * tc.Hours;

            return pay;
        }

        public TimeCard GetTimeCard(DateTime dateTime)
        {
            return timeCards.FirstOrDefault(t => t.Date.Equals(dateTime));
        }
    }
}
