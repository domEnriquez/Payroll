using PayollDomain;
using System.Collections.Generic;
using System.Linq;

namespace PayrollDatabase
{
    public class PayrollDb
    {
        private static Dictionary<int, Employee> employees = new Dictionary<int, Employee>();
        private static Dictionary<int, Employee> unionMemebers = new Dictionary<int, Employee>();

        public static void AddEmployee(int id, Employee employee)
        {
            employees[id] = employee;
        }

        public static List<int> GetAllEmployeeIds()
        {
            return employees.Keys.ToList();
        }

        public static Employee GetEmployee(int id)
        {
            if (employees.ContainsKey(id))
                return employees[id] as Employee;
            else
                return null;

        }

        public static void DeleteEmployee(int id)
        {
            employees.Remove(id);
        }

        public static Employee GetUnionMember(int memberId)
        {
            if (unionMemebers.ContainsKey(memberId))
                return unionMemebers[memberId] as Employee;
            else
                return null;
        }

        public static void AddUnionMember(int memeberId, Employee e)
        {
            unionMemebers[memeberId] = e;
        }

        public static void RemoveUnionMember(int memberId)
        {
            unionMemebers.Remove(memberId);
        }
    }
}
