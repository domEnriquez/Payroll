using System;
using TransactionApplication;
using TF = TransactionFactory;

namespace TransactionImplementation
{
    public class TransactionFactoryImplementation : TF.TransactionFactory
    {
        public override Transaction MakeAddCommisionedEmployee(Request r)
        {
            AddCommissionedEmployeeRequest req = r as AddCommissionedEmployeeRequest;
            return new AddCommissionedEmployee(req);
        }

        public override Transaction MakeAddHourlyEmployee(Request r)
        {
            AddHourlyEmployeeRequest req = r as AddHourlyEmployeeRequest;
            return new AddHourlyEmployee(req);
        }

        public override Transaction MakeAddSalariedEmployee(Request r)
        {
            AddSalariedEmployeeRequest req = r as AddSalariedEmployeeRequest;
            return new AddSalariedEmployee(req);
        }

        public override Transaction MakeDeleteEmployee(Request r)
        {
            DeleteEmployeeRequest req = r as DeleteEmployeeRequest;
            return new DeleteEmployeeTransaction(req);
        }

        public override Transaction MakeAddTimeCard(Request r)
        {
            TimeCardRequest req = r as TimeCardRequest;
            return new TimeCardTransaction(req);
        }

        public override Transaction MakeAddSalesReceipt(Request r)
        {
            SalesReceiptRequest req = r as SalesReceiptRequest;
            return new SalesReceiptTransaction(req);
        }

        public override Transaction MakeAddServiceCharge(Request r)
        {
            ServiceChargeRequest req = r as ServiceChargeRequest;
            return new ServiceChargeTransaction(req);
        }

        //public override Transaction MakeChangeCommissioned(Request r)
        //{
        //    ChangeCommissionedRequest req = r as ChangeCommissionedRequest;
        //    return new ChangeCommissionedTransaction(req);
        //}

        //public override Transaction MakeChangeDirectMethod(Request r)
        //{
        //    ChangeDirectMethodRequest req = r as ChangeDirectMethodRequest;
        //    return new ChangeDirectMethodTransaction(req);
        //}

        //public override Transaction MakeChangeHoldMethod(Request r)
        //{
        //    ChangeHoldMethodRequest req = r as ChangeHoldMethodRequest;
        //    return new ChangeHoldMethodTransaction(req);
        //}

        //public override Transaction MakeChangeHourly(Request r)
        //{
        //    ChangeHourlyRequest req = r as ChangeHourlyRequest;
        //    return new ChangeHourlyTransaction(req);
        //}

    }
}
