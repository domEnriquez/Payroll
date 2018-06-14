using PayollDomain;
using PayrollBoundary;
using PayrollDatabase;
using System;
using TransactionApplication;

namespace TransactionImplementation
{
    public class TimeCardTransaction : Transaction
    {
        private readonly DateTime date;
        private readonly double hours;
        private readonly int empId;

        public TimeCardTransaction(TimeCardRequest req)
        {
            date = req.DateTime;
            hours = req.Hours;
            empId = req.EmpId;
        }

        public TimeCardTransaction(DateTime date, double hours, int empId)
        {
            this.date = date;
            this.hours = hours;
            this.empId = empId;
        }

        public void Execute()
        {
            Employee e = PayrollDb.GetEmployee(empId);

            if (e != null)
            {
                TimeCardHandler tch = e.Classification as TimeCardHandler;
                //PaymentClassification hc = PayrollFactory.paymentFactory.MakeHourlyClassification(e.Classification);
                if (tch != null)
                    tch.AddTimeCard(date, hours);
                //hc.AddTimeCard(new TimeCard(date, hours));
                else
                    throw new InvalidOperationException("Tried to add timecard to non-hourly employee");
            }
            else
                throw new InvalidOperationException("No such employee.");
        }
    }
}
