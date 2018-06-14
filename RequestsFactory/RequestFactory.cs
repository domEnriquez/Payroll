using System;
using TransactionApplication;

namespace RequestsFactory
{
    public abstract class RequestFactory
    {
        public static RequestFactory rf;
        public abstract Request MakeSalariedEmployeeRequest(int empId, string name, string address, double salary);
        public abstract Request MakeHourlyEmployeeRequest(int empId, string name, string address, int rate);
        public abstract Request MakeCommissionedEmployeeRequest(int empId, string name, string address, double rate, int salary);
        public abstract Request MakeDeleteEmployeeRequest(int empId);
        public abstract Request MakeTimeCardRequest(DateTime dateTime, double hours, int empId);
        public abstract Request MakeSalesReceiptRequest(DateTime dateTime, double amount, int empId);
        public abstract Request MakeServiceChargeRequest(int memeberId, DateTime dateTime, double charge);
    }
}
