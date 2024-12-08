using prismProject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prismProject
{
    internal static class EmployeeData
    {
        public static List<Employee> employees { get; private set; } = new List<Employee>();
        public static int listIndex { get; private set; }

        public static void addEmployee(Employee employee)
        {
            employees.Add(employee);
        }


        public static void setListIndex(int index)
        {
            listIndex = index;
        }
    }
}
