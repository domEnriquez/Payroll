using RequestsFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionApplication;

namespace TransactionImplementation
{
    public class RequestFactoryImplementation : RequestFactory
    {
        public override Request MakeSalariedEmployeeRequest(int empId, string name, string address, double salary)
        {
            return new AddSalariedEmployeeRequest(empId, name, address, salary);
        }

        public override Request MakeHourlyEmployeeRequest(int empId, string name, string address, int rate)
        {
            return new AddHourlyEmployeeRequest(empId, name, address, rate);
        }

        public override Request MakeCommissionedEmployeeRequest(int empId, string name, string address, double rate, int salary)
        {
            return new AddCommissionedEmployeeRequest(empId, name, address, rate, salary);
        }

        public override Request MakeDeleteEmployeeRequest(int empId)
        {
            return new DeleteEmployeeRequest(empId);
        }

        public override Request MakeTimeCardRequest(DateTime dateTime, double hours, int empId)
        {
            return new TimeCardRequest(dateTime, hours, empId);
        }

        public override Request MakeSalesReceiptRequest(DateTime dateTime, double amount, int empId)
        {
            return new SalesReceiptRequest(dateTime, amount, empId);
        }

        public override Request MakeServiceChargeRequest(int memeberId, DateTime dateTime, double charge)
        {
            return new ServiceChargeRequest(memeberId, dateTime, charge);
        }
    }
}
