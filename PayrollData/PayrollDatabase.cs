using Payroll.Entity;
using System.Collections.Generic;

namespace PayrollData
{
    public class PayrollDatabase
    {
        private static Dictionary<int, Employee> employees = new Dictionary<int, Employee>();

        public static void AddEmployee(int id, Employee employee)
        {
            employees[id] = employee;
        }

        public static Employee GetEmployee(int id)
        {
            return employees[id] as Employee;
        }


    }
}
