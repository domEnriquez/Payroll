
using TransactionApplication;

namespace TransactionImplementation
{
    public class AddSalariedEmployeeRequest : Request
    {
        public AddSalariedEmployeeRequest(int empId, string name, string addr, double salary)
        {
            EmpId = empId;
            Name = name;
            Address = addr;
            Salary = salary;
        }

        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Salary { get; set; }
    }
}
