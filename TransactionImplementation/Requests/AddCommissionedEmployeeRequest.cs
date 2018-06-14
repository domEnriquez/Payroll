

using TransactionApplication;

namespace TransactionImplementation
{
    public class AddCommissionedEmployeeRequest : Request
    {

        public AddCommissionedEmployeeRequest(int empId, string name, string addr, double rate, double salary)
        {
            EmpId = empId;
            Name = name;
            Address = addr;
            HourlyRate = rate;
            Salary = salary;
        }

        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double HourlyRate { get; set; }
        public double Salary { get; set; }
    }
}
