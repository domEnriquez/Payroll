

using TransactionApplication;

namespace TransactionImplementation
{
    public class AddHourlyEmployeeRequest : Request
    {
        public AddHourlyEmployeeRequest(int empId, string name, string addr, double rate)
        {
            EmpId = empId;
            Name = name;
            Address = addr;
            HourlyRate = rate;
        }

        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double HourlyRate { get; set; }
    }
}
