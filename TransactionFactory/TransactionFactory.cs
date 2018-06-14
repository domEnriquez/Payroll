
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionApplication;

namespace TransactionFactory
{
    public abstract class TransactionFactory
    {
        public abstract Transaction MakeAddCommisionedEmployee(Request r);
        public abstract Transaction MakeAddHourlyEmployee(Request r);
        public abstract Transaction MakeAddSalariedEmployee(Request r);
        public abstract Transaction MakeDeleteEmployee(Request r);
        public abstract Transaction MakeAddTimeCard(Request r);
        public abstract Transaction MakeAddSalesReceipt(Request r);
        public abstract Transaction MakeAddServiceCharge(Request r);
    }
}
